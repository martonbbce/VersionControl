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

namespace WebServiceGyak05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadMnbServices();
        }
        void LoadMnbServices()
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
            File.WriteAllText("kimenet.txt", result);
            
        }
    }
}
