using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Helper;
using WindowsFormsApplication1.Models;
using FarPoint.Win.Spread;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public string NewValue { get { return textBox1.Text; } private set { textBox1.Text = value; } }

        public string PrintResult { get { return textBox2.Text; } private set { textBox2.Text = value; } }

        private BindingList<Item> itemBindingList;
        private List<Item> itemList;
        private BindingSource bindingSource;

        public Form4()
        {
            InitializeComponent();


            InitBindingSource();

            btnLoad.Click += new EventHandler(button1_Click);
            btnEnd.Click += new EventHandler(button2_Click);
            btnApply.Click += new EventHandler(btnApply_Click);
            btnPrint.Click += new EventHandler(btnPrint_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnDel.Click += new EventHandler(btnDel_Click);

            fpSpread1.EditChange += new EditorNotifyEventHandler(fpSpread1_EditChange);


            btnMerge.Click += new EventHandler(btnMerge_Click);
        }

        void btnMerge_Click(object sender, EventArgs e)
        {
            fpSpread1.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, 2);
        }

        void fpSpread1_EditChange(object sender, EditorNotifyEventArgs e)
        {
            var neVAlue = e.EditingControl.Text;
        }

        private void InitBindingSource()
        {
            itemBindingList = new BindingList<Item>();
            fpSpread1.DataSource = itemBindingList;

            //itemList = new List<Item>();

            //bindingSource = new BindingSource();
            //bindingSource.DataSource = itemList;

            //fpSpread1.ActiveSheet.AutoGenerateColumns = true;
            //fpSpread1.DataSource = bindingSource;

        }

        void btnDel_Click(object sender, EventArgs e)
        {
            int selectedIndex = fpSpread1.ActiveSheet.ActiveRowIndex;
            if (selectedIndex >= 0)
            {
                var item = bindingSource[selectedIndex] as Item;

                if (item != null)
                    bindingSource.Remove(item);
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            int r = new Random().Next();
            itemBindingList.Add(new Item("Code"+r, "Name"+r));
            //itemList.Add(new Item("code"+r, "name"+r));
            //bindingSource.ResetBindings(false);
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            PrintResult = string.Empty;

            var list = fpSpread1.DataSource as List<Item>;

            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine(string.Format("Id : {0}, Code :{1}, Name : {2}", item.Id, item.Code, item.Name));
            }

            PrintResult = sb.ToString();

        }

        void btnApply_Click(object sender, EventArgs e)
        {
            //int row = fpSpread1.ActiveSheet.ActiveRow.Index;
            //int col = fpSpread1.ActiveSheet.ActiveColumn.Index;
            //var list = fpSpread1.DataSource as List<Item>;
            

            //SheetView sheet = fpSpread1.ActiveSheet;

            //sheet.SetValue(row, col, NewValue);
            //var item = list.ElementAt(row);
            
            SheetView sheet = fpSpread1.ActiveSheet;

            int row = sheet.ActiveRowIndex;
            int currentCol = sheet.ActiveColumnIndex;
            int col = GetColumnIndex("Code");

            if (currentCol == col)
                return;

            
            string itemCode = GetItemCode(row, col);

            Item item = itemBindingList.FirstOrDefault(x => x.Code == itemCode);

            if (item == null) return;

            SetValue(item, GetColumnDataField(currentCol));
        }

        private string GetItemCode(int row, int col)
        {
            SheetView sheet = fpSpread1.ActiveSheet;
            return Convert.ToString(sheet.GetValue(row, col));
        }

        private string GetColumnDataField(int col)
        {
            SheetView sheet = fpSpread1.ActiveSheet;
            return sheet.Columns[col].DataField;
        }

        private int GetColumnIndex(string dataField)
        {
            SheetView sheet = fpSpread1.ActiveSheet;
            foreach (Column column in sheet.Columns)
            {
                if (string.Equals(column.DataField, dataField, StringComparison.OrdinalIgnoreCase))
                    return column.Index;
            }
            return -1;
        }

        private void SetValue(Item item, string propertyName)
        {
            PropertyInfo pi = typeof(Item).GetProperty(propertyName);

            if (pi == null) return;

            if (pi.PropertyType == typeof(int))
            {
                int i = int.TryParse(NewValue, out i) ? i : 0;
                pi.SetValue(item, i, null);
            }
            else
            {
                pi.SetValue(item, NewValue, null);
            }

            
            //typeof(Item).GetProperty(propertyName).SetValue(item, NewValue, null);
        }

        void button2_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("종료하시겠습니까", "확인", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }


        void button1_Click(object sender, EventArgs e)
        {
            LogHelper.Default.WriteLogEntry(new StateLog()
            {
                Status = "Ongoing",
                DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Message = "button clicked"
            });


            //List<Item> itemList = new List<Item>()
            //{
            //    new Item("A", "a"),
            //    new Item("B", "b"),
            //    new Item("C", "c"),
            //    new Item("D", "d"),
            //    new Item("E", "e"),
            //};

            //fpSpread1.DataSource = itemList;


        }

    }
}
