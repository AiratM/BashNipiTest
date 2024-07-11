using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckApp.Abstractions
{
    public abstract class FileLoaderBase
    {
        public bool IsFileExists(string fileName)
        {

            return true;
        }
    }
}
