using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public abstract class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        protected Result(bool success)
        {
            Success = success;
        }

        protected Result(bool success, string message):this(success)
        {
            Message = message;
        }
    }
}
