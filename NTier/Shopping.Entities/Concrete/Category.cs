﻿using Shopping.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        //unutmaaa
    }
}
