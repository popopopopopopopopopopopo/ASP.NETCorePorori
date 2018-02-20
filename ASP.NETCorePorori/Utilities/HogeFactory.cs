using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ASP.NETCorePorori.Models;

namespace ASP.NETCorePorori.Utilities
{
    public static class HogeFactory
    {
        private static AsyncLocal<HogeModel> Factory { get; set; } = new AsyncLocal<HogeModel>(hoge=>Console.WriteLine("Changed"));

        public static HogeModel Hoge
        {
            get => Factory.Value ?? (Factory.Value = new HogeModel());
        }
    }
}
