using sporsalonutakipsistemi.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace sporsalonutakipsistemi.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        Context c = new Context();
        public bool TGetUser(string email, string password)
        {

            var user = c.Users.Where(x => x.Email == email && x.Password == password && x.IsActive == true).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<User> TGetPassives()
        {
            return c.Users.Where(x => x.IsActive == false).ToList();
        }
    }

}

