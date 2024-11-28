using System;
using System.Collections.Generic;

using System.Drawing;
using System.IO;

using System.Windows.Forms;

using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using AForge.Video;

namespace TimeSeriesCollector.recordImplement
{
    public partial class USBCameraRecordForm : Form, IRecordable
    {
        FilterInfoCollection cameras;
        VideoFileWriter videoWriter;
        VideoCaptureDevice videoCaptureDevice;

        bool isRecording = false;
        Dictionary<String, Bitmap> mats = new Dictionary<String, Bitmap>();
        Dictionary<String, VideoCodec> encodingMap = new Dictionary<String, VideoCodec>();

        public USBCameraRecordForm()
        {
            InitializeComponent();
            InitializeCameraSelector();
        }
        private void InitializeCameraSelector()
        {

            // 枚举所有视频输入设备
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (cameras.Count == 0)
            {
                MessageBox.Show("没有找到可用的摄像头设备");
                deleted = true;
                return;
            }

            foreach (FilterInfo device in cameras)
            {
                int i = 1;
                channelBox.Items.Add(device.Name);
                i++;
            }


            encodingMap.Add("Raw", VideoCodec.Raw);
            encodingMap.Add("H.264", VideoCodec.H264);
            encodingMap.Add("H.265", VideoCodec.H265);
            encodingMap.Add("MPEG4", VideoCodec.MPEG4);
            encodingMap.Add("VP9", VideoCodec.VP9);
            foreach (var kv in encodingMap)
            {
                encodingComboBox.Items.Add(kv.Key);
            }
            if(encodingComboBox.Items.Count > 0)
                encodingComboBox.SelectedIndex = 0;

        }
        ~USBCameraRecordForm()
        {
        }
        public string prefix { get; set; } = "";
        public string path { get; set; } = "";
        public int interval { get; set; } = 0;
        public bool deleted { get; set; } = false;
        public int recordTime { get; set; } = 0;
        // 生成一段时间序列作为文件名
        private string filePath;


        private void InitializeCamera()
        {
            int selectedChannel = channelBox.SelectedIndex;
            videoCaptureDevice = new VideoCaptureDevice(cameras[selectedChannel].MonikerString);
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(Record_NewFrame);

            videoSourcePlayer.VideoSource = videoCaptureDevice;
            //videoSourcePlayer.NewFrame += VideoPlay_NewFrame;
            videoSourcePlayer.Start();

            // 视频质量

            VideoCapabilities[] resolutions = videoCaptureDevice.VideoCapabilities;
            foreach (VideoCapabilities resolution in resolutions)
            {
                int height = resolution.FrameSize.Height;
                int width = resolution.FrameSize.Width;
                int frameRate = resolution.AverageFrameRate;
                videoQualityComboBox.Items.Add(String.Format("{0}x{1},{2}fps", width,height, frameRate));
            }
            if (videoQualityComboBox.Items.Count > 0)
            {
                videoQualityComboBox.SelectedIndex = 0;
                setProp();
            }

        }
        private void setProp()
        {
            videoSourcePlayer.Stop();
            VideoCapabilities r = videoCaptureDevice.VideoCapabilities[videoQualityComboBox.SelectedIndex];
            videoCaptureDevice.VideoResolution = r;
            videoSourcePlayer.Start();
        }
        private void DisposeCamera()
        {
            videoQualityComboBox.Items.Clear();
            if (videoSourcePlayer.IsRunning)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }
            

        }

        public bool isReady()
        {
            return videoSourcePlayer.IsRunning;
        }
        public void startRecord()
        {

            if (!Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            filePath = Path.Combine(path, string.Format("{0}-{1:yyyyMMddHHmmss}.avi", prefix, DateTime.Now));
            mats.Clear();
            isRecording = true;
            setGroupBox.Enabled = false;

            videoWriter = new VideoFileWriter();

            int quality_index = videoQualityComboBox.SelectedIndex;
            VideoCapabilities resolution = videoCaptureDevice.VideoCapabilities[quality_index];
            /*                int height = resolution.FrameSize.Height,
                                width = resolution.FrameSize.Width,
                                frameRate = resolution.AverageFrameRate;*/
            int height = resolution.FrameSize.Height,
                width = resolution.FrameSize.Width,
                frameRate = resolution.AverageFrameRate;
            string key = encodingComboBox.Text;
            VideoCodec codec = VideoCodec.Default;
            encodingMap.TryGetValue(key, out codec);
            videoWriter.Open(filePath, width, height, frameRate, codec);

        }
        private void Record_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (isRecording)
            {
                if (videoWriter != null)
                {
                    using (Bitmap frame = (Bitmap)eventArgs.Frame.Clone())
                    { 
                    
                        videoWriter.WriteVideoFrame(frame);
                        videoWriter.Flush();
                    }
                    
                }
            }
            // eventArgs.Frame.RotateFlip(RotateFlipType.RotateNoneFlipX);

        }
        public void stopRecord(bool saveOrNot)
        {

            isRecording = false;
            setGroupBox.Enabled = true;
            if (!saveOrNot)
            {
                if (File.Exists(path))
                    File.Delete(filePath);
                mats.Clear();
            }

            //停止录像 Stop recording

            videoWriter.Close();
            videoWriter.Dispose();
            videoWriter = null;

        }
        protected override void OnClosed(EventArgs e)
        {
            deleted = true;
            DisposeCamera();
            base.OnClosed(e);
        }

        private void channelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeCamera();
            InitializeCamera();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void videoQualityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setProp();
        }
    }
}
