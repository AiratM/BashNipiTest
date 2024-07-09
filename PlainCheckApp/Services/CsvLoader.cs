using Microsoft.Extensions.Logging;
using PlainCheckApp.Abstractions;
using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCheckApp.Services
{
    internal class CsvLoader : FileLoaderBase, ILineLoader
    {
        private readonly ILogger _logger;
        public char Delimeter { get; set; } = ';';

        public CsvLoader(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<List<LineType>> LoadLinesAsync(string sourceName) => await Task.Run(() => LoadLines(sourceName));

        public List<LineType> LoadLines(string sourceName)
        {
            _logger.LogInformation("Начало загрузки из файла");

            if (!IsFileExists(sourceName))
            {
                _logger.LogError($"Указанный файл {sourceName} не существует!");
                return null;
            }

            var hash = new HashSet<LineType>();
            try
            {
                using var reader = File.OpenText(sourceName);
                string s = reader.ReadLine();
                var arr = s.Split(Delimeter);

                if (arr.Length != 4)
                {
                    _logger.LogError("Ошибка в структуре файла");
                    return null;
                }
                hash.Add(new LineType
                {
                    LineId = int.Parse(arr[0]),
                    X1 = int.Parse(arr[1]),
                    Y1 = int.Parse(arr[2]),
                    PolygonId = int.Parse(arr[3]),
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Произошла ошибка при чтении обработке файла. {e.Message} {e.Source} {e.StackTrace}");
                return null;
            }
            return hash.ToList();
        }


    }
}
