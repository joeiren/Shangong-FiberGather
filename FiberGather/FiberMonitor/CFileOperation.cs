using System;
using System.Collections.Generic;
using System.IO;

namespace FiberMonitor
{
    /// <summary>
    ///     文件操作
    /// </summary>
    public class CFileOperation
    {
        /// <summary>
        ///     磁盘空间最小值默认限定50MB
        /// </summary>
        public double dDiskFreeSpaceLimit = 50.00;

        /// <summary>
        ///     最后一次创建文件的时间
        /// </summary>
        private DateTime dtLastCreateFileTime;

        /// <summary>
        ///     同步读写操作
        /// </summary>
        private FileStream fs;

        /// <summary>
        ///     保存在本地文件的时长
        /// </summary>
        private TimeSpan saveFileTimeSpan;

        /// <summary>
        ///     根目录到具体文件之前的路径
        /// </summary>
        private string strDirPath;

        /// <summary>
        ///     文件目录 :如D:,E:
        /// </summary>
        private string strFileDirectory;

        /// <summary>
        ///     根文件夹名称
        /// </summary>
        private string strFileFolderName;

        /// <summary>
        ///     文件名
        /// </summary>
        private string striFileName;

        /// <summary>
        ///     文件写操作对象
        /// </summary>
        private StreamWriter sw;

        /// <summary>
        ///     本地数据参数保存函数
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="fileDirectory">文件路径</param>
        /// <param name="accessFileTimeSpan"></param>
        /// <param name="filespace"></param>
        /// <param name="filetype"></param>
        public void SetSaveParam(string strFileName, string strFileDirectory, TimeSpan saveFileTimeSpan,
            double dDiskFreeSpaceLimit, string strFileFolderName)
        {
            striFileName = strFileName;
            this.strFileDirectory = strFileDirectory;
            this.saveFileTimeSpan = saveFileTimeSpan;
            this.dDiskFreeSpaceLimit = dDiskFreeSpaceLimit;
            this.strFileFolderName = strFileFolderName;
        }

        /// <summary>
        ///     根据盘符获取磁盘空间
        /// </summary>
        /// <param name="strDiskName"></param>
        /// <returns></returns>
        public double GetDiskFreeSpace(string strDiskName)
        {
            var diDisk = new DriveInfo(strDiskName);
            double dFreeSpace = diDisk.TotalFreeSpace;
            dFreeSpace = dFreeSpace/1024/1024;
            dFreeSpace = Math.Round(dFreeSpace, 4, MidpointRounding.AwayFromZero);
            return dFreeSpace;
        }

        /// <summary>
        ///     判断磁盘空间是否在规定范围内
        /// </summary>
        /// <param name="strDiskName"></param>
        /// <returns></returns>
        public bool CheckDiskFreeSpace(string strDiskName)
        {
            var dDiskFreeSpace = GetDiskFreeSpace(strDiskName);
            if (dDiskFreeSpace < dDiskFreeSpaceLimit)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     创建目录
        /// </summary>
        /// <param name="strFileDir"></param>
        /// <param name="strFileType"></param>
        /// <returns>true：创建成功；false：创建失败</returns>
        //public bool CreateFileFolder(ref string strFileDir, string strFileType)
        public bool CreateFileFolder()
        {
            var bFlag = false;
            try
            {
                var tempStr = Directory.GetDirectoryRoot(strFileDirectory);
                if (CheckDiskFreeSpace(tempStr.Substring(0, 1)))
                {
                    ////strFileDir = strFileDir + "\\" + strFileType + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd");
                    ////if (!Directory.Exists(strFileDir))
                    ////{
                    ////    Directory.CreateDirectory(strFileDir);
                    ////    bFlag = true;
                    ////}
                    strDirPath = strFileDirectory + "\\" + strFileFolderName + "\\" + DateTime.Now.ToString("yyyy") +
                                 "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd");
                    if (!Directory.Exists(strDirPath))
                    {
                        Directory.CreateDirectory(strDirPath);
                    }
                }
            }
            catch (Exception ex)
            {
                bFlag = false;
                Console.WriteLine("CreateFileFolder.Error: " + ex.Message);
            }
            return bFlag;
        }

        /// <summary>
        ///     创建文件
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="strFilePath"></param>
        /// <param name="strFileType"></param>
        /// <returns>true：创建成功；false：创建失败</returns>
        //public bool CreateFile(string strFileName,ref string strFilePath, string strFileType)
        private bool CreateFile()
        {
            var bFlag = false;
            try
            {
                //strFilePath = strFilePath + @"\" + strFileName + "_" + DateTime.Now.ToString("HH-mm") + strFileType;///默认txt
                //if (File.Exists(strFilePath))
                //{
                //    //File.Create(strFilePath);
                //    File.Delete(strFilePath);
                //}
                ////File.Create(strFilePath);
                //fs = new FileStream(strFilePath, FileMode.CreateNew);
                //StreamWriter sw = new StreamWriter(fs);
                var filePath = strDirPath + @"\" + striFileName + "-" + DateTime.Now.ToString("HH-mm") + ".txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var fs = new FileStream(filePath, FileMode.CreateNew);
                sw = new StreamWriter(fs);
            }
            catch (IOException ex)
            {
                bFlag = false;
                Console.WriteLine("CreateFile.Error: " + ex.Message);
            }
            return bFlag;
        }

        /// <summary>
        ///     写入文件夹
        /// </summary>
        /// <param name="listData"></param>
        /// <returns>true：写入成功；false：写入失败</returns>
        public bool WriteToFile(List<float[]> listData, int iNum, int iSaveLevel)
        {
            var bFlag = true; //先屏蔽写入
            //if (iNum > 0)
            //{
            //    string strLevel = "F0";
            //    if (iSaveLevel == 0)
            //    {
            //        strLevel = "F0";
            //    }
            //    else if (iSaveLevel == 1)
            //    {
            //        strLevel = "F1";
            //    }
            //    else if (iSaveLevel == 2)
            //    {
            //        strLevel = "F2";
            //    }
            //    else if (iSaveLevel == 3)
            //    {
            //        strLevel = "F3";
            //    }
            //    else if (iSaveLevel == 4)
            //    {
            //        strLevel = "F4";
            //    }

            //    try
            //    {
            //        if (sw == null || ((dtLastCreateFileTime + saveFileTimeSpan) < DateTime.Now))
            //        {
            //            if (sw != null)
            //            {
            //                sw.Close();
            //            }
            //            CreateFileFolder();
            //            CreateFile();
            //            dtLastCreateFileTime = DateTime.Now;
            //        }
            //        if (listData.Count > 0 && listData[0].Length > 0)
            //        {
            //            for (int i = 0; i < listData[0].Length; i++)
            //            {
            //                ///输出时间
            //                sw.Write(DateTime.Now.ToString("yyyy\tMM\tdd\tHH\tmm\tss\t"));
            //                ///输出数据
            //                for (int j = 0; j < listData.Count; j++)
            //                {
            //                    sw.Write("{0}\t", listData[j][i].ToString(strLevel));
            //                }
            //                sw.WriteLine();
            //            }

            //        }
            //        ///清空缓冲区内容，并把缓冲区内容写入基础流
            //        sw.Flush();
            //        ///关闭数据流
            //        //sw.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        bFlag = false;
            //        Console.WriteLine("WriteToFile.Error: " + ex.Message);
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            return bFlag;
        }

        /// <summary>
        ///     关闭文件流
        /// </summary>
        public void CloseFileStream()
        {
            if (sw != null)
            {
                //sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }
    }
}