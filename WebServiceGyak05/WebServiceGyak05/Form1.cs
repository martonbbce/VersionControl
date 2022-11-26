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
            
        }
        private static string LoadMnbServices()
        {
            var mnbService = new MnbServiceReference.MNBArfolyamServiceSoapClient();
            var request = new MnbServiceReference.GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate="2022-01-01",
                endDate="2022-10-31"
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            File.WriteAllText("kimenet"+DateTime.Now.ToString("yyMMddHHmm"), result);
            //Rates = new BindingList<RateData>();
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
            }
        }
    }
}
