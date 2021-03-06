﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homeschool_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newProblem_Click(object sender, EventArgs e)
        {
            foreach (RadioButton r in Choices.Controls)
            {
                r.Checked = false;
            }

            if (Convert.ToInt16(numericUpDown1.Value) < Convert.ToInt16(numericUpDown2.Value + 1))
            {
                Int16 LowVal = Convert.ToInt16(numericUpDown1.Value);
                Int16 HighVal = Convert.ToInt16(numericUpDown2.Value + 1);

                Random rnd = new Random();
                int Problem1 = rnd.Next(LowVal, HighVal);
                int Problem2 = rnd.Next(LowVal, HighVal);

                Problem_Num1.Text = Problem1.ToString();
                Problem_Num2.Text = Problem2.ToString();

                Answer_Number.Text = "?";

                int Answer = Problem1 + Problem2;
                Int32 [] badAnswer = new Int32[4] { 0, 0, 0, 0 };

                badAnswer[0] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6);
                badAnswer[1] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6);
                badAnswer[2] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6);
                badAnswer[3] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6);

                while (badAnswer[0] == badAnswer[1] || badAnswer[0] == badAnswer[2] || badAnswer[0] == badAnswer[3] || badAnswer[0] == Answer)
                { badAnswer[0] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6); }
                while (badAnswer[1] == badAnswer[0] || badAnswer[1] == badAnswer[2] || badAnswer[1] == badAnswer[3] || badAnswer[1] == Answer)
                { badAnswer[1] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6); }
                while (badAnswer[2] == badAnswer[1] || badAnswer[2] == badAnswer[0] || badAnswer[2] == badAnswer[3] || badAnswer[2] == Answer)
                { badAnswer[2] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6); }
                while (badAnswer[3] == badAnswer[1] || badAnswer[3] == badAnswer[2] || badAnswer[3] == badAnswer[0] || badAnswer[3] == Answer)
                { badAnswer[3] = Answer + rnd.Next(1, 6) - rnd.Next(1, 6); }

                int loopsset = rnd.Next(0, 4);
                int loopsnow = 0;

                foreach (Int32 bad in badAnswer)
                {
                    if (loopsnow == loopsset)
                    {
                     badAnswer[loopsnow] = Answer;
                    }
                    loopsnow = loopsnow + 1;
                }

                Choices_Choice1.Text = badAnswer[0].ToString();
                Choices_Choice2.Text = badAnswer[1].ToString();
                Choices_Choice3.Text = badAnswer[2].ToString();
                Choices_Choice4.Text = badAnswer[3].ToString();

            }
            else
            {
                MessageBox.Show("Low value must be lower than High Value");
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 1;
            }
        }

        private void submitAnswer_Click(object sender, EventArgs e)
        {
            foreach (RadioButton r in Choices.Controls)
            {
                if (r.Checked)
                    Answer_Number.Text = r.Text;
            }

            if (Convert.ToInt16(Answer_Number.Text) != Convert.ToInt16(Problem_Num1.Text) + Convert.ToInt16(Problem_Num2.Text))
            {
                Answer_Number.ForeColor = System.Drawing.Color.Red;
                Message_Text.Text = "Try Again!";
            }
            else
            {
                Answer_Number.ForeColor = System.Drawing.Color.Green;
                Message_Text.Text = "That's Correct!";
            }



        }
    }
}
