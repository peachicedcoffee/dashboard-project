using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ParsingMethod();
            this.Load += new EventHandler(Form3_Load);
            button1.Click += new EventHandler(button1_Click);
        }

        void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button clicked");
        }

        void Form3_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void ParsingMethod()
        {
            string text = "100";
            int n = int.TryParse(text, out n) ? n : -1;
            bool worker = (0 < n) ? true : false;
        }

    }
}
