using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorselProgramlama
{
    public class Uyeler
    {
        private string _uyeAdi;
        private string _uyeSoyadi;
        private string _mail;
        private int _tel;

        public string UyeAdi
        {
            get { return _uyeAdi; }
            set { _uyeAdi = value; }
        }

        public string UyeSoyadi
        {
            get { return _uyeSoyadi; }
            set { _uyeSoyadi = value; }
        }
        public string UyeMail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        public int UyeTel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public Uyeler() { }
        public void TabloyaEkle(DataTable tablo)
        {
            tablo.Rows.Add(new object[] {this.UyeAdi,
                                         this.UyeSoyadi,
                                         this.UyeMail,
                                         this.UyeTel});




        }


    }
}