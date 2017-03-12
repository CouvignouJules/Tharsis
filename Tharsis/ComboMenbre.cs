using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tharsis
{
    class ComboMenbre
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboMenbre(string text, int value)
        {
            Text = text;
            Value = value;
        }

       

        public override string ToString()
        {
            return Text;
        }
    }
}
