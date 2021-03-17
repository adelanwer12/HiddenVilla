﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelsRooms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
