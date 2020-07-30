using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace API.Models.AmadeusResponse
{
    public class AmadeusResponse
    {
        public AmadeusResponse()
        {
            Data = new HashSet<Data>();
        }

        public Meta Meta { get; set; }
        public IEnumerable<Data> Data { get; set; }
    }
}
