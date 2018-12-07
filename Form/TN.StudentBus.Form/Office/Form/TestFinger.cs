using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TN.StudentBus.Office.Extention;

namespace TN.StudentBus.Office
{
    public partial class TestFinger : Form
    {
        private int LastId = 0;
        public AxZKFPEngXControl.AxZKFPEngX SensorDriver;
        public TestFinger()
        {
            InitializeComponent(); 
        }
        #region "Functions"
        #endregion
        #region "Event"
        private async void SensorDriver_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            try
            {
                int score = 8;
                int processedNum = 1;
                int ID = SensorDriver.IdentificationInFPCacheDB(Main.fpcHandle, e.aTemplate, ref score, ref processedNum);
                if (ID == -1)
                {
                    //Màu đỏ
                    SensorDriver.ControlSensor(12, 1);
                    SensorDriver.ControlSensor(13, 1);
                    Thread.Sleep(100);
                    SensorDriver.ControlSensor(13, 0);
                    Thread.Sleep(100);
                    SensorDriver.ControlSensor(13, 1);
                    Thread.Sleep(100);
                    SensorDriver.ControlSensor(13, 0);
                    Thread.Sleep(500);
                    SensorDriver.ControlSensor(12, 0);

                    lblStatus.Text = "Nhận dạng thất bại";
                    _Id.Text = "...";
                    _StudentName.Text = "...";
                    _date.Text = "...";
                    _School.Text = "...";
                    _Class.Text = "...";
                    _Birthday.Text = "...";
                }
                else
                {
                    lblStatus.Text = $"Nhận dạng thành công ID = {ID}";
                    try
                    {
                        var kt = await DALContext.StudentByFinger(AppSettings.UserInfo?.Token,ID);
                        if (kt != null)
                        {
                            _Id.Text = kt.Id.ToString();
                            _StudentName.Text = kt.FullName;
                            _date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            _School.Text = kt.School?.Name;
                            _Class.Text = kt.ClassOfSchool?.Name;
                            _Birthday.Text = kt.Birthday?.ToString("dd/MM/yyyy");
                        }
                    }
                    catch
                    {
                    }

                    SensorDriver.ControlSensor(11, 1);
                    SensorDriver.ControlSensor(13, 1);
                    Thread.Sleep(100);
                    SensorDriver.ControlSensor(13, 0);
                    Thread.Sleep(500);
                    SensorDriver.ControlSensor(11, 0);
                    LastId = ID;
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("SensorDriver_OnCapture", ex.ToString());
                return;
            }
        }
   
        private void SensorDriver_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                int dc = g.GetHdc().ToInt32();
                SensorDriver.PrintImageAt(dc, 0, 0, 137, 186);
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("SensorDriver_OnImageReceived", ex.ToString());
                return;
            }
        }
        
        private void AddFinger_Load(object sender, EventArgs e)
        {
            try
            {
                SensorDriver.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(SensorDriver_OnCapture);
                SensorDriver.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("AddFinger_Load", ex.ToString());
                return;
            }
        }
        private void AddFinger_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SensorDriver.OnCapture -= new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(SensorDriver_OnCapture);
                SensorDriver.OnImageReceived -= new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("AddFinger_FormClosing", ex.ToString());
                return;
            }
        }
        #endregion
    }
}
