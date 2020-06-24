using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DataModels;
using System.Diagnostics;
using System.Data.SqlClient;

namespace DAL
{
    public interface IBukuRepository
    {
        bool Add(BukuVM model);
        bool Update(BukuVM model);
        bool Delete(string idBuku);
        BukuVM getByID(string IdBuku);
        IEnumerable<BukuVM> getAll();
    }
    public class BukuRepository : IBukuRepository
    {
        PerpustakaanDBEntities db = new PerpustakaanDBEntities();
        Buku b = new Buku();
        public bool Add(BukuVM model)
        {
            try
            {
                b.ID_Buku = model.ID_Buku;
                b.jenisBuku = model.jenisBuku;
                b.JudulBuku = model.jenisBuku;
                b.Pengarang = model.Pengarang;
                b.HargaSewa = model.HargaSewa;
                db.Bukus.Add(b);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(string idBuku)
        {
            try
            {
                b = db.Bukus.Find(idBuku);
                //Debug.WriteLine("cek b=>"+b.ID_Buku);
                if(b != null)
                {                                   
                    db.Bukus.Remove(b);
                    //Debug.WriteLine("cek b1=>"+b.ID_Buku);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    //Debug.WriteLine("cek b2=>"+b.ID_Buku);
                    return false;
                }
            }
            catch (SqlException e)
            {
                //Debug.WriteLine("cek catch=>" +e);
                return false;
            }
        }

        public IEnumerable<BukuVM> getAll()
        {
            List<BukuVM> ListBuku = new List<BukuVM>();
            foreach(Buku bk in db.Bukus)
            {
                BukuVM model = new BukuVM();
                model.ID_Buku = bk.ID_Buku;
                model.jenisBuku = bk.jenisBuku;
                model.JudulBuku = bk.JudulBuku;
                model.Pengarang = bk.Pengarang;
                model.HargaSewa = bk.HargaSewa;
                ListBuku.Add(model);                
            }
            return ListBuku;
        }

        public BukuVM getByID(string IdBuku)
        {           
            b = db.Bukus.Find(IdBuku);
            if(b != null)
            {
                BukuVM bVM = new BukuVM();
                bVM.ID_Buku = b.ID_Buku;
                bVM.jenisBuku = b.jenisBuku;
                bVM.JudulBuku = b.JudulBuku;
                bVM.Pengarang = b.Pengarang;
                bVM.HargaSewa = b.HargaSewa;
                return bVM;
            }
            else
            {
                return null;
            }           
        }

        public bool Update(BukuVM model)
        {
            try
            {
                b = db.Bukus.Find(model.ID_Buku);
                if(b != null)
                {
                    b.jenisBuku = model.jenisBuku;
                    b.JudulBuku = model.JudulBuku;
                    b.Pengarang = model.Pengarang;
                    b.HargaSewa = model.HargaSewa;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
        }
    }
}
