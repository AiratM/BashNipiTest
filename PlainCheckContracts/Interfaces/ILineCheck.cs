using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckContracts.Interfaces
{
    public interface ILineCheck
    {
        Task<bool> IsLineInRectangle();
    }
}
