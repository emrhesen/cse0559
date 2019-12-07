using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Service.DTO
{
    public class MovieDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }
    }
}
