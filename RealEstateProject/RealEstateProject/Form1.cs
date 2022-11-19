using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace RealEstateProject
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
            //MessageBox.Show(GetCell(2, 2), "2, 2 eredménye");
        }

        void LoadData()
        {
            Flats = context.Flat.ToList();
        }

        void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string ErrorMessage = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(ErrorMessage, "Error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
            
        }

        void CreateTable()
        {
            string[] headers = new string[]
            {
                "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobák száma",
                "Alapterület (m2)",
                "Ár (mFt)",
                "Négyzetméter ár (Ft/m2)"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i+1] = headers[i];
            }
            object[,] values = new object[Flats.Count, headers.Length];

            int index = 0;
            foreach (Flat f in Flats)
            {
                values[index, 0] = f.Code;
                values[index, 1] = f.Vendor;
                values[index, 2] = f.Side;
                values[index, 3] = f.District;
                values[index, 4] = f.Elevator;
                values[index, 5] = f.NumberOfRooms;
                values[index, 6] = f.FloorArea;
                values[index, 7] = f.Price;
                values[index, 8] = "";
                index++;
            }

            xlSheet.get_Range(
                GetCell(2, 1), 
                GetCell(1+values.GetLength(0),values.GetLength(1))
                ).Value2=values;
            string[] kepletesoszlop = new string[Flats.Count];
            index = 0;
            string arcella;
            string teruletcella;
            foreach (string item in kepletesoszlop)
            {
                arcella = GetCell(index + 1, 8);
                teruletcella = GetCell(index + 1, 7);
                kepletesoszlop[index] = "=1000000*"+arcella+"/" + teruletcella;
                
                //kepletesoszlop[index] = String.Format("={1}/{2}", GetCell(index+1, 8), GetCell(index+1,7));
                Console.WriteLine(kepletesoszlop[index]);
                index++;
            }
            //while (index < kepletesoszlop.Length)
            //{
            //    kepletesoszlop[index] = String.Format("={1}/{2}", GetCell(index + 1, 8), GetCell(index + 1, 7));
            //    Console.WriteLine(kepletesoszlop[index]);
            //    index++;
            //}
            xlSheet.get_Range(GetCell(2,9),GetCell(kepletesoszlop.Length+1,9)).Value = kepletesoszlop;

        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();
            return ExcelCoordinate;
        }
    }
}
