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
            Data = new List<Data>();
        }

        public Meta Meta { get; set; }
        public List<Data> Data { get; set; }
    }
}
