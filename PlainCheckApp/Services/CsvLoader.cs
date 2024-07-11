using Microsoft.Extensions.Logging;
using PlainCheckApp.Abstractions;
using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
using PlainCheckContracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCheckApp.Services
{
    public class CsvLoader : FileLoaderBase, ILineLoader
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Ошибка выполнения загрузки
        /// </summary>
        private string _error;

        /// <summary>
        /// Разделитель для значений в файле csv
        /// </summary>
        public char Delimeter { get; set; } = ';';

        public CsvLoader(ILogger<CsvLoader> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string GetError() => _error;

        public async Task<HashSet<LineModel>> LoadLinesAsync(string sourceName) => await Task.Run(() => LoadLines(sourceName));

        public HashSet<LineModel> LoadLines(string sourceName)
        {
            if (!IsFileExists(sourceName))
            {
                _error = $"Указанный файл {sourceName} не существует!";
                _logger.LogError(_error);
                return null;
            }

            var hash = new HashSet<LineModel>();
            try
            {
                using var reader = File.OpenText(sourceName);
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    var arr = s.Split(Delimeter);

                    if (arr.Length != 4)
                    {
                        _error = "Ошибка в структуре файла";
                        _logger.LogError(_error);
                        return null;
                    }
                    hash.Add(new LineModel
                    {
                        LineId = int.Parse(arr[0]),
                        Dot = new DotModel
                        {
                            X = float.Parse(arr[1]),
                            Y = float.Parse(arr[2]),
                        },
                        PolygonId = int.Parse(arr[3]),
                    });
                }
            }
            catch (Exception e)
            {
                _error = $"Произошла ошибка при чтении обработке файла. {e.Message}";
                _logger.LogError($"Произошла ошибка при чтении обработке файла. {e.Message} {e.Source} {e.StackTrace}");
                return null;
            }
            return hash;
        }


    }
}
