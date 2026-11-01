using Microsoft.Extensions.Logging;
using NLog;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using UnitTestingForEon.Database.Mappers;
using UnitTestingForEon.ServiceLayer;

namespace UnitTestingForEon
{
    public partial class MainForm(VendorMapper vendorMapper) : Form
    {
        public required LoggingService<MainForm> logger ;
        public MainForm(LoggingService<MainForm> logger, VendorMapper vendorMapper) : this(vendorMapper)
        {
            this.logger = logger;
            this.logger.LogDebug("MainForm constructor called.");
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form initialization logic can go here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DEBUG TEST");
            logger.LogDebug("Button clicked.");
            logger.LogInformation("Button clicked.");
            vendorMapper.MapVendor(null);
        }
    }


}
