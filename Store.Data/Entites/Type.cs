﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites
{
    public class Type : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
