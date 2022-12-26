using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].Name = "30";
            chart1.Series[1].Name = "40";
            chart1.Series[2].Name = "50";
            chart1.Series[3].Name = "60";
            chart1.Series[4].Name = "70";
            chart1.Series[5].Name = "80";
            chart1.Series[6].Name = "90";
            chart2.Series[0].Name = "Объем заказа";
            chart3.Series[0].Name = "Спрос";
            chart3.Series[1].Name = "Заказ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int Ch = 60;
            int Cd = 160;
            int MC = 40;
            int[] Part = { 30, 40, 50, 60, 70, 80, 90 };
            int SC = 10;
            Random random = new Random();
            int[] demand = new int[100];
            double[] demandAverage = new double[7];
            double[,] cost = new double[7, 100];
            double temp;
            int x = 0;

            for (int j = 0; j < Part.Length; j++)
            {
                Desigin(Part[j], j);
            }

            x = 0;
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < 7; i++)
            {
                chart2.Series[0].Points.Add(demandAverage[i]);
                ++x;
            }



            void Desigin(int part, int j)
            {
                temp = 0;
                for (int i = 0; i < 100; i++)
                {
                    int dem = (int)Math.Round(random.NextDouble() * SC);
                    demand[i] = part + dem - 5;
                }

                
                if (j == 1) //Рисовка
                {
                    x = 0;
                    chart3.Series[0].Points.Clear();
                    chart3.Series[1].Points.Clear();
                    for (int i = 0; i < 100; i++)
                    {
                        chart3.Series[0].Points.AddXY(x, MC);
                        chart3.Series[1].Points.AddXY(x, demand[i]);
                        ++x;
                    }
                }

                for (int i = 0; i < 100; i++)
                {
                    if (demand[i] < MC)
                    {
                        cost[j, i] = Ch * (MC - demand[i]);
                    }
                    else
                    {
                        cost[j, i] = Cd * (demand[i] - MC);
                    }
                }
                
                x = 0;
                chart1.Series[0].Points.Clear();
                for (int i = 0; i < 100; i++)
                {
                    chart1.Series[j].Points.AddXY(x, cost[j, i]);
                    ++x;
                    temp += cost[j, i];
                }
                demandAverage[j] = temp / 100;
            }
        }
    }
}
