using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorselProgramlama
{
    public class Kitaplar
    {
        private string _kitapAdi;
        private string _yazarAdi;
        private int _kitapNo;

        public string KitapAdi
        {
            get { return _kitapAdi; }
            set { _kitapAdi = value; }
        }

        public string YazarAdi
        {
            get { return _yazarAdi; }
            set { _yazarAdi = value; }
        }

        public int KitapNo
        {
            get { return _kitapNo; }
            set { _kitapNo = value; }
        }

        public Kitaplar() { }


    }
}