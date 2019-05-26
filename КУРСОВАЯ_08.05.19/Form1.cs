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
        //Вывод справки о программе
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
                Help.ShowHelp(this, "file://D:\\Manual\\info.chm");            
        }

        //Считывание данных для формирования базы
        private void button1_Click(object sender, EventArgs e)
        {
            stock[] st = new stock[50];                      
            //openfiledialog//
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader SR = new StreamReader(openFileDialog1.FileName);
                int i = 0;
                while (SR.EndOfStream == false)
                {
                    //dataGridView1.Rows.Add(SR.ReadLine(), SR.ReadLine(), SR.ReadLine(), SR.ReadLine(), SR.ReadLine(), SR.ReadLine());
                    st[i].name = SR.ReadLine();
                    st[i].company = SR.ReadLine();
                    st[i].costforone = Convert.ToInt32(SR.ReadLine());
                    st[i].number = Convert.ToInt32(SR.ReadLine());
                    st[i].numberofstock = Convert.ToInt32(SR.ReadLine());
                    st[i].minpartia = Convert.ToInt32(SR.ReadLine());
                    dataGridView1.Rows.Add(st[i].name, st[i].company, st[i].costforone, st[i].number, st[i].numberofstock, st[i].minpartia);
                    i++;
                }
                SR.Close();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "OUT.txt";
            sfd.DefaultExt = "txt";
            sfd.Filter = "txt filer (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                StreamWriter SW = new StreamWriter(fileStream);
                for (int i = 0; i < dataGridView1.RowCount - 2; i++)
                {
                    SW.WriteLine("______________________________________________________________________");
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {

                        SW.Write(dataGridView1.Rows[i].Cells[j].Value + "|| ");
                    }
                    SW.WriteLine();

                }
                SW.Close();
                fileStream.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pass = "123qwE";
            if (textBox1.Text == pass)
            {
                dataGridView1.ReadOnly = false;

                label1.Text = "CORRECT PASSWORD";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button8.Enabled = true;
                button7.Enabled = true;
                button10.Enabled = true;
                button6.Enabled = true;
                button5.Enabled = true;
                textBox2.Enabled = true;
                button9.Enabled = true;
                
            }
            else
            {
                label1.Text = "EROR.INCORRECT PASS";
              
                dataGridView1.ReadOnly = true;
                 button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button8.Enabled = false;
                button7.Enabled = false;
                button10.Enabled = false;
                button6.Enabled = false;
                button5.Enabled = false;
                textBox2.Enabled = false;
                button9.Enabled = false;
            }
            if (textBox1.Text == "")
            {
                dataGridView1.ReadOnly = true;
            }
          


        }

        private void button8_Click(object sender, EventArgs e)
        {
            int dell = 1;
            label2.Text = "";
            if ((dataGridView1.SelectedCells[0].RowIndex < 0) || (dataGridView1.SelectedCells[0].RowIndex >= dataGridView1.RowCount-1))
            {
                label2.Text += "EROR!Don`t have this row." + Environment.NewLine;
            }
            else
            {
                dell = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(dell);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            textBox3.Text += "Товары с минимальной партией больше 50" + Environment.NewLine;
            int x = 0;
            stock y = new stock();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                
                if (y.ChekINT(s) == false)
                {
                    label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                    label2.Text += "INCORECT VALUE IN: ";
                    label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) + "(" + i + ",6)";

                    goto skipp;

                }
                else
                {
                    label2.Text = "CORRECT";
                }

                x = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                if (x >= 50)
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
            stock x = new stock();
            switch (ChoiseCol)
            {
                case 0:
                case0:
                    s = Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                    if (x.ChekSTR(s) == false)
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                    }
                    else {
                        label2.Text = "CORRECT";
                    }                    
                    break;
                case 1:
                    goto case0;
                    
                case 2:
                    goto caseint;                  
                case 3:
                caseint:
                    s = Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                    if (x.ChekINT(s) == false)
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[ChoiseRow].Cells[ChoiseCol].Value);
                    }
                    else
                    {
                        label2.Text = "CORRECT";
                    }
                    break;
                case 4:
                    goto caseint;
                    
                case 5:
                    goto caseint;
                    
            }




        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            int times = 0;
            stock x = new stock();
            int stock = 0, stockNeed = 0;
            if (x.ChekINT(textBox2.Text) == false)
            {
                textBox3.Text += "Введите номер склада коррекстно" + Environment.NewLine;
                goto skippStock;
            }
            else
            {
                stock = Convert.ToInt32(textBox2.Text);
            }




            
            
            textBox3.Text += "_____Товары со склада (" + stock + ") :" + Environment.NewLine;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                if (x.ChekINT(s) == false)
                {
                    label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                    label2.Text += "INCORECT VALUE IN: ";
                    label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "(" + i + ",5)";
                    goto skipp;
                }else
                {
                    label2.Text = "CORRECT";
                }            
                stockNeed = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                if (stock == stockNeed)
                {

                    textBox3.Text += (dataGridView1.Rows[i].Cells[0].Value + "  ");
                    textBox3.Text += (dataGridView1.Rows[i].Cells[3].Value + "  ");

                    textBox3.Text += Environment.NewLine;
                    times++;
                }
            skipp:;
            }
            
            if (times == 0)
            {
                textBox3.Text += "Отсутствуют!" + Environment.NewLine;
            }
            skippStock:;


        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            label2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            textBox3.Text += "_____PRISE-LIST:" + Environment.NewLine;
           

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                stock y = new stock();                
                if (y.ChekSTR(s) == false)
                {
                    label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                    label2.Text += "INCORECT VALUE IN: ";
                    label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    goto skipp;
                }
                else
                {

                }

                textBox3.Text += dataGridView1.Rows[i].Cells[0].Value;
                textBox3.Text += " - ";
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
            int times = 0;
            stock x = new stock();
            int stock=0, stockNeed = 0;
            if (x.ChekINT(textBox2.Text) == false)
            {
                textBox3.Text += "Введите номер склада коррекстно" + Environment.NewLine;
                goto skippstock;
            }
            else
            {
                stock = Convert.ToInt32(textBox2.Text);
            }
            

            for (int i = 0; i < dataGridView1.RowCount-1 ; i++)
            {
                s = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                                  
                    if ( x.ChekINT(s) == false)
                    {
                        label2.Text = "EROR.INCORECT VALUE.TRY AGAIN!! ";
                        label2.Text += "INCORECT VALUE IN: ";
                        label2.Text += Convert.ToString(dataGridView1.Rows[i].Cells[4].Value) + "(" + i + ",5)";
                        goto skipp;
                    }
                    else
                    {

                    }
                
                
                stockNeed = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                if (stock == stockNeed)
                {
                    dataGridView1.Rows.RemoveAt(i);                                        
                    times++;
                    i = -1;
                }
               
            }

        skipp:;
       

        skippstock:;
            if (times == 0)
            {
                textBox3.Text += "_____Склад (" + stock + ") отсутствует!" + Environment.NewLine;

            }
            else if (times > 0)
            {

                textBox3.Text += "_____Товары со склада (" + stock + ") удалены!" + Environment.NewLine;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.SelectionStart = textBox3.TextLength;
            textBox3.ScrollToCaret();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 72)
            {
                Help.ShowHelp(this, "file://D:\\Manual\\info.chm");
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
