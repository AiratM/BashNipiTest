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
        Task<HashSet<LineModel>> LoadLinesAsync(string sourceName);

        /// <summary>
        /// Получение ошибки загрузки
        /// </summary>
        /// <returns>Текст ошибки</returns>
        public string GetError();
    }
}
