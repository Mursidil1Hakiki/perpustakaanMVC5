using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ViewModels;

namespace ViewModels
{
    public class sewaVM
    {
        public int ID_Sewa { get; set; }
        public int? ID_User { get; set; }
        public string ID_Buku { get; set; }
        public int? HargaSewa { get; set; }
        public DateTime? tglMulai { get; set; }
        public DateTime? tglSelesai { get; set; }
        public int? numberOfDay { get; set; }
        public int? sewaAmount { get; set; }        
    }
}
