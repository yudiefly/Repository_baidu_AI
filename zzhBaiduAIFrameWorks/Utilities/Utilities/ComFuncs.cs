using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilities
{
    /// <summary>
    /// 一些公用的方法
    /// </summary>
    public class ComFuncs
    {
        /// <summary>
        /// 将图片Base64编码
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static String getFileBase64(String fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
            return baser64;
        }
    }
}
