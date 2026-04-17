using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WindowsFormsApplication1.Models
{
    public class Item : INotifyPropertyChanged
    {
        private static readonly Random r = new Random();

        public Item()
        {
            Id = r.Next();
        }

        public Item(string code, string name) : this()
        {
            this.Code = code;
            this.Name = name;
        }


        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

    }
}
