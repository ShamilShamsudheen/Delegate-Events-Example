using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventSample.Services
{
    public class SMSService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMSService: {message}");
        }
    }
}
