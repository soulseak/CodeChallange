﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallange.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public Member Member { get; set; }
    }
}