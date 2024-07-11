using Microsoft.Extensions.Logging;
using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
using PlainCheckContracts.Interfaces;
using PlainCheckContracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainCheckApp
{
    public partial class MainForm : Form
    {
        private readonly ILogger _logger;
        private readonly ILineLoader _lineLoader;
        private readonly IGraphicDraw _graphicDraw;
        public MainForm(ILogger<MainForm> logger, ILineLoader lineLoader, IGraphicDraw graphicDraw)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lineLoader = lineLoader ?? throw new ArgumentNullException(nameof(lineLoader));
            _graphicDraw = graphicDraw ?? throw new ArgumentNullException(nameof(graphicDraw));
            InitializeComponent();
            AddGridRows();
            _logger.LogInformation("Программа запущена");
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            var frmAbout = (AboutForm)Program.ServiceProvider.GetService(typeof(AboutForm));
            frmAbout.ShowDialog();
        }

        private async void menuItemOpenFile_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Add("Начало обработки данных");
            _logger.LogInformation("Начало обработки данных");
            menuItemOpenFile.Enabled = false;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stopwatch sw = Stopwatch.StartNew();
            var loadedData = await _lineLoader.LoadLinesAsync(openFileDialog1.FileName);
            if (loadedData is null)
            {
                MessageBox.Show(_lineLoader.GetError(), "Ошибка загрузки данных");
                return;
            }
            var distinctedPolygonIds = loadedData.Select(q => q.PolygonId).Distinct();
            _logger.LogInformation("Данные загружены");
            listBoxLog.Items.Add($"Данные загружены {sw.ElapsedMilliseconds}");
            string graphicFileName = await _graphicDraw.CreateImageAsync(loadedData);
            sw.Stop();
            listBoxLog.Items.Add($"Изображение сгенерировано {sw.ElapsedMilliseconds}");
            pictureBoxMain.LoadAsync(graphicFileName);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddGridRows()
        {
            dataGridViewRectangle.Rows.Add(4);
            dataGridViewRectangle[0, 0].Value = "Первая точка";
            dataGridViewRectangle[0, 1].Value = "Вторая точка";
            dataGridViewRectangle[0, 2].Value = "Третья точка";
            dataGridViewRectangle[0, 3].Value = "Четвертая точка";
            dataGridViewRectangle.AllowUserToAddRows = false;
            dataGridViewRectangle.AllowUserToDeleteRows = false;
        }

        private void menuItemDrawRectangle_Click(object sender, EventArgs e)
        {
            var model = CreateRectangleModel();
            if (model is null)
            {
                return;
            }
        }

        /// <summary>
        /// Создание модели прямоугольника
        /// </summary>
        /// <returns>Модель прямоугольника в случае успешного выполнения, иначе null</returns>
        private RectangleModel CreateRectangleModel()
        {
            try
            {
                var dots = new List<DotModel>(4);
                for (int i = 0; i<4; i++)
                {
                    dots.Add(new DotModel {
                        X = float.Parse(dataGridViewRectangle[1, i].Value.ToString()),
                        Y = float.Parse(dataGridViewRectangle[2, i].Value.ToString()),
                    });
                }
               
                var model = new RectangleModel(dots);

                return null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Произошла ошибка при чтении обработке файла. {e.Message} {e.Source} {e.StackTrace}");
                return null;
            }

        }
    }
}
