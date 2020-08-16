using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garages_Recruit_1271.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = 2,
                 Name = "gggg",
                 Password = "ddddfff",
                 Address = "ddddeee",
                 Phone = 33333,
                 Mail = "eee@gmail.com"
             }
             );
        }
    }
}
