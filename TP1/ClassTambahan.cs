using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TP1
{
    class FilterHarga
    {
        string value;
        public FilterHarga(string str)
        {
            this.value = str;
        }
        public int getMinHarga()
        {
            int nilai = 0;
            if (this.value == "100rb - 200rb") {
                nilai = 100000;
            } else if (this.value == "200rb - 500rb")
            {
                nilai = 200000;
            }
            else if (this.value == "500rb - 1juta")
            {
                nilai = 500000;
            }
            return nilai;
        }

        public int getHighHarga()
        {
            int nilai = 0;
            if (this.value == "100rb - 200rb")
            {
                nilai = 200000;
            }
            else if (this.value == "200rb - 500rb")
            {
                nilai = 500000;
            }
            else if (this.value == "500rb - 1juta")
            {
                nilai = 1000000;
            }
            return nilai;
        }
    }

    class TambahBarang
    {
        public TambahBarang(int setID,string setNama, int setHarga,string setJenisBarang, string setDeskripsi)
        {
            id = setID;
            nama = setNama;
            harga = setHarga;
            jenisBarang = setJenisBarang;
            deskripsi = setDeskripsi;
        }
        public int id { get; set; }
        public string nama{ get; set; }
        public int harga { get; set; }
        public string jenisBarang { get; set; }
        public string deskripsi { get; set; }

    }
    

}
