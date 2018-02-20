using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ASP.NETCorePorori.Models
{
    public class HogeModel
    {
        public int ThreadId { get; set; } = Thread.CurrentThread.ManagedThreadId;

        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
