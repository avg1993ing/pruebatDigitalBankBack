﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BagRequestBusinessException : BaseException
    {
        public BagRequestBusinessException(LogException logException) : base(logException)
        {
        }
    }
}
