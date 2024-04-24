using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        StrDisplay strDisplay = new StrDisplay();

        public Form1()
        {
            InitializeComponent();
        }

        // Number Button
        private void button0_Click(object sender, EventArgs e)
        {
            numDisplay("0");
        }
        private void button00_Click(object sender, EventArgs e)
        {
            numDisplay("00");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            numDisplay("1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            numDisplay("2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            numDisplay("3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            numDisplay("4");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            numDisplay("5");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            numDisplay("6");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            numDisplay("7");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            numDisplay("8");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            numDisplay("9");
        }

        // Dot Button
        private void buttonDot_Click(object sender, EventArgs e)
        {

        }

        // Memory Button
        private void buttonMemPlus_Click(object sender, EventArgs e)
        {

        }

        private void buttonMemMinus_Click(object sender, EventArgs e)
        {

        }

        private void buttonMemClear_Click(object sender, EventArgs e)
        {
    
        }

        // Clear Button
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display("0");
        }

        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            Display("0");
        }

        // Operation Button
        private void buttonPlus_Click(object sender, EventArgs e)
        {

        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {

        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {

        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {

        }

        // Equal Button
        private void buttonEqual_Click(object sender, EventArgs e)
        {

        }

        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            textDisplay.Text = strDisplay.Text;
        }

        // Method
        private void numConnect(string strNum)
        {
            if (strNum == "00")
            {
                if (strDisplay.Text != "0" && strDisplay.Text.Length < strDisplay.MaxLength - 1)
                {
                    strDisplay.Text += strNum;
                }
            }
            else if (strDisplay.Text.Length < strDisplay.MaxLength)
            {
                if (strDisplay.Text == "0")
                {
                    strDisplay.Text = strNum;
                }
                else
                {
                    strDisplay.Text += strNum;
                }
            }
        }
        private void numDisplay(string strNum)
        {
            numConnect(strNum);
            Display();
        }
        private void Display()
        {
            textDisplay.Text = strDisplay.Text;
        }
        private void Display(string text)
        {
            strDisplay.Text = text;
            textDisplay.Text = strDisplay.Text;
        }
        private class StrDisplay
        {
            public string Text;
            public int MaxLength;

            public StrDisplay()
            {
                this.Text = "0";
                this.MaxLength = 20;
            }
        }

    }
}
