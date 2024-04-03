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
        private int _kitapID;
        private string _kitapAdi;
        private string _yazarAdi;
        private string _kitapNo;
        private string _yayinEvi;
        private string _türü;
        private string _basımTarihi;
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
        public string BasımTarihi
        {
            get { return _basımTarihi; }
            set { _basımTarihi = value; }
        }
        public int KitapID
        {
            get { return _kitapID; }
            set { _kitapID = value; }
        }
        public Kitaplar() { }

        public void DurumDegistir()
        {
            if (kitabınDurum == 0)
            {
                kitabınDurum = kitabinDurumu.mevcutDegil;
            }
            else
                kitabınDurum = kitabinDurumu.mevcut;
        }
        public void TabloyaEkle(DataTable tablo)
        {
            bool bulundu = false;
            DataRowCollection tableRows = tablo.Rows;
            foreach (DataRow row in tableRows)
            {
                if (row["Kitap ID"]==this.KitapID.ToString())
                {
                    bulundu = true;
                    row["Kitap ID"]=this.KitapID;
                    row["Kitap Numarası"] = this.KitapNo;
                    row["Yazar Adı"] = this.YazarAdi;
                    row["Kitap Adı"] = this.KitapAdi;
                    row["Yayın Evi"] = this.YayınEvi;
                    row["Türü"] = this.KitapTürü;
                    row["Basım Tarihi"] = this.BasımTarihi;
                    break;
                }
            }

            if (!bulundu)
            {

                tablo.Rows.Add(new object[] {this.KitapID,
                                         this.KitapNo,
                                         this.YazarAdi,
                                         this.KitapAdi,
                                         this.YayınEvi,
                                         this.KitapTürü,
                                         this.BasımTarihi,
                                         this.kitabınDurum});

            }           
        }
        
    }
}