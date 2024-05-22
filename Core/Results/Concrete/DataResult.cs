using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public abstract class DataResult<T> : Result, IDataResult<T>
    {
        protected DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        protected DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
