﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBoundedContext.Service.Controllers.v1.ValueObjects
{
    public class CreateProductRequest
    {
        public string Description { get; set; }
        public string BarCode { get; set; }
        public string UnitMeasurementId { get; set; }
    }
}
