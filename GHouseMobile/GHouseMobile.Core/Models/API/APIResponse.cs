using System;
using System.Collections.Generic;

namespace GHouseMobile.Core.Models.API
{
    public class APIResponse
    {
        public string Version { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsCustomErrorObject { get; set; }
        public string Result { get; set; }

        public List<APIResponseError> Error { get; set; }
    }
}
