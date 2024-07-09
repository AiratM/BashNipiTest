using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainCheckApp
{
    public partial class MainForm : Form
    {
        private readonly ILogger _logger;
        public MainForm(ILogger<MainForm> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            InitializeComponent();
            _logger.LogInformation("Программа запущена");
        }
    }
}
