using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    class InvalidDataException :Exception
    {
        public InvalidDataException(string message) : base(message)
        {

        }
    }



}
