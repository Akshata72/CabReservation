using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabreservation
{
    public class CabException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_USER_ID
        }
        public CabException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
