﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Exceptions
{
    public class ProductException : Exception
    {

        public ProductException(string message) : base(message)
        {
            SaveError(message);
        }


        void SaveError(string message)
        {
            //Any logic to persist the error
        }
    }
}
