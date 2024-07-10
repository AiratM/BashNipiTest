using Microsoft.Extensions.Logging;
using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
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
            var distinctedPolygonIds = loadedData.Select(q => q.PolygonId).Distinct();
            _logger.LogInformation("Данные загружены");
            listBoxLog.Items.Add($"Данные загружены {sw.ElapsedMilliseconds}");
            string graphicFileName = await _graphicDraw.CreateImageAsync(loadedData);
            sw.Stop();
            listBoxLog.Items.Add($"Изображение сгенерировано {sw.ElapsedMilliseconds}");
            pictureBoxMain.LoadAsync(graphicFileName);
        }
        private async Task<bool> CalcResultsAsync()
        {
            listBoxLog.Items.Add("before");
            var tasks = new[]
            {
                Task.Run(()=> One()),
                Task.Run(()=> Two())
            };
            await Task.WhenAll(tasks);

            //var t2 = One();
            //var t3 = Two();
            //await Task.WhenAll(t1, t2, t3);
            listBoxLog.Items.Add($"One: {tasks[0].Result.Item1}, {tasks[0].Result.Item2}");
            listBoxLog.Items.Add($"Two: {tasks[1].Result.Item1}, {tasks[1].Result.Item2}");
            menuItemOpenFile.Enabled = true;
            return true;
        }

        private async Task<(int, int)> One()
        {
            int i1 = Thread.CurrentThread.ManagedThreadId;
            await Task.Delay(5000);
            int i2 = Thread.CurrentThread.ManagedThreadId;
            return (i1, i2);
        }
        private async Task<(int, int)> Two()
        {
            int i1 = Thread.CurrentThread.ManagedThreadId;
            await Task.Delay(3000);
            int i2 = Thread.CurrentThread.ManagedThreadId;
            return (i1, i2);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
