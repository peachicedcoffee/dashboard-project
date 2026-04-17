using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class TestData
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Button { get; set; }

        public TestData()
        {
        }

        public TestData(int id, string text) 
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
