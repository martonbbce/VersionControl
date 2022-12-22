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
using VARProject.Entities;

namespace VARProject
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticklist;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        public Form1()
        {
            InitializeComponent();
            Ticklist = context.Tick.ToList();
            dataGridView1.DataSource = Ticklist;
            CreatePortfolio();
                        
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticklist
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void Nyeresegek()
        {
            //08feladat
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files | *.txt";
            saveFileDialog1.Title = "Save Profits File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                tw.WriteLine("Időszak Nyereség");

                List<decimal> Nyereségek = new List<decimal>();
                int intervalum = 30;
                DateTime kezdőDátum = (from x in Ticklist select x.TradingDay).Min();
                DateTime záróDátum = new DateTime(2016, 12, 30);
                TimeSpan z = záróDátum - kezdőDátum;
                for (int i = 0; i < z.Days - intervalum; i++)
                {
                    decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                               - GetPortfolioValue(kezdőDátum.AddDays(i));
                    Nyereségek.Add(ny);
                    Console.WriteLine(i + " " + ny);
                    tw.WriteLine(i + " " + ny);
                }

                var nyereségekRendezve = (from x in Nyereségek
                                          orderby x
                                          select x)
                                            .ToList();
                MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());


                tw.Close();
            }
            else MessageBox.Show("Nem adtál meg fájlnevet!");

            
        }

        private void btnSaveProfit_Click(object sender, EventArgs e)
        {
            Nyeresegek();
            
        }
    }
}
