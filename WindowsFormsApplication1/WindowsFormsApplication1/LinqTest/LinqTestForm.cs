using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.LinqTest
{
    public partial class LinqTestForm : Form
    {
        public LinqTestForm()
        {
            InitializeComponent();
            AddEvents();
        }

        private void AddEvents()
        {
            this.Load += new EventHandler(LinqTestForm_Load);
        }

        private void InitData()
        {
            List<StockoutReq> list = new List<StockoutReq>();
            list.Add(new StockoutReq()
            {
                Id=1,
                ReqNumber="R-001",
                ItemCode = "itemA",
                Quantity=10
            });
            list.Add(new StockoutReq()
            {
                Id = 1,
                ReqNumber = "R-001",
                ItemCode = "itemB",
                Quantity = 20
            });
            list.Add(new StockoutReq()
            {
                Id = 2,
                ReqNumber = "R-002",
                ItemCode = "itemA",
                Quantity = 1000
            });
            list.Add(new StockoutReq()
            {
                Id = 3,
                ReqNumber = "R-003",
                ItemCode = "itemC",
                Quantity = 990
            });

            var groupby = list.GroupBy(x => x.Id)
                .ToDictionary(x=> x.Key, y=> y.ToList());

        }

        void LinqTestForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

    }
}
