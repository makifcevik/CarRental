using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProcessSuccessful = "Process is successful";
        public static string ProcessError = "An error occured during process";
        public static string CarNameAlreadyExists = "There is already a car with this name";
        internal static string CarImageLimitExceeded = "There are already enough images for this car";
    }
}
