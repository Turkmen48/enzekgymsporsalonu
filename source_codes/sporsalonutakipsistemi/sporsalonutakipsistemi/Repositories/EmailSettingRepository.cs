using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.Repositories
{
    public class EmailSettingRepository : GenericRepository<EmailSetting>
    {
        Context context = new Context();
        public EmailSetting GetFirst()
        {
            return context.EmailSettings.FirstOrDefault();
        }
    }
}
