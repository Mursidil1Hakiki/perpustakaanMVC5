using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DataModels;

namespace DAL
{
    public interface IformLogin
    {
        Register_UserVM Validation(Register_UserVM model);
    }
    public class FormLogin : IformLogin
    {
        PerpustakaanDBEntities db = new PerpustakaanDBEntities();
        public Register_UserVM Validation(Register_UserVM model)
        {
            
            var datauser = db.Register_User.Where(x => x.NamaUser == model.NamaUser).FirstOrDefault();            
            
            if (model.NamaUser == datauser.NamaUser && model.Password == datauser.Password)
            {
                Register_UserVM newModel = new Register_UserVM();
                newModel.ID_User = datauser.ID_User;
                newModel.NamaUser = datauser.NamaUser;
                newModel.Password = datauser.Password;
                newModel.Role = datauser.Role;
                return newModel;
            }
            else
            {
                return null;
            }                     
                        
        }
    }
}
