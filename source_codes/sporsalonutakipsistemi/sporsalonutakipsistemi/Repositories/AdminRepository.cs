using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.Repositories
{
    public class AdminRepository : GenericRepository<Admin>
    {
        Context c = new Context();
        public bool TGetAdmin(string username, string password)
        {
            if (c.Admins.Any(x => x.Username == username && x.Password == password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
