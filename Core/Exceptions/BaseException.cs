using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BaseException : Exception
    {
        public LogException Exception { get; private set; }
        public BaseException(LogException logException)
        {
            this.Exception = logException;
        }
    }
}
