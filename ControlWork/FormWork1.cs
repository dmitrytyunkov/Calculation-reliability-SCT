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
    public partial class FormWork1 : Form
    {
        List<Label> labelsN;
        List<Label> labelsLambdaEl;
        List<Label> labelsLambda;
        List<ComboBox> comboBoxsElement;
        List<NumericUpDown> numericUpDownsNumbersElement;
        List<Button> buttonsDelete;
        List<GroupBox> groupBoxsRow;

        int i;
        double resLambda;
        List<float> PT;

        List<Electricalradioelement> elements;
        List<string> titleElement;

        public FormWork1()
        {
            labelsN = new List<Label>();
            labelsLambdaEl = new List<Label>();
            labelsLambda = new List<Label>();
            comboBoxsElement = new List<ComboBox>();
            numericUpDownsNumbersElement = new List<NumericUpDown>();
            buttonsDelete = new List<Button>();
            groupBoxsRow = new List<GroupBox>();

            PT = new List<float>();
            i = 0;
            resLambda = 0;

            titleElement = new List<string>();
            elements = ControlWork.Select.GetElectricalradioelement();
            foreach (Electricalradioelement element in elements)
            {
                titleElement.Add(element.GetTitle());
            }

            InitializeComponent();

            comboBoxElement.Items.AddRange(titleElement.ToArray());
            comboBoxElement.SelectedIndex = 0;
            dataGridViewTable1.Rows.RemoveAt(0);

            UpdateLabels(groupBoxRow);
            labelLambda_TextChanged(labelLambda, EventArgs.Empty);
            UpdateTable1(groupBoxRow, "add", 0);
        }

        private void buttonAddRaw_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                AddNewElement(groupBoxRow);
            }
            else
            {
                AddNewElement(groupBoxsRow[i - 1]);
            }
            labelLambda_TextChanged(labelLambda, EventArgs.Empty);
            UpdateTable1(groupBoxsRow[i], "add", 0);
            i++;
        }

        private void numericUpDownNumbersElement_ValueChanged(object sender, EventArgs e)
        {
            UpdateLabels(groupBoxRow);
            UpdateTable1(groupBoxRow, "upd", 0);
        }

        private void comboBoxElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels(groupBoxRow);
            UpdateTable1(groupBoxRow, "upd", 0);
        }

        private void comboBoxsElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox send = (ComboBox)sender;
            int i;
            for (i = 0; i < comboBoxsElement.Count; i++)
                if (send.Equals(comboBoxsElement[i]))
                    break;
            
            UpdateLabels(groupBoxsRow[i]);
            UpdateTable1(groupBoxsRow[i], "upd", i + 1);
        }

        private void numericUpDownsNumbersElement_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown send = (NumericUpDown)sender;
            int i;
            for (i = 0; i < numericUpDownsNumbersElement.Count; i++)
                if (send.Equals(numericUpDownsNumbersElement[i]))
                    break;

            UpdateLabels(groupBoxsRow[i]);
            UpdateTable1(groupBoxsRow[i], "upd", i + 1);
        }

        private void labelLambda_TextChanged(object sender, EventArgs e)
        {
            PT = new List<float>();
            double sum = Convert.ToDouble(labelLambda.Text.Replace(" * 10^-6",""));
            foreach (var label in labelsLambda)
            {
                sum += Convert.ToDouble(label.Text.Replace(" * 10^-6", ""));
            }
            resLambda = sum * ControlWork.Select.GetVariantNumber();
            labelResultLamda.Text = "Для изделия: Λ = " + resLambda + " * 10^-6";
            labelBlockLamda.Text = "Для блока: Λ = " + sum + " * 10^-6";

            dataGridViewTable2.Rows.Clear();
            object[] row = new object[7];
            row[0] = "P(T)";
            for (int i = 1; i < 7; i++)
            {
                PT.Add((float)(Math.Exp(-(resLambda * Math.Pow(10, -6)) * (i * 500))));
                row[i] = Math.Round(PT[i - 1], 3);
            }
            dataGridViewTable2.Rows.Add(row);

            DrawPlot();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Button send = (Button)sender;
            int i;
            for (i = 0; i < buttonsDelete.Count; i++)
                if (send.Equals(buttonsDelete[i]))
                    break;

            Controls.Remove(groupBoxsRow[i]);
            groupBoxsRow.RemoveAt(i);
            labelsLambda.RemoveAt(i);
            labelsLambdaEl.RemoveAt(i);
            labelsN.RemoveAt(i);
            buttonsDelete.RemoveAt(i);
            comboBoxsElement.RemoveAt(i);
            numericUpDownsNumbersElement.RemoveAt(i);
            this.i--;

            for (int j = i; j < groupBoxsRow.Count; j++ )
                groupBoxsRow[j].Location = new Point(12, groupBoxsRow[j].Location.Y - groupBoxsRow[j].Height - 6);
            buttonAddRaw.Location = new Point(12, buttonAddRaw.Location.Y - groupBoxRow.Height - 6);
            dataGridViewTable1.Location = new Point(12, dataGridViewTable1.Location.Y - groupBoxRow.Height - 6);
            labelResultLamda.Location = new Point(labelResultLamda.Location.X, labelResultLamda.Location.Y - groupBoxRow.Height - 6);
            labelBlockLamda.Location = new Point(12, labelBlockLamda.Location.Y - groupBoxRow.Height - 6);
            dataGridViewTable2.Location = new Point(12, dataGridViewTable2.Location.Y - groupBoxRow.Height - 6);
            pictureBoxPlot.Location = new Point(12, pictureBoxPlot.Location.Y - groupBoxRow.Height - 6);
            labelConclusion.Location = new Point(12, labelConclusion.Location.Y - groupBoxRow.Height - 6);

            
            if (dataGridViewTable1.Rows.Count > i + 1)
                dataGridViewTable1.Rows.RemoveAt(i + 1);
            
            for (int j = 0; j < labelsN.Count; j++)
            {
                labelsN[j].Text = (j + 2).ToString();
                dataGridViewTable1.Rows[j + 1].Cells[0].Value = labelsN[j].Text;
            }

            labelLambda_TextChanged(labelLambda, EventArgs.Empty);
        }
        // обрезает и меняет размер изображения когда не надо
        private void FormWork1_Resize(object sender, EventArgs e)
        {
            //DrawPlot();
            //labelConclusion.Location = new Point(12, pictureBoxPlot.Location.Y + pictureBoxPlot.Height + 3);
        }

        private void DrawPlot()
        {
            Bitmap b = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(b);
            List<PointF> tempPoints = new List<PointF>();
            for (int i = 1; i < dataGridViewTable2.Rows[0].Cells.Count; i++)
            {
                tempPoints.Add(new PointF(26 + i * 500 * (pictureBoxPlot.Width - 52) / 3000, (float)((pictureBoxPlot.Height - 15) - Convert.ToDouble(dataGridViewTable2.Rows[0].Cells[i].Value) * (pictureBoxPlot.Height - 25))));
            }
            
            PointF[] points = tempPoints.ToArray();
            Point[] pointsOx = {
                                 new Point(pictureBoxPlot.Width, pictureBoxPlot.Height - 14),
                                 new Point(pictureBoxPlot.Width - 10, pictureBoxPlot.Height - 11),
                                 new Point(pictureBoxPlot.Width - 10, pictureBoxPlot.Height - 18)
                             };
            Point[] pointsOy = {
                                 new Point(25, 0),
                                 new Point(22, 10),
                                 new Point(29, 10)
                             };

            g.DrawLine(new Pen(Color.Black, 2), 26, 10, 26, pictureBoxPlot.Height - 15);
            g.DrawLine(new Pen(Color.Black, 2), 26, pictureBoxPlot.Height - 15, pictureBoxPlot.Width - 10, pictureBoxPlot.Height - 15);
            g.FillPolygon(new SolidBrush(Color.Black), pointsOx);
            g.FillPolygon(new SolidBrush(Color.Black), pointsOy);
            g.DrawString("P(T)", new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), 0, 0);
            g.DrawString("T", new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), pictureBoxPlot.Width - 12, pictureBoxPlot.Height - 12);

            for (int i = 0; i < 6; i++)
            {
                g.DrawString((500 + i * 500).ToString(), new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), points[i].X - 16, pictureBoxPlot.Height - 14);
                g.DrawLine(new Pen(Color.Black, 2), points[i].X, pictureBoxPlot.Height - 15, points[i].X, pictureBoxPlot.Height - 19);
            }

            for (int i = 0; i < 10; i++)
            {
                g.DrawString((i * 0.1).ToString(), new Font("Times New Roman", (float)9.75), new SolidBrush(Color.Black), 0, (float)((pictureBoxPlot.Height - 15) - i / 10.0 * (pictureBoxPlot.Height - 25) - 7));
                g.DrawLine(new Pen(Color.Black, 2), 26, (float)((pictureBoxPlot.Height - 15) - i / 10.0 * (pictureBoxPlot.Height - 25)), 30, (float)((pictureBoxPlot.Height - 15) - i / 10.0 * (pictureBoxPlot.Height - 25)));
            }

            foreach (var point in points)
            {
                g.DrawLine(new Pen(Color.Black), point, new PointF(26, point.Y));
                g.DrawLine(new Pen(Color.Black), point, new PointF(point.X, pictureBoxPlot.Height - 15));
            }

            g.DrawCurve(new Pen(Color.Red, 1), points);
            foreach (var point in points)
                g.FillEllipse(new SolidBrush(Color.Red), point.X - 2, point.Y - 2, 4, 4);

            pictureBoxPlot.Image = b;
            pictureBoxPlot.Refresh();
        }

        private void AddNewElement(GroupBox prevGroupBox)
        {
            GroupBox groupBox = new GroupBox
            {
                Parent = this,
                Width = groupBoxRow.Width,
                Height = groupBoxRow.Height,
                Visible = true
            };
            groupBox.Location = new Point(12, prevGroupBox.Location.Y + prevGroupBox.Height + 6);

            ComboBox comboBox = new ComboBox
            {
                Parent = groupBox,
                Width = comboBoxElement.Width,
                Height = comboBoxElement.Height,
                Font = new System.Drawing.Font("Times New Roman", (float)9.75),
                Visible = true
            };
            comboBox.Location = new Point(prevGroupBox.Controls[2].Location.X, prevGroupBox.Controls[2].Location.Y);
            comboBox.Items.AddRange(titleElement.ToArray());
            comboBox.SelectedIndex = 0;
            comboBox.SelectedIndexChanged += comboBoxsElement_SelectedIndexChanged;

            NumericUpDown numericUpDown = new NumericUpDown
            {
                Parent = groupBox,
                Width = numericUpDownNumbersElement.Width,
                Height = numericUpDownNumbersElement.Height,
                Font = new System.Drawing.Font("Times New Roman", (float)9.75),
                Visible = true
            };
            numericUpDown.Location = new Point(prevGroupBox.Controls[4].Location.X, prevGroupBox.Controls[4].Location.Y);
            numericUpDown.Maximum = 1000000;
            numericUpDown.Minimum = 1;
            numericUpDown.ValueChanged += numericUpDownsNumbersElement_ValueChanged;

            Label label1 = new Label
            {
                Parent = groupBox,
                Text = (i + 2).ToString(),
                Font = new System.Drawing.Font("Times New Roman", (float)9.75),
                AutoSize = true,
                Visible = true
            };
            label1.Location = new Point(labelN.Location.X, labelN.Location.Y);

            Label label2 = new Label
            {
                Parent = groupBox,
                Text = "",
                Font = new System.Drawing.Font("Times New Roman", (float)9.75),
                AutoSize = true,
                Visible = true
            };
            label2.Location = new Point(prevGroupBox.Controls[3].Location.X, prevGroupBox.Controls[3].Location.Y);

            Label label3 = new Label
            {
                Parent = groupBox,
                Text = "",
                Font = new System.Drawing.Font("Times New Roman", (float)9.75),
                AutoSize = true,
                Visible = true
            };
            label3.Location = new Point(prevGroupBox.Controls[1].Location.X, prevGroupBox.Controls[1].Location.Y);

            Button button = new Button
            {
                Parent = groupBox,
                Text = "Удалить",
                Font = new System.Drawing.Font("Times New Roman", (float)9.75),
                Visible = true
            };
            button.Location = new Point(prevGroupBox.Controls[1].Location.X + prevGroupBox.Controls[1].Width + 12, 18);
            button.Click += buttonDelete_Click;

            groupBox.Controls.Add(label1);
            groupBox.Controls.Add(label3);
            groupBox.Controls.Add(comboBox);
            groupBox.Controls.Add(label2);
            groupBox.Controls.Add(numericUpDown);
            groupBox.Controls.Add(button);
            Controls.Add(groupBox);

            UpdateLabels(groupBox);
            label3.TextChanged += labelLambda_TextChanged;

            comboBoxsElement.Add(comboBox);
            numericUpDownsNumbersElement.Add(numericUpDown);
            labelsN.Add(label1);
            labelsLambdaEl.Add(label2);
            labelsLambda.Add(label3);
            buttonsDelete.Add(button);
            groupBoxsRow.Add(groupBox);
            
            buttonAddRaw.Location = new Point(12, groupBox.Location.Y + groupBox.Height + 6);
            dataGridViewTable1.Location = new Point(12, buttonAddRaw.Location.Y + buttonAddRaw.Height + 6);
            labelResultLamda.Location = new Point(labelResultLamda.Location.X, dataGridViewTable1.Location.Y + dataGridViewTable1.Height + 3);
            labelBlockLamda.Location = new Point(12, dataGridViewTable1.Location.Y + dataGridViewTable1.Height + 3);
            dataGridViewTable2.Location = new Point(12, labelResultLamda.Location.Y + labelResultLamda.Height + 3);
            pictureBoxPlot.Location = new Point(12, dataGridViewTable2.Location.Y + dataGridViewTable2.Height + 6);
            labelConclusion.Location = new Point(12, pictureBoxPlot.Location.Y + pictureBoxPlot.Height + 3);
        }

        private void UpdateLabels(GroupBox groupBox)
        {
            ComboBox comboBox = (ComboBox)groupBox.Controls[2];
            Label labelLambdaEl = (Label)groupBox.Controls[3];
            NumericUpDown numericUpDown = (NumericUpDown)groupBox.Controls[4];
            Label labelLambda = (Label)groupBox.Controls[1];
            labelLambdaEl.Text = Math.Round(elements[comboBox.SelectedIndex].GetLambda(), 3).ToString() + " * 10^-6";
            labelLambda.Text = Math.Round(Convert.ToDouble(labelLambdaEl.Text.Replace(" * 10^-6", "")) * Convert.ToInt32(numericUpDown.Value), 3).ToString() + " * 10^-6";
        }

        private void UpdateTable1(GroupBox groupBox, string type, int pos)
        {
            Label labelN = (Label)groupBox.Controls[0];
            ComboBox comboBoxElement = (ComboBox)groupBox.Controls[2];
            NumericUpDown numericUpDownNumbersElement = (NumericUpDown)groupBox.Controls[4];
            Label labelLambdaEl = (Label)groupBox.Controls[3];
            Label labelLambda = (Label)groupBox.Controls[1];

            object[] row = new object[5];
            row[0] = labelN.Text;
            row[1] = comboBoxElement.SelectedItem.ToString();
            row[2] = numericUpDownNumbersElement.Value;
            row[3] = labelLambdaEl.Text;
            row[4] = labelLambda.Text;

            switch (type)
            {
                case "add":
                    dataGridViewTable1.Rows.Add(row);
                    break;
                case "upd":
                    if (dataGridViewTable1.Rows.Count > pos)
                        dataGridViewTable1.Rows.RemoveAt(pos);
                    dataGridViewTable1.Rows.Insert(pos, row);
                    break;
            }
        }
    }
}
