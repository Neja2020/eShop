﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MeasureUnit { get; set; }
        public double Price { get; set; }
    }
}
