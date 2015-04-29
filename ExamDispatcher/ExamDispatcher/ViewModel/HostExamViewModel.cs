using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DataModels.Questions;
using ExamSandbox;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Webservice;

namespace ExamDispatcher.ViewModel
{
    public class HostExamViewModel : ViewModelBase
    {
        #region Properties and Fields
        private Exam _Exam;
        public Exam Exam
        {
            get { return _Exam; }
            set
            {
                if (_Exam == value)
                    return;
                _Exam = value;
                Image = BitmapToImageSource(GenerateQR(100, 100, LocalIPAddress() + ":" + Exam.ExamId.ToString()));
                RaisePropertyChanged("Exam");
            }
        }

        private BitmapImage _Image;
        public BitmapImage Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                RaisePropertyChanged("Image");
            }
        }
        #endregion


        #region Commands
        public ICommand StartExamCommand { get; private set; }
        private void ExecuteStartCommand()
        {
            NancyWebservice.Start();
            Sandbox.AddExamToSandbox(Exam);
            Sandbox.StartExamById(Exam.ExamId);

        }

        public ICommand StopExamCommand { get; private set; }
        private void ExecuteStopCommand()
        {
            Sandbox.StopExamById(Exam.ExamId);
            Sandbox.RemoveExamById(Exam.ExamId);
            NancyWebservice.Stop();
            
        }
        #endregion

        public HostExamViewModel()
        {
            StartExamCommand = new RelayCommand(() => ExecuteStartCommand());
            StopExamCommand = new RelayCommand(() => ExecuteStopCommand());
            


        }

        private Bitmap GenerateQR(int width, int height, string text)
        {
            var bw = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(bw.Write(text));

            return result;
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

    }
}
