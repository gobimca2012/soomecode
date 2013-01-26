﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;

namespace AliHelper
{
    class FileUtils
    {
        public static string GetAppDataFolder()
        {
            string AppDataFolder = Environment.CurrentDirectory;
            if (!Directory.Exists(AppDataFolder))
            {
                Directory.CreateDirectory(AppDataFolder);
            }
            return AppDataFolder;
        }

        public static string GetImageFolder()
        {
            string imageDir = Environment.CurrentDirectory + Path.DirectorySeparatorChar + Constants.IMAGE_DIR;
            if (!Directory.Exists(imageDir))
            {
                Directory.CreateDirectory(imageDir);
            }
            return imageDir;
        }

        public static System.Drawing.Image GetImage(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            return result;
        } 

        public static string DownloadImage(WebClient webClient, string url, int id)
        {
            string imageFile = FileUtils.GetImageFolder() + Path.DirectorySeparatorChar + id + ".jpg";
            if (File.Exists(imageFile))
            {
                return imageFile;
            }
            webClient.DownloadFile(url, imageFile);
            return imageFile;
        }

        /*
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string IniReadValue(string Section, string Key, string filePath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filePath);
            return temp.ToString();
        }
        public static void IniWriteValue(string Section, string Key, string val, string filePath)
        {
            WritePrivateProfileString(Section, Key, val, filePath);
        }
        */
    }
}
