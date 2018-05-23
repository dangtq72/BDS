using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using MemoryData;

namespace Starts_Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        ServiceHost serviceHost;


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serviceHost = new ServiceHost(typeof(AppService));
                int s = AppService.StartRun();

                /// return = 0 la ko co loi gi ca,
                /// return -1 la co loi,
                /// return 2 la lo MDW,
                /// return 3 la ko ket noi dc DB
                if (s == 0)
                {
                    serviceHost.Open();
                    //
                    this.label1.ForeColor = System.Drawing.Color.Blue;
                    this.label1.Text = "You are victorious !";
                }
                else if (s == -1)
                {
                    this.label1.ForeColor = System.Drawing.Color.Red;
                    this.label1.Text = "Lỗi trong quá trình bật service !";
                }
                else if (s == -2)
                {
                    this.label1.ForeColor = System.Drawing.Color.Red;
                    this.label1.Text = "Lỗi kết nối DB !";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn tắt ngay lập tức Service hay không?", "Thông báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
