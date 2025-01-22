﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShoppen1._0.Helpers;
using WebbShoppen1._0.Models;

namespace WebbShoppen1._0.UsingDb
{
    internal class GetInfoDb
    {

        public async Task<List<T>> GetDbInfoAsync<T>() where T : class
        {
            List<T> items;

            using (var db = new MyDbContext())
            {
                items = await db.Set<T>().ToListAsync();
            }
            return items;

        }

        public List<T> GetDbInfo<T>() where T : class
        {
            List<T> items;

            using (var db = new MyDbContext())
            {
                items = db.Set<T>().ToList();
            }
            return items;

        }

    }
}
