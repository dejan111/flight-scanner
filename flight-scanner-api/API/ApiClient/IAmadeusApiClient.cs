using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApiClient
{
    public interface IAmadeusApiClient
    {
        //Task<string> GetProtectedResources();
        Task<string> PostProtectedResources(string json, string url);
    }
}
