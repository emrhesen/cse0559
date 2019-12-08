using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketOrder.Service.DTO
{
    public class TicketDTO
    {
        public string MovieId { get; set; }
        public string FullName { get; set; }
        public int Price { get; set; }
    }
}
