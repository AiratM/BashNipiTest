using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckContracts.Interfaces
{
    /// <summary>
    /// Основная проверка
    /// </summary>
    public interface IPlaneCheck
    {
        Task<bool> CheckLinesAsync();
    }
}
