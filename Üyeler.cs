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

      

        public Uyeler() { }

        
    }
}