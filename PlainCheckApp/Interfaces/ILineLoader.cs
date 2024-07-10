using PlainCheckContracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckApp.Interfaces
{
    /// <summary>
    /// Интерфейс загрузки данных по линиям
    /// </summary>
    public interface ILineLoader
    {
        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <param name="sourceName">Наименование источника данных</param>
        /// <returns>Коллекция линиий</returns>
        Task<HashSet<LineType>> LoadLinesAsync(string sourceName);
    }
}
