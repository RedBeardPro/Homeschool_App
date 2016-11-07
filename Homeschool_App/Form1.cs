using System;
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

                int loopsset = rnd.Next(0, 4);
                int loopsnow = 0;

                int Answer = Problem1 + Problem2;
                Int32 [] badAnswer = new Int32[4] { 0, 0, 0, 0 };
                Int32 nowBad = Answer + rnd.Next(0, 6);

                foreach (RadioButton r in Choices.Controls)
                {
                    loopsnow = loopsnow + 1;
                    if (loopsnow == 4) { loopsnow = 0; }

                    if (loopsnow == loopsset)
                    {
                        r.Text = Answer.ToString();
                        badAnswer[loopsnow] = Convert.ToInt32(r.Text);
                    }
                    else
                    {
                        //MessageBox.Show(Answer.ToString() + Environment.NewLine + 
                        //    badAnswer[0].ToString() + Environment.NewLine +
                        //    badAnswer[1].ToString() + Environment.NewLine + 
                        //    badAnswer[2].ToString() + Environment.NewLine + 
                        //    badAnswer[3].ToString());

                        while ( nowBad == badAnswer[0] || nowBad == badAnswer[1] || nowBad == badAnswer[2] || nowBad == badAnswer[3])
                        {
                            nowBad = Answer + rnd.Next(0, 6);
                        }

                        //MessageBox.Show(Answer.ToString() + Environment.NewLine +
                        //    badAnswer[0].ToString() + Environment.NewLine +
                        //    badAnswer[1].ToString() + Environment.NewLine +
                        //    badAnswer[2].ToString() + Environment.NewLine +
                        //    badAnswer[3].ToString());
                        badAnswer[loopsnow] = nowBad;
                        r.Text = nowBad.ToString();
                    }   
                }
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
