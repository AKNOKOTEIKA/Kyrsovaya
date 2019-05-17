using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace КУРСОВАЯ_08._05._19
{
    public partial class Form1 : Form
    {

        public static string s = "";
        public static int ChoiseCol = 0, ChoiseRow = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("data.txt");
            while (SR.EndOfStream == false)
            {

                dataGridView1.Rows.Add(SR.ReadLine(), SR.ReadLine(), SR.ReadLine(), SR.ReadLine(), SR.ReadLine(), SR.ReadLine());


            }




            SR.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter("Out.txt");
            string s = "";




            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                SW.WriteLine("________________________________________________________________");
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {

                    SW.Write(dataGridView1.Rows[i].Cells[j].Value + "||");
                }
                SW.WriteLine();

            }


            SW.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pass = "1";
            if (textBox1.Text == pass)
            {
                dataGridView1.ReadOnly = false;

                label1.Text = "CORRECT";
            }
            else
            {
                label1.Text = "EROR";
                dataGridView1.ReadOnly = true;
            }
            if (textBox1.Text == "")
            {
                dataGridView1.ReadOnly = true;
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            int dell = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(dell);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            textBox3.Text += "Товары с минимальной партией больше 50" + Environment.NewLine;
            int x = 0;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);

                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (((int)s[j] > 48 && (int)s[j] < 57))
                    {
                        label2.Text = "CORRECT";
                    }
                    else
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "(" + i + ",6)";

                        goto skipp;
                    }
                }

                x = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                if (x > 50)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        textBox3.Text += dataGridView1.Rows[i].Cells[j].Value + "  ";
                    }
                    textBox3.Text += Environment.NewLine;
                }
            }

        skipp:;

        }



        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            switch (ChoiseCol)
            {
                case 0:
                case0:
                    s = Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);

                    for (int j = 0; j < s.Length - 1; j++)
                    {
                        if (((int)s[j] > 65 && (int)s[j] < 90) || ((int)s[j] > 97 && (int)s[j] < 122))
                        {
                            label2.Text = "CORRECT";
                        }
                        else
                        {
                            label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                            label2.Text += "INCORECT VALUE IN: ";
                            label2.Text += Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                        }
                    }
                    break;
                case 1:
                    goto case0;
                    break;
                case 2:
                    s = Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);

                    for (int j = 0; j < s.Length - 1; j++)
                    {
                        if (((int)s[j] > 48 && (int)s[j] < 57) || (int)s[j] == 46)
                        {
                            label2.Text = "CORRECT";
                        }
                        else
                        {
                            label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                            label2.Text += "INCORECT VALUE IN: ";
                            label2.Text += Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                        }
                    }
                    break;
                case 3:
                caseint:
                    s = Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);

                    for (int j = 0; j < s.Length - 1; j++)
                    {
                        if (((int)s[j] > 48 && (int)s[j] < 57))
                        {
                            label2.Text = "CORRECT";
                        }
                        else
                        {
                            label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                            label2.Text += "INCORECT VALUE IN: ";
                            label2.Text += Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                        }
                    }
                    break;
                case 4:
                    goto caseint;
                    break;
                case 5:
                    goto caseint;
                    break;
            }




        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            int stock = Convert.ToInt32(textBox2.Text), stockNeed = 0;
            int times = 0;
            textBox3.Text += "Товары со склада (" + stock + ") : " + Environment.NewLine;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (((int)s[j] > 48 && (int)s[j] < 57))
                    {
                        label2.Text = "CORRECT";
                    }
                    else
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "(" + i + ",5)";
                        goto skipp;
                       
                    }
                }

                stockNeed = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                if (stock == stockNeed)
                {

                    textBox3.Text += (dataGridView1.Rows[i].Cells[0].Value + "  ");
                    textBox3.Text += (dataGridView1.Rows[i].Cells[3].Value + "  ");

                    textBox3.Text += Environment.NewLine;
                    times++;
                }

            }
        skipp:;
            if (times == 0)
            {
                textBox3.Text += "Отсутствуют!" + Environment.NewLine;
            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            label2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text += "Price-lise:" + Environment.NewLine;
           

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);

                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (((int)s[j] > 65 && (int)s[j] < 90) || ((int)s[j] > 97 && (int)s[j] < 122))
                    {
                        
                    }
                    else
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                        goto skipp;     
                    }
                }

                textBox3.Text += dataGridView1.Rows[i].Cells[0].Value;
                textBox3.Text += dataGridView1.Rows[i].Cells[2].Value;
                textBox3.Text += Environment.NewLine;


            skipp:;
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {

            int stock = Convert.ToInt32(textBox2.Text), stockNeed = 0;
            int times = 0;
            

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);

                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (((int)s[j] > 48 && (int)s[j] < 57))
                    {

                    }
                    else
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "(" + i + ",5)";
                        goto skipp;
                    }
                }

                



                    stockNeed = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                if (stock == stockNeed)
                {
                    textBox3.Text = "Товары со склада (" + stock + ") удалены!" + Environment.NewLine; 
                    dataGridView1.Rows.RemoveAt(i);
                    times++;
                }
           

            }

        skipp:;
        if (times == 0)
            {
                textBox3.Text += "Склад (" + stock + ") отсутствует!" + Environment.NewLine;

            }


        }



        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ActiveForm.Text = e.RowIndex + ", " + e.ColumnIndex;
            
            ChoiseCol = e.ColumnIndex;
            ChoiseRow = e.RowIndex;

        }
    }
}
