using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhoneBook
{
    public partial class Form1 : Form
    {
        PhoneBook myphoneBook;
        public Form1()
        {
            InitializeComponent();
            myphoneBook = new PhoneBook();
            
        }

        private void textViewBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myphoneBook.AddPhone(nameTextBox.Text, phoneTextBox.Text, schoolTestBox.Text);
            textViewBox.Text = myphoneBook.ListUpAll();

        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            //myphoneBook.ReadCSVFile(@"C:\\Users\\asw411\\source\\repos\\MyPhoneBook\\MyPhoneBook\\phonebook.csv",true);

            openFileDialog1.ShowDialog();
            string fname = openFileDialog1.FileName;
            myphoneBook.ReadCSVFile(fname,true);

            textViewBox.Text = myphoneBook.ListUpAll();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            List<string> result;

            if (myphoneBook.FindNameByNumber(findTextBox.Text, out result))
            {
                resultTextBox.Clear();
                foreach (string s in result)
                {
                    resultTextBox.Text += (s + "\r\n");
                }
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
