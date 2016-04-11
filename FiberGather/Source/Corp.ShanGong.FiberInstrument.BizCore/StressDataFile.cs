using System;
using System.IO;
using System.Linq;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Setting;
using log4net;
using log4net.Appender;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    public class StressDataFile
    {
        private const string FileNameFormatter = @"StressData{0}-{1}-{2}.txt";
//        public static void Save(string content)
//        {
//            TransmitSaveFilePath();
//            _loger.Info(content);
//        }

        private static readonly ILog _loger = LogManager.GetLogger("StressDataFileAppender");

        public static void ResetSaveDataLocalPath()
        {
            var repository = LogManager.GetRepository();
            var appenders = repository.GetAppenders();
            var targetAppender = appenders.First(p => p.Name == "StressDataFileAppender") as RollingFileAppender;
            if (targetAppender != null)
            {
                targetAppender.File = Path.Combine(GlobalSetting.Instance.DataFileLocalPath,
                    GlobalSetting.Instance.CurrentSaveDate.ToFilePathString());
                targetAppender.ActivateOptions();
            }
            var appends = _loger.Logger.Repository.GetAppenders();
        }

        public static void TransmitSaveFilePath()
        {
            if (DateTime.Now.Year != GlobalSetting.Instance.CurrentSaveDate.Year ||
                DateTime.Now.Month != GlobalSetting.Instance.CurrentSaveDate.Month ||
                DateTime.Now.Day != GlobalSetting.Instance.CurrentSaveDate.Day)
            {
                GlobalSetting.Instance.CurrentSaveDate = DateTime.Now;
            }
        }

        public static void SaveByChannel(string content, int channel)
        {
            if (DateTime.Now.Year != GlobalSetting.Instance.CurrentSaveDate.Year ||
                DateTime.Now.Month != GlobalSetting.Instance.CurrentSaveDate.Month ||
                DateTime.Now.Day != GlobalSetting.Instance.CurrentSaveDate.Day)
            {
                GlobalSetting.Instance.CurrentSaveDate = DateTime.Now;
            }
            var path = Path.Combine(GlobalSetting.Instance.DataFileLocalPath, "结构应力与温度",
                GlobalSetting.Instance.CurrentSaveDate.ToFilePathString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
//            path = Path.Combine(path,
//                string.Format("StressData{0}-{1}-{2}.txt", channel.ToString().PadLeft(2, '0'), DateTime.Now.Hour,
//                    DateTime.Now.Minute));
            path = Path.Combine(path,
                string.Format("StressData{0}-{1}.txt", channel.ToString().PadLeft(2, '0'), DateTime.Now.Hour));
            if (!File.Exists(path))
            {
                using (var stream = File.Create(path))
                {
                    stream.Close();
                }
            }
            File.AppendAllText(path, content);
        }
    }
}