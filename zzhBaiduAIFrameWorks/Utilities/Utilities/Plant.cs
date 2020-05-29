using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Utilities.Model;

namespace Utilities
{
    /// <summary>
    /// 植物识别
    /// </summary>
    public class Plant
    {
        private static string plant(string token, string plantFileName)
        {

            string host = "https://aip.baidubce.com/rest/2.0/image-classify/v1/plant?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = ComFuncs.getFileBase64(plantFileName);
            String str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("植物识别:");
            Console.WriteLine(result);
            return result;
        }
        /// <summary>
        /// 植物识别
        /// </summary>
        /// <param name="token"></param>
        /// <param name="plantFileName"></param>
        /// <returns></returns>
        public PlantResult getPlant(string token, string plantFileName)
        {
            var strResponse = plant(token, plantFileName);
            try
            {
                var result = JsonUtil.Deserialize<PlantResult>(strResponse);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("getPlant:{0}", ex.Message);
                return null;
            }
        }
    }

    /*
     参数	        类型	            是否必须	说明
    log_id	        uint64	                是	    唯一的log id，用于问题定位
    result	        arrry(object)	        是	    植物识别结果数组
    +name	        string	                是	    植物名称，示例：吉娃莲
    +score	        uint32	                是	    置信度，示例：0.5321
    +baike_info	    object	                否	    对应识别结果的百科词条名称
    ++baike_url	    string	                否	    对应识别结果百度百科页面链接
    ++image_url	    string	                否	    对应识别结果百科图片链接
    ++description	string	                否	    对应识别结果百科内容描述 
     */

    public class PlantResult
    {
        /// <summary>
        /// 唯一的log id，用于问题定位
        /// </summary>
        public UInt64 log_id { set; get; }
        /// <summary>
        /// 植物识别结果数组
        /// </summary>
        public List<BaiKeEntity> result { set; get; }
    }   
}
