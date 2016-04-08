using System;

namespace Corp.ShanGong.FiberInstrument.Common
{
    public class BoundaryException : Exception
    {
        public BoundaryException(Exception ex)
        {
            if (ex != null)
            {
                Display = ex.Message;
                DetailInfo = ex.ToString();
                SourceException = ex;
            }
        }

        public BoundaryException(string dispaly)
        {
            Display = dispaly;
        }

        public BoundaryException(string display, Exception source)
        {
            Display = display;
            SourceException = source;
        }

        public string Display
        {
            get;
            set;
        }

        public string DetailInfo
        {
            get;
            private set;
        }

        public Exception SourceException
        {
            get;
            set;
        }
    }
}