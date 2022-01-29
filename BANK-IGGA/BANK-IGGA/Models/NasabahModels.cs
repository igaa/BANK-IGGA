using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BANK_IGGA.Models
{
    public class NasabahModels
    {
        public int id { get; set;  }
        public string nama_lengkap { get; set; }
        public string alamat { get; set;  }
        public string tempat_lahir { get; set; }
        public DateTime tanggal_lahir { get; set; }
        public string no_ktp { get; set; }
        public string nohp { get; set; }
    }
}
