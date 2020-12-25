using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRatings.Client.Domain
{
    public class UserLoginResult
    {
        public bool Succeeded { get; private set; }
        public string Error { get; private set; }

        public UserLoginResult(bool succeeded, string error = null)
        {
            this.Succeeded = succeeded;
            this.Error = error;
        }
    }
}
