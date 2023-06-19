using RegisterAndLoginApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegisterAndLoginApp.Services
{
    public class SecurityService
    {


        
        UsersDAO usersDAO = new UsersDAO();

        public SecurityService()
        {


        }

        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
            // return true eğer listede varsa bul
            
        }
    }
}
