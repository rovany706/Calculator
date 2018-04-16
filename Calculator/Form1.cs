using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked)
            {
                switch (button.Name)
                {
                    case "RussiaRadioButton":
                        dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
                        dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm:ss";
                        dateTimePicker3.CustomFormat = "dd.MM.yyyy HH:mm:ss";
                        break;
                    case "USARadioButton":
                        dateTimePicker1.CustomFormat = "MM.dd.yyyy HH:mm:ss";
                        dateTimePicker2.CustomFormat = "MM.dd.yyyy HH:mm:ss";
                        dateTimePicker3.CustomFormat = "MM.dd.yyyy HH:mm:ss";
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Calc.DateСalculation (dateTimePicker3.Value, textBox1.Text, textBox2.Text, radioButton1.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Calc.DistanceBetweenDates(dateTimePicker1.Value, dateTimePicker2.Value);
        }
    }
}
