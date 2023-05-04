using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class PUsersCount : ViewComponent
    {
        UserRepository userRepository = new UserRepository();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var deger = await userRepository.GetFilteredDataAsync(x => x.IsActive == false);
            return View(deger.Count());
        }
    }
}
