using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BukuVM
    {
        public string ID_Buku { get; set; }
        public string JudulBuku { get; set; }
        public string Pengarang { get; set; }
        public string jenisBuku { get; set; }
        public int? HargaSewa { get; set; }
    }
}
