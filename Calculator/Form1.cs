using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string op = ""; // + or - or * or / or =
        string mem1 = "0";
        string mem2 = "0";
        string opMem = "";
        bool errorflag = false;
        StrDisplay strDisplay = new StrDisplay();

        public Form1()
        {
            InitializeComponent();
        }

        // Number Button
        private void button0_Click(object sender, EventArgs e)
        {
            numButton("0");
        }
        private void button00_Click(object sender, EventArgs e)
        {
            numButton("00");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            numButton("1");
        }
        private void button2_Click(object sender, EventArgs e)
        {   
            numButton("2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            numButton("3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            numButton("4");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            numButton("5");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            numButton("6");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            numButton("7");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            numButton("8");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            numButton("9");
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
            if (errorflag)
            {
                errorflag = false;
                op = "";
            }
            Display("0");
        }

        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            errorflag = false;
            Display("0");
            mem1 = "0";
            op = "";
        }

        // Operation Button
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            opButton(sender, e);
            op = "+";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            opButton(sender, e);
            op = "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            opButton(sender, e);
            op = "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            opButton(sender, e);
            op = "/";
        }

        // Equal Button
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (!errorflag)
            {
                if (op != "")
                {
                    if (op == "=") // Equalを押した直後
                    {
                        op = opMem;
                    }
                    else
                    {
                        opMem = op;
                        mem2 = strDisplay.Text;
                    }
                    decimal result = Calculate(mem1, mem2);
                    if (!errorflag)
                    {
                        string strResult = result.ToString();
                        Display(strResult);
                        mem1 = strResult;
                        strDisplay.Text = "0";
                        op = "=";
                    }
                }
            }
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
        private void numButton(string strNum)
        {
            if (!errorflag)
            {
                numDisplay(strNum);
                if (op == "=")
                {
                    op = "";
                    mem1 = "0";
                    mem2 = "0";
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

        private void opButton(object sender, EventArgs e)
        {
            if (op == "")
            {
                mem1 = strDisplay.Text;
                strDisplay.Text = "0";
            }
            else if (op == "=")
            {
                strDisplay.Text = "0";
            }
            else
            {
                buttonEqual_Click(sender, e);
            }
        }
        private decimal Calculate(string strNum1, string strNum2)
        {   
            decimal num1 = decimal.Parse(strNum1);
            decimal num2 = decimal.Parse(strNum2);
            decimal result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2; 
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        errorRaise("Error (divided by 0)");
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
        private void errorRaise(string text)
        {
            Display(text);
            errorflag = true;
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
