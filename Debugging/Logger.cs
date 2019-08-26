using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    class Logger
    {
        public static Logger DEFLOG = new Logger("default.log");
        public static Logger ERRORS = new Logger("errors.log");

        private string path;
        private StringBuilder builder;

        static public void Write(string file, string message)
        {
            File.AppendAllText(file, DateTime.Now.ToString() + ": " + message);
        }

        public Logger(string logPath)
        {
            builder = new StringBuilder();
            path = logPath;
            File.Delete(path);
        }

        public Logger(string logPath, string title) : this(logPath)
        {
            WriteLog(title);
        }

        public Logger(string logPath, params Object[] startParams) : this(logPath)
        {
            var parString = "";
            foreach (var p in startParams) parString += p.ToString();
            WriteLog(parString);
        }

        public void WriteLog(string log)
        {
            builder.Append(DateTime.Now.ToString());
            builder.Append(": ");
            builder.Append(log);
            builder.Append("\r\n");
        }

        public void WriteLogFreq(FreqPoint freq)
        {
            WriteLog(String.Format("Freq is {0}, X is: {1}, Y is: {2}", freq.Freq, freq.Coords.Real, freq.Coords.Imaginary));
        }

        public void Flush()
        {
            File.AppendAllText(path, builder.ToString());
        }
    }
}
