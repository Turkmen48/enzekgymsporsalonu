﻿using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.Repositories
{
    public class SiteInfoRepository : GenericRepository<SiteInfo>
    {
        Context context = new Context();
        public SiteInfo GetFirst()
        {
            return context.SiteInfos.FirstOrDefault();
        }
    }
}
