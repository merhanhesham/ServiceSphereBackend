﻿using ServiceSphere.core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.SpecificationsForUsers
{
    public interface ISpecificationsUsers<T> where T:AppUser
    {
        //signature for where 
        public Expression<Func<T, bool>> Critria { get; set; }
        //signature for include 
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public Expression<Func<T, Object>> OrderByDesc { get; set; }
    }
}
