﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public interface ICoursesManagmentDbContextFactory
    {
        CoursesManagmentContext CreateDbContext();
    }
}
