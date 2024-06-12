using System;

namespace GHouseMobile.Core.Exceptions
{
    public class UnAuthorizeException : Exception
    {
        public UnAuthorizeException(string message)
            : base(message)
        {

        }
    }
}
