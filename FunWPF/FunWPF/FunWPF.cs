using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunWPF
{
    public partial class FunWPF : Form
    {

        double firstNumber;
        double secondNumber;
        string operatorEntered;

        Label mathExpression = null;

        bool operatorBeenEntered = false;
        bool secondNumberTime = false;
        bool cleared = false;

        public FunWPF()
        {
            InitializeComponent();
        }

        private void FunWPF_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numberLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (cleared)
            {
                label17.Text = "";
                cleared = false;
            }

            if(operatorBeenEntered)
            {
                label17.Text = "";
                operatorBeenEntered = false;
                secondNumberTime = true;
            }

            if(clickedLabel != null)
            {

                if(mathExpression == null && label17.Text.Length < 10)
                {
                    if (label17.Text.Length == 0 && clickedLabel.Text == ".")
                    {
                        label17.Text = "0" + clickedLabel.Text;                       
                    }

                    else
                    {
                        label17.Text += clickedLabel.Text;
                    }

                    if(!secondNumberTime)
                    {
                        firstNumber = double.Parse(label17.Text);
                    }

                    else if(secondNumberTime)
                    {
                        secondNumber = double.Parse(label17.Text);
                    }

                    return;
                }

                if(mathExpression != null)
                {
                    mathExpression = null;
                    label17.Text = "";
                    return;
                }

            }
        }

        private void decimalClick(object sender, EventArgs e)
        {
            if(!label17.Text.Contains("."))
            {
                numberLabel_Click(sender, e);
            }
        }

        private void addSign_Click(object sender, EventArgs e)
        {
            if (label17.Text == "") return;
            if(label17.Text[0] == '-')
            {
                label17.Text = label17.Text.Remove(0,1);

                if(!operatorBeenEntered)
                {
                    firstNumber = double.Parse(label17.Text);
                }
                else
                {
                    secondNumber = double.Parse(label17.Text);
                }

                return;
            }
            else
            {
                label17.Text = "-" + label17.Text;

                if (!operatorBeenEntered)
                {
                    firstNumber = double.Parse(label17.Text);
                }
                else
                {
                    secondNumber = double.Parse(label17.Text);
                }

                return;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            operatorBeenEntered = true;
            Label clicked = sender as Label;

            operatorEntered = clicked.Text;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            label17.Text = "0";

            if(secondNumberTime)
            {
                secondNumber = 0;
            }
            else
            {
                firstNumber = 0;
            }

            cleared = true;
        }

        private void equals_Click(object sender, EventArgs e)
        {

            if(!secondNumberTime)
            {
                label20.Text = firstNumber.ToString();
                reset();
                return;
            }

            if (operatorBeenEntered)
            {
                reset();
                return;
            }

            double result = 0;

            if(operatorEntered == "÷")
            {
                result = firstNumber / secondNumber;
            }
            else if(operatorEntered == "×")
            {
                result = firstNumber * secondNumber;
            }
            else if(operatorEntered == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if(operatorEntered == "-")
            {
                result = firstNumber - secondNumber;
            }

            label20.Text = result.ToString();

            reset();
        }

        private void reset()
        {
            label17.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            operatorEntered = "";

            mathExpression = null;

            operatorBeenEntered = false;
            secondNumberTime = false;
            cleared = false;
        }
    }
}
