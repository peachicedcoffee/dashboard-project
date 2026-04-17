using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string LastUpdatedString { get { return label1.Text; } private set { label1.Text = value; } }


        public Form1()
        {
            InitializeComponent();

            AddEvents();

            InitData();
            InitCombobox();
        }



        #region event handlers

        void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        #endregion



        #region private methods

        private void AddEvents()
        {
            this.Load += new EventHandler(Form1_Load);
            btnLoad.Click += new EventHandler(btnLoad_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnShow.Click += new EventHandler(btnShow_Click);
        }

        void btnShow_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Form1 : show dialog starting");

            Form2 form = new Form2();

            Console.WriteLine("Form1 : form2 created");

            form.DoPublicMethod();

            Console.WriteLine("Form1 : show dialog ended");
        }

        private void InitData()
        {
            List<TestData> myData = new List<TestData>()
            {
                new TestData(1,"A"),
                new TestData(2,"B"),
                new TestData(3,"C"),
                new TestData(4,"D"),
                new TestData(5,"E"),
                new TestData(6,"F"),
            };

            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Id", typeof(int));

            foreach (TestData t in myData)
            {
                DataRow row = dt.NewRow();
                row["Text"] = t.Text;
                row["Id"] = t.Id;
                dt.Rows.Add(row);
            }
            fpSpread1.Sheets[0].ColumnHeader.Cells[0, 0].Text = "Test String";
            fpSpread1.Sheets[0].ColumnHeader.Cells[0, 1].Text = "Test Int";
            fpSpread1.Sheets[0].DataSource = dt;
        }

        private void InitCombobox()
        {
            comboBox1.MaxDropDownItems = 3;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            List<TestData> myData = new List<TestData>()
            {
                new TestData(1,"A"),
                new TestData(2,"B"),
                new TestData(3,"C"),
                new TestData(4,"D"),
                new TestData(5,"E"),
                new TestData(6,"F"),
            };

            foreach (TestData d in myData)
            {
                comboBox1.Items.Add(d);
            }
        }

        private void LoadSettings()
        {
            LastUpdatedString = Settings1.Default.LastUpdateTime;
        }

        private void SaveSettings()
        {
            Settings1.Default.LastUpdateTime = DateTime.Now.ToLongTimeString();
            Settings1.Default.Save();
        }

        #endregion

    }
}
