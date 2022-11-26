using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WebServiceGyak05.Entities;
using System.Windows.Forms.DataVisualization.Charting;


namespace WebServiceGyak05
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates;
        public Form1()
        {
            InitializeComponent();
            Rates = new BindingList<RateData>();
            dataGridView1.DataSource = Rates;
            
            DoXml();
            //DiagramAbrazolas();
            RefreshData();
        }
        private string LoadMnbServices()
        {
            var mnbService = new MnbServiceReference.MNBArfolyamServiceSoapClient();
            var request = new MnbServiceReference.GetExchangeRatesRequestBody()
            {
                currencyNames = comboBoxCurrency.SelectedItem.ToString(),
                startDate = dtPickerStartDate.Value.ToString(),
                endDate = dtPickerEndDate.Value.ToString()
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            File.WriteAllText("kimenet"+DateTime.Now.ToString("yyMMddHHmm"), result);
            //Rates = new BindingList<RateData>();
            mnbService.Close();
            return result;
        }
        void DoXml()
        {
            XmlDocument xmldocc = new XmlDocument();
            xmldocc.LoadXml(LoadMnbServices());
            foreach (XmlElement el in xmldocc.DocumentElement)
            {
                RateData rd = new RateData();
                Rates.Add(rd);
                rd.Date = DateTime.Parse(el.GetAttribute("date"));
                var childElement = (XmlElement)el.ChildNodes[0];
                rd.Currency = childElement.GetAttribute("curr");
                var unitt = decimal.Parse(childElement.GetAttribute("unit"));
                var valuee = decimal.Parse(childElement.InnerText);
                if (unitt != 0)
                    rd.Value = valuee / unitt;
                else
                    rd.Value = valuee;
            }
        }
        void DiagramAbrazolas()
        {
            chartRateData.DataSource = Rates;
            chartRateData.Series[0].ChartType = SeriesChartType.Line;
            chartRateData.Series[0].XValueMember = "Date";
            chartRateData.Series[0].YValueMembers = "Value";
            chartRateData.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRateData.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartRateData.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }
        void RefreshData()
        {
            DiagramAbrazolas();
            Rates.Clear();

        }

        private void dtPickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dtPickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
