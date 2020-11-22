using System;
using System.Windows.Forms;

namespace NRatings.Client.GUI
{
    public partial class LogBox : UserControl
    {

        private bool mScrollToLast = false;

        public bool ScrollToLast
        {
            get { return this.mScrollToLast; }
            set { this.mScrollToLast = value; }
        }
        
        public LogBox()
        {
            InitializeComponent();
        }



        public void WriteToLog(string text, bool withTimestamp)
        {
            DateTime d = DateTime.Now;

            if (withTimestamp == true)
                this.AddLine(d.ToString("HH:mm:ss") + ": " + text); 
            else
                this.AddLine(text);

            if (this.mScrollToLast == true)
            {
                this.rtxtLog.SelectionStart = rtxtLog.TextLength;
                this.rtxtLog.Focus();
                this.rtxtLog.ScrollToCaret();
            }



        }

        public void ClearLog()
        {
            this.rtxtLog.Clear();
        }

        public void AddLine(string line)
        {
            this.rtxtLog.Text += line + Environment.NewLine;
        }

    }
}
