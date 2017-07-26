using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Byt
    {
        public int zywa;
        public string symbol;
        public int x;
        public int y;
        public int iloscSasiadow;

        public Byt()
        {
            iloscSasiadow = 0;
            Ubij();
        }
        public Byt(int x, int y)
        {
            Ubij();
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            //return iloscSasiadow == 0 ? symbol : iloscSasiadow.ToString();
            return symbol;
        }

        public void Ozyw()
        {
            zywa = 1;
            symbol = "█";
        }
        public void Ubij()
        {
            zywa = 0;
            symbol = "_";
        }
    }
}
