using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.Exeptions
{
    public class DuplicatedRecordExeption : Exception
    {
        public DuplicatedRecordExeption() { }
        public DuplicatedRecordExeption(string message) : base(message) { }
        
    }
}
