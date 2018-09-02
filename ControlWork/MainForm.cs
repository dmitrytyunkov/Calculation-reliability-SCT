using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ControlWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBoxGroup.SelectedIndex = 0;
        }

        private void buttonWork1_Click(object sender, EventArgs e)
        {
            ControlWork.Select.SelectElectricalradioelement(comboBoxGroup.SelectedIndex);
            ControlWork.Select.SelectVariant(numericUpDownVariant.Value);
            FormWork1 formWork1 = new FormWork1();
            formWork1.ShowDialog();
        }

        private void buttonWork2_Click(object sender, EventArgs e)
        {
            ControlWork.Select.SelectElectricalradioelement(comboBoxGroup.SelectedIndex);
            ControlWork.Select.SelectVariant(numericUpDownVariant.Value);
            FormWork2 formWork2 = new FormWork2();
            formWork2.ShowDialog();
        }
    }
}
