using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.CustomControls
{
    public partial class CustomButton : Button
    {
        
        public CustomButton()
        {
            InitializeComponent();
            SetStyle();
        }

        private void SetStyle()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.ForeColor = Color.LightGray;
            this.BackColor = Color.Blue;
        }


    }
}
