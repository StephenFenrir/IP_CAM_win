using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video; //Windows library to deal with stream and video.

namespace CP_CAM_TEST
{
    public partial class Form1 : Form
    {
        MJPEGStream stream;
        public Form1()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://172.16.7.44:4747/mjpegfeed?640x480"); //Access to direct video stream
            stream.NewFrame += stream_New_Frame;
        }

        void stream_New_Frame(object sender, NewFrameEventArgs eventArgs) {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp; //UI frame = clone frame from stream

        }

        //UI part
        private void btnStart_Click(object sender, EventArgs e)
        {
            stream.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stream.Stop();
        }
    }
}
