using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DataModels;

namespace DAL
{
    public interface iSewa
    {
        IEnumerable<sewaVM> GetAll();
        IEnumerable<sewaVM> GetByName(String Name);
        bool insert(sewaVM model);

    }
    public class SewaRepository : iSewa
    {
        PerpustakaanDBEntities db = new PerpustakaanDBEntities();
        Sewa sw = new Sewa();
        public IEnumerable<sewaVM> GetAll()
        {
            List<sewaVM> listSewa = new List<sewaVM>();
            foreach(Sewa sw in db.Sewas)
            {
                sewaVM model = new sewaVM();
                model.ID_Buku = sw.ID_Buku;
                model.ID_User = sw.ID_User;
                model.HargaSewa = sw.HargaSewa;
                model.numberOfDay = sw.numberOfDay;
                model.sewaAmount = sw.sewaAmount;
                model.tglMulai = sw.tglMulai;
                model.tglSelesai = sw.tglSelesai;
                listSewa.Add(model);
            }
            return listSewa;
        }

        public IEnumerable<sewaVM> GetByName(string Name)
        {
            List<sewaVM> listSewa = new List<sewaVM>();
            int getIdUser = db.Register_User.Where(r => r.NamaUser == Name).FirstOrDefault().ID_User;
            var getDataSewa = db.Sewas.Where(x => x.ID_User == getIdUser);
            foreach (Sewa sw in getDataSewa)
            {
                sewaVM model = new sewaVM();
                model.ID_Buku = sw.ID_Buku;
                model.ID_User = sw.ID_User;
                model.HargaSewa = sw.HargaSewa;
                model.numberOfDay = sw.numberOfDay;
                model.sewaAmount = sw.sewaAmount;
                model.tglMulai = sw.tglMulai;
                model.tglSelesai = sw.tglSelesai;
                listSewa.Add(model);
            }
            return listSewa;
        }

        public bool insert(sewaVM model)
        {
            DateTime tglMulai = model.tglMulai.;  
            sw.ID_User = model.ID_User;
            sw.ID_Buku = model.ID_Buku;
            sw.numberOfDay =DateTime.Compare(model.tglSelesai, model.tglMulai);
            

        }
    }
}
