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

namespace FileTest3
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void SaveFile()
        {
            string name = tbName.Text;
            int nKor = int.Parse(tbKor.Text);
            int nMath = int.Parse(tbMath.Text);

            StreamWriter sw = new StreamWriter("data.txt");

            sw.WriteLine(name);
            sw.WriteLine(nKor);
            sw.WriteLine(nMath);

            sw.Close();

            PrintResult(tbName.Text, tbKor.Text, tbMath.Text);
        }

        public void PrintResult(string name, string kor, string math)
        {
            txtResult.Text = "";
            txtResult.Text += "이름 : " + name + "\n";
            txtResult.Text += "국어 : " + kor + "\n";
            txtResult.Text += "수학 : " + math + "\n";

            txtResult.Text += "=====================\n";
        }

        public void LoadFile()
        {
            if (!File.Exists("data.txt"))
                return;

            try
            {
                StreamReader sr = new StreamReader("data.txt");

                string sName = sr.ReadLine();
                string sKor = sr.ReadLine();
                string sMath = sr.ReadLine();

                sr.Close();

                tbName.Text = sName;
                tbKor.Text = sKor;
                tbMath.Text = sMath;

                PrintResult(sName, sKor, sMath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Clear()
        {
            txtResult.Text = "";

            tbName.Text = "";
            tbKor.Text = "";
            tbMath.Text = "";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Clear();
            LoadFile();
        }
    }
}
