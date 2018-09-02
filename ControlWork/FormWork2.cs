using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlWork
{
    public partial class FormWork2 : Form
    {
        List<List<int>> table3;
        List<List<int>> table4;
        int max = 0;
        double Gmax2 = 0;

        public FormWork2()
        {
            InitializeComponent();

            FillTable3();
            FillTable4();
            FillTable5();
            DrawPlot();
        }
        // обрезает изображение
        private void FormWork2_Resize(object sender, EventArgs e)
        {
            //DrawPlot();
            //labelConclusion.Location = new Point(12, pictureBoxPlot.Location.Y + pictureBoxPlot.Height + 3);
        }

        private void FillTable3()
        {
            table3 = new List<List<int>>();
            int[] row1 = new int[] { 59, 90, 110, 240, 260, 270, 320, 525 };
            int[] row2 = new int[] { 35, 51, 70, 150, 240, 290, 350, 380 };
            int[] row3 = new int[] { 20, 40, 90, 130, 150, 220, 320, 410, 475, 530 };
            table3.Add(row1.ToList());
            table3.Add(row2.ToList());
            table3.Add(row3.ToList());

            for (int i = 0; i < table3.Count; i++)
                for (int j = 0; j < table3[i].Count; j++)
                    table3[i][j] += ControlWork.Select.GetAdditionNum();

            object[] row = new object[11];
            foreach (var temp in table3)
            {
                if (temp.Equals(table3[0]))
                    row[0] = "Первое изделие:";
                else if (temp.Equals(table3[1]))
                    row[0] = "Второе изделие:";
                else
                    row[0] = "Третье изделие:";
                int i = 1;
                foreach (var t in temp)
                {
                    row[i] = t;
                    i++;
                }
                dataGridViewTable3.Rows.Add(row);
            }
        }

        private void FillTable4()
        {
            table4 = new List<List<int>>();
            int[] row14 = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] row24 = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] row34 = new int[] { 0, 0, 0, 0, 0, 0 };
            table4.Add(row14.ToList());
            table4.Add(row24.ToList());
            table4.Add(row34.ToList());

            for (int i = 0; i < table3.Count; i++)
            {
                for (int j = 0; j < table3[i].Count; j++)
                {
                    if (table3[i][j] < 100 && table3[i][j] >= 0)
                        table4[i][0]++;
                    if (table3[i][j] < 200 && table3[i][j] >= 100)
                        table4[i][1]++;
                    if (table3[i][j] < 300 && table3[i][j] >= 200)
                        table4[i][2]++;
                    if (table3[i][j] < 400 && table3[i][j] >= 300)
                        table4[i][3]++;
                    if (table3[i][j] < 500 && table3[i][j] >= 400)
                        table4[i][4]++;
                    if (table3[i][j] < 600 && table3[i][j] >= 500)
                        table4[i][5]++;
                }
            }

            object[] row = new object[7];
            foreach (var temp in table4)
            {
                if (temp.Equals(table4[0]))
                    row[0] = "Первое изделие:";
                else if (temp.Equals(table4[1]))
                    row[0] = "Второе изделие:";
                else
                    row[0] = "Третье изделие:";
                int i = 1;
                foreach (var t in temp)
                {
                    row[i] = t;
                    i++;
                }
                dataGridViewTable4.Rows.Add(row);
            }
        }

        private void FillTable5()
        {
            //int max = 0;
            int min = 0;
            List<int> Wm = new List<int>();

            for (int i = 0; i < table4.Count; i++)
            {
                if (table4[i].Max() > max)
                    max = table4[i].Max();
                if (table4[i].Min() < min)
                    min = table4[i].Min();
            }

            for (int i = min; i <= max; i++)
            {
                int count = 0;
                foreach (var t in table4)
                    count += t.FindAll(p => p == i).Count;
                Wm.Add(count);
            }

            int n = Wm.Sum();

            List<double> Pm_stat = new List<double>();
            foreach (var temp in Wm)
                Pm_stat.Add(temp / Convert.ToDouble(n));

            List<double> mPm_stat = new List<double>();
            for (int i = 0; i < Pm_stat.Count; i++)
                mPm_stat.Add(Pm_stat[i] * (min + i));

            double mx = mPm_stat.Sum();

            List<double> difmx = new List<double>();
            for (int i = min; i <= max; i++)
                difmx.Add(Math.Abs(i - mx));

            List<double> difmx2 = new List<double>();
            foreach (var temp in difmx)
                difmx2.Add(Math.Pow(temp, 2));

            List<double> difmx2Pm_stat = new List<double>();
            for (int i = 0; i < difmx2.Count; i++)
                difmx2Pm_stat.Add(difmx2[i] * Pm_stat[i]);

            double Dx = difmx2Pm_stat.Sum();

            List<double> Pm_theor = new List<double>();
            for (int i = min; i <= max; i++)
                Pm_theor.Add(Math.Pow(mx, i) / Factorial(i) * Math.Exp(-mx));

            List<double> Gm2 = new List<double>();
            for (int i = 0; i < Pm_stat.Count; i++)
                Gm2.Add(Math.Abs(Pm_stat[i] - Pm_theor[i]));

            Gmax2 = 1.63 / Math.Sqrt(n);

            int Npp = 1;
            object[] row = new object[10];
            for (int i = min; i <= max; i++)
            {
                row[0] = Npp;
                row[1] = i;
                row[2] = Wm[i - min];
                row[3] = Math.Round(Pm_stat[i - min], 3);
                row[4] = Math.Round(mPm_stat[i - min], 3);
                row[5] = Math.Round(difmx[i - min], 3);
                row[6] = Math.Round(difmx2[i - min], 3);
                row[7] = Math.Round(difmx2Pm_stat[i - min], 3);
                row[8] = Math.Round(Pm_theor[i - min], 3);
                row[9] = "± " + Math.Round(Gm2[i - min], 3);
                dataGridViewTable5.Rows.Add(row);
                Npp++;
            }

            labelN.Text = "n = " + n;
            labelMx.Text = "m = " + Math.Round(mx, 3);
            labelDx.Text = "D(x) = " + Math.Round(Dx, 3);

            bool err = false;
            foreach (var temp in Gm2)
                if (temp > Gmax2)
                    err = true;
            
            if (err)
            {
                labelConclusion.Text = "";
                labelConclusionGm.Text = "Значение отклонения больше,\r\n чем знгачение максимально допустимого отклонения";
            }
            else
                labelConclusionGm.Text = "";
        }

        private void DrawPlot()
        {
            Bitmap b = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(b);
            List<PointF> pointsStat = new List<PointF>();
            List<PointF> pointsTheor = new List<PointF>();
            List<PointF> pointsGmaxPlus = new List<PointF>();
            List<PointF> pointsGmaxMinus = new List<PointF>();
            float minPoint = 0.5F;

            for (int i = 0; i < dataGridViewTable5.RowCount; i++)
                pointsGmaxMinus.Add(new PointF(23 + (float)Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[1].Value) * (pictureBoxPlot.Width - 46) / max, ((pictureBoxPlot.Height - 15) - (float)(Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[3].Value) - Gmax2 + Math.Abs(minPoint)) * (float)((pictureBoxPlot.Height - 25) / 1.5))));
            for (int i = 0; i < dataGridViewTable5.RowCount; i++)
                pointsGmaxPlus.Add(new PointF(23 + (float)Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[1].Value) * (pictureBoxPlot.Width - 46) / max, ((pictureBoxPlot.Height - 15) - (float)(Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[3].Value) + Gmax2 + Math.Abs(minPoint)) * (float)((pictureBoxPlot.Height - 25) / 1.5))));
            for (int i = 0; i < dataGridViewTable5.RowCount; i++)
                pointsStat.Add(new PointF(23 + (float)Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[1].Value) * (pictureBoxPlot.Width - 46) / max, ((pictureBoxPlot.Height - 15) - (float)(Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[3].Value) + Math.Abs(minPoint)) * (float)((pictureBoxPlot.Height - 25) / 1.5))));
            for (int i = 0; i < dataGridViewTable5.RowCount; i++)
                pointsTheor.Add(new PointF(23 + (float)Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[1].Value) * (pictureBoxPlot.Width - 46) / max, ((pictureBoxPlot.Height - 15) - (float)(Convert.ToDouble(dataGridViewTable5.Rows[i].Cells[8].Value) + Math.Abs(minPoint)) * (float)((pictureBoxPlot.Height - 25) / 1.5))));

            PointF[] pointsOx = {
                                 new PointF(pictureBoxPlot.Width, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5) - 1),
                                 new PointF(pictureBoxPlot.Width - 10, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5) - 4),
                                 new PointF(pictureBoxPlot.Width - 10, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5) + 4)
                             };
            Point[] pointsOy = {
                                 new Point(22, 0),
                                 new Point(19, 10),
                                 new Point(26, 10)
                             };

            g.DrawLine(new Pen(Color.Black, 2), 23, 10, 23, pictureBoxPlot.Height - 15);
            g.DrawLine(new Pen(Color.Black, 2), 23, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5), pictureBoxPlot.Width - 10, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5));
            g.FillPolygon(new SolidBrush(Color.Black), pointsOx);
            g.FillPolygon(new SolidBrush(Color.Black), pointsOy);
            g.DrawString("Pm", new Font("Times New Roman", 9.75F), new SolidBrush(Color.Black), 0, 0);
            g.DrawString("m", new Font("Times New Roman", 9.75F), new SolidBrush(Color.Black), pictureBoxPlot.Width - 12, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5));

            for (int i = 1; i <= max; i++)
            {
                g.DrawString(i.ToString(), new Font("Times New Roman", 9.75F), new SolidBrush(Color.Black), pointsStat[i].X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5) + 1);
                g.DrawLine(new Pen(Color.Black, 2), pointsStat[i].X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5), pointsStat[i].X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5) - 4);
            }

            for (int i = -5; i < 10; i++)
            {
                g.DrawString((i * 0.1).ToString(), new Font("Times New Roman", 9.75F), new SolidBrush(Color.Black), 0, (float)((pictureBoxPlot.Height - 15) - (i + 5) / 15.0 * (pictureBoxPlot.Height - 25) - 7));
                g.DrawLine(new Pen(Color.Black, 2), 23, (float)((pictureBoxPlot.Height - 15) - (i + 5) / 15.0 * (pictureBoxPlot.Height - 25)), 27, (float)((pictureBoxPlot.Height - 15) - (i + 5) / 15.0 * (pictureBoxPlot.Height - 25)));
            }

            foreach (var point in pointsStat)
            {
                g.DrawLine(new Pen(Color.Black), point, new PointF(23, point.Y));
                g.DrawLine(new Pen(Color.Black), point, new PointF(point.X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5)));
            }

            /*foreach (var point in pointsTheor)
            {
                g.DrawLine(new Pen(Color.Black), point, new PointF(23, point.Y));
                g.DrawLine(new Pen(Color.Black), point, new PointF(point.X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5)));
            }

            foreach (var point in pointsGmaxPlus)
            {
                g.DrawLine(new Pen(Color.Black), point, new PointF(23, point.Y));
                g.DrawLine(new Pen(Color.Black), point, new PointF(point.X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5)));
            }

            foreach (var point in pointsGmaxMinus)
            {
                g.DrawLine(new Pen(Color.Black), point, new PointF(23, point.Y));
                g.DrawLine(new Pen(Color.Black), point, new PointF(point.X, (float)((pictureBoxPlot.Height - 15) - (1 / 15.0 * (pictureBoxPlot.Height - 25)) * 5)));
            }*/

            g.DrawLine(new Pen(Color.Red), pictureBoxPlot.Width - 150, 10, pictureBoxPlot.Width - 130, 10);
            g.DrawString("Pm статистическая", new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), pictureBoxPlot.Width - 125, 4);

            g.DrawLine(new Pen(Color.Blue), pictureBoxPlot.Width - 150, 30, pictureBoxPlot.Width - 130, 30);
            g.DrawString("Pm теоретическая", new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), pictureBoxPlot.Width - 125, 24);

            g.DrawLine(new Pen(Color.Green), pictureBoxPlot.Width - 150, 50, pictureBoxPlot.Width - 130, 50);
            g.DrawString("±Gmax^2", new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), pictureBoxPlot.Width - 125, 44);

            g.DrawCurve(new Pen(Color.Red, 1), pointsStat.ToArray());
            foreach(var point in pointsStat)
                g.FillEllipse(new SolidBrush(Color.Red), point.X - 2, point.Y - 2, 4, 4);
            g.DrawCurve(new Pen(Color.Blue, 1), pointsTheor.ToArray());
            foreach (var point in pointsTheor)
                g.FillEllipse(new SolidBrush(Color.Blue), point.X - 2, point.Y - 2, 4, 4);
            g.DrawCurve(new Pen(Color.Green, 1), pointsGmaxPlus.ToArray());
            foreach (var point in pointsGmaxPlus)
                g.FillEllipse(new SolidBrush(Color.Green), point.X - 2, point.Y - 2, 4, 4);
            g.DrawCurve(new Pen(Color.Green, 1), pointsGmaxMinus.ToArray());
            foreach (var point in pointsGmaxMinus)
                g.FillEllipse(new SolidBrush(Color.Green), point.X - 2, point.Y - 2, 4, 4);

            pictureBoxPlot.Image = b;
            pictureBoxPlot.Refresh();
        }

        private int Factorial(int num)
        {
            int factorial = 1;
            for (int i = 1; i <= num; i++)
                factorial *= i;
            return factorial;
        }
    }
}
