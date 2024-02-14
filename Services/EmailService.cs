using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventSample.Services
{
    public class EmailService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"EmailService: {message}");
        }
    }
}
