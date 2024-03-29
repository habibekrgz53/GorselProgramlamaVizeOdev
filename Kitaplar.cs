using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorselProgramlama
{
    
    public enum kitabinDurumu { mevcut, mevcutDegil }

    public class Kitaplar
    {
        
        private string _kitapAdi;
        private string _yazarAdi;
        private string _kitapNo;
        private string _yayinEvi;
        private string _türü;
        private int _basımTarihi;
        public kitabinDurumu kitabınDurum;

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

        public string KitapNo
        {
            get { return _kitapNo; }
            set { _kitapNo = value; }
        }
        public string YayınEvi
        {
            get { return _yayinEvi; }
            set { _yayinEvi = value; }
        }
        public string KitapTürü
        {
            get { return _türü; }
            set { _türü = value; }
        }
        public int BasımTarihi
        {
            get { return _basımTarihi; }
            set { _basımTarihi = value; }
        }
        public Kitaplar() { }

       
        public void TabloyaEkle(DataTable tablo)
        {
            tablo.Rows.Add(new object[] {this.KitapAdi,
                                         this.YazarAdi,
                                         this.KitapNo,
                                         this.YayınEvi,
                                         this.KitapTürü,
                                         this.BasımTarihi,
                                         this.kitabınDurum});
                                         


                                         
        }
        
    }
}