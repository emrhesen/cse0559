using Domain.Business.TicketOrder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.CommandServices
{
    public interface ITicketCommandService
    {
        Task SellTicketAsync(TicketEntity entity, CancellationToken ctx);
    }
}
