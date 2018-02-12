using System;
using System.Collections.Generic;

namespace SM.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string LogoUrl { get; set; }
    }
}