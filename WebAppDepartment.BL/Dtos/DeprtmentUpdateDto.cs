﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppDepartment.BL
{
    public class DeprtmentUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Budget { get; set; }
    }
}
