using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            Load += new EventHandler(Form2_Load);
            button2.Click += new EventHandler(button2_Click);
            button1.Click += new EventHandler(button1_Click);
            fpSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(fpSpread1_ButtonClicked);
            fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellClick);
            StringConcatTest();
        }

        void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int maxCount = r.Next(1, 30);

            List<string> dataSource = new List<string>();
            for (int i = 0; i < maxCount; i++)
            {
                dataSource.Add(r.Next().ToString());
            }
           
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(dataSource.ToArray());
        }

        void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
        }

        void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            FpSpread spread = sender as FpSpread;
            if (spread == null) return;
            if (e.Column == 2) return;

            Console.WriteLine("cell click triggered");
        }

        void fpSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            Console.WriteLine("button click triggered");
            //e.EditingControl.Text = "test";
        }

        public void DoPublicMethod()
        {
            Console.WriteLine("Form2 : public method calling");
            ShowDialog();

        }

        void Form2_Load(object sender, EventArgs e)
        {
            List<TestData> myData = new List<TestData>()
            {
                new TestData(1,"a"),
                new TestData(2,"b"),
                new TestData(3,"c"),
                new TestData(4,"d"),
                new TestData(5,"e"),
            };

            fpSpread1.DataSource = myData;
            fpSpread1.ActiveSheet.Columns[2].CellType = new ButtonCellType() { Text = "check", TextDown = "selected" };
          // fpSpread1.ActiveSheet.Cells[0, 1].Text= "test";

        }


        private void StringConcatTest()
        {
            string lot1 = "Lot1";
            string lot2 = "Lot2";
            string lot3 = "Lot3";

            string union = string.Concat("▩", string.Join("▩", new string[] { lot1, lot2, lot3 }));
        }
    }
}
