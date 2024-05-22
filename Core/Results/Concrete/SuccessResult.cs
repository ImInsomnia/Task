using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success) : base(true)
        {
        }

        public SuccessResult(string message) : base(true, message)
        {

        }
    }
}
