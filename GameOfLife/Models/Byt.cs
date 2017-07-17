using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Byt
    {
        public bool zywa;

        public Byt()
        {
            zywa = false;
        }

        public override string ToString()
        {
            return zywa ? "█" : "░";
        }

        public void Ozyw()
        {
            zywa = true;
        }
        public void Ubij()
        {
            zywa = false;
        }
    }
}
