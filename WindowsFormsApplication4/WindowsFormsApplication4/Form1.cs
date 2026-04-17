using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public List<ServerInfo> serverList;
        public BindingList<ServerInfo> serverInfoList;

        public Form1()
        {
            InitializeComponent();

            InitData();

            Load += Form1_Load;
            btnAdd.Click += BtnAdd_Click;
            btnDel.Click += BtnDel_Click;
            btnPrt.Click += BtnPrt_Click;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * 
            string a = "2025-07-03 21:04:27";
            string b = "2025-07-03 20:04:27";
            int c = string.CompareOrdinal(a, b);
             */
            string a = "1";
            string b = "2";
            int c = string.CompareOrdinal(a, b);

            string d = "4";
            string ee = "3";
            int f = string.CompareOrdinal(d, ee);

            string g = "5";
            string h = "5";
            int i = string.CompareOrdinal(g, h);
        }

        private void BtnPrt_Click(object sender, EventArgs e)
        {
            foreach(var server in serverInfoList)
            {
                string info = $"Server:{server.Server}, DB:{server.DbName}";
                textBox1.AppendText(info);
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView view = sender as DataGridView;

            if(view.CurrentCell.OwningColumn.DataPropertyName == "Password")
            {
                TextBox passwordText = e.Control as TextBox;

                if (passwordText != null)
                    passwordText.UseSystemPasswordChar = true;
            }
        }

        private void InitControl()
        {
            //dataGridView1.Columns.Clear();

            //DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            //comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //comboCol.Name = "DbType";
            //comboCol.HeaderText = "Db 타입";
            //comboCol.Items.AddRange(new DbType[] { DbType.MSSQL, DbType.Oracle });

            //DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
            //txtCol.Name = "Password";
            //txtCol.HeaderText = "비밀번호";

            //dataGridView1.Columns.AddRange(comboCol);
            ////dataGridView1.Columns.Add("DbType", "Db타입");
            //dataGridView1.Columns.Add("Server", "서버");
            //dataGridView1.Columns.Add("Port", "포트");
            //dataGridView1.Columns.Add("LoginId", "로그인ID");
            ////dataGridView1.Columns.Add("Password", "비밀번호");
            //dataGridView1.Columns.Add(txtCol);
            

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;

            var data = row.DataBoundItem as ServerInfo;
            serverInfoList.Remove(data);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            serverInfoList.Add(new ServerInfo());
        }

        private void InitData()
        {
            //serverList = new List<ServerInfo>();
            //dataGridView1.DataSource = serverList;

            serverInfoList = new BindingList<ServerInfo>();
            dataGridView1.DataSource = serverInfoList;
        }
        
    }
}
