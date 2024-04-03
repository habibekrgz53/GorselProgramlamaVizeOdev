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
        private string _tel;
        private int ID;
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
        public string UyeTel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public int UyeID
        {
            get { return ID; }
            set { ID = value; }
        }
        public Uyeler() { }
        public void TabloyaEkle(DataTable tablo)
        {
            bool bulundu = false;
            foreach (DataRow row in tablo.Rows)
            {
                if (Convert.ToInt32(row["Üye ID"]) == this.ID)
                {
                    bulundu = true;
                    row["Üye Adı"] = this.UyeAdi;
                    row["Üye Soyadı"]=this.UyeSoyadi;
                    row["Üye Mail"] = this.UyeMail;
                    row["Üye Tel"]= this.UyeTel;
                    break;
                }
                
            }
            if (!bulundu)
            {
                tablo.Rows.Add(new object[] {this.ID,
                                         this.UyeAdi,
                                         this.UyeSoyadi,
                                         this.UyeMail,
                                         this.UyeTel});
            }
        }
            



    }
}