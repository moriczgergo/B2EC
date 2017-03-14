using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2EChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                byte[] file = File.ReadAllBytes(openFileDialog1.FileName);
                bool isConverted = false;
                for (var i = 0; i < file.Length; i++)
                {
                    try
                    {
                        if (file[i] == 0x42 && file[i + 1] == 0x32 && file[i + 2] == 0x45 && file[i + 3] == 0x46 && file[i + 4] == 0x52 && file[i + 5] == 0x45 && file[i + 6] == 0x45)
                        {
                            isConverted = true;
                            break;
                        }
                    } catch (Exception)
                    {

                    }
                }
                if (isConverted)
                {
                    MessageBox.Show("The author of this executable did use Batch2Exe.", "B2EC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                } else
                {
                    MessageBox.Show("The author of this executable did not use Batch2Exe.", "B2EC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
