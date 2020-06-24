using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DataModels;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DAL
{
    public interface IUserLoginRepository
    {
        bool Add(Register_UserVM model);
        bool Update(Register_UserVM model);
        bool Delete(int id);
        Register_UserVM GetById(int id);
        IEnumerable<Register_UserVM> GetAll();
    }

    public class UserLoginRepository : IUserLoginRepository
    {
        PerpustakaanDBEntities db = new PerpustakaanDBEntities();
        Register_User ru = new Register_User();
        public bool Add(Register_UserVM model)
        {
            try
            {                
                ru.NamaUser = model.NamaUser;
                ru.Password = model.Password;
                ru.Role = model.Role;
                db.Register_User.Add(ru);
                db.SaveChanges();
                return true;
            }
            catch (SqlException e)
            {
                Debug.WriteLine("cek=>"+ e);
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                ru = db.Register_User.Find(id);
                db.Register_User.Remove(ru);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Register_UserVM> GetAll()
        {
            List<Register_UserVM> listru = new List<Register_UserVM>();
            foreach(Register_User lru in db.Register_User)
            {
                Register_UserVM ruvm = new Register_UserVM();
                ruvm.ID_User = lru.ID_User;
                ruvm.NamaUser = lru.NamaUser;
                ruvm.Password = lru.Password;
                ruvm.Role = lru.Role;
                listru.Add(ruvm);
            }
            return listru;
        }

        public Register_UserVM GetById(int id)
        {
            try
            {
                ru = db.Register_User.Find(id);
                Register_UserVM ruvm = new Register_UserVM();
                ruvm.ID_User = ru.ID_User;
                ruvm.NamaUser = ru.NamaUser;
                ruvm.Password = ru.Password;
                ruvm.Role = ru.Role;
                return ruvm;
            }catch(Exception e)
            {
                return null;
            }
        }

        public bool Update(Register_UserVM model)
        {
            try
            {
                ru = db.Register_User.Find(model.ID_User);
                ru.NamaUser = model.NamaUser;
                ru.Password = model.Password;
                ru.Role = model.Role;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
