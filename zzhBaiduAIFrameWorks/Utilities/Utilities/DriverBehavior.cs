using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Utilities
{
    /// <summary>
    /// 驾驶员行为分析
    /// </summary>
    public class DriverBehavior
    {
        /// <summary>
        /// 驾驶员行为分析
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static string driver_behavior(string token,string driveFileName)
        {           
            string host = "https://aip.baidubce.com/rest/2.0/image-classify/v1/driver_behavior?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            // 图片的base64编码
            string base64 = ComFuncs.getFileBase64(driveFileName);
            String str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            Console.WriteLine("驾驶行为分析:");
            Console.WriteLine(result);
            return result;
        }
        /// <summary>
        /// 获取驾驶员行为
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driveFileName"></param>
        /// <returns></returns>
        public static DriverBehaviorReponse getDriverBehavior(string token, string driveFileName)
        {
            var strResponse = driver_behavior(token, driveFileName);
            try
            {
                var result= JsonUtil.Deserialize<DriverBehaviorReponse>(strResponse);
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine("getDriverBehavior:{0}", ex.Message);
                return null;
            }
        }       
    }

    public class DriverBehaviorReponse
    {
        /// <summary>
        /// 驾驶员数量 
        /// </summary>
        public int person_num { set; get; }
        /// <summary>
        /// 行为属性值
        /// 驾驶员的属性行为信息；
        /// 若未检测到驾驶员，则该项为[]
        /// </summary>
        public List<PersonInfo> person_info { set; get; }
        /// <summary>
        /// id（调用？日志？）
        /// </summary>
        public long log_id { set; get; }
    }
    /// <summary>
    /// 驾驶员行为
    /// </summary>
    public class PersonInfo
    {
        /// <summary>
        /// 行为属性
        /// </summary>
        public Attributes attributes { set; get; }
        /// <summary>
        /// 检测出驾驶员的位置
        /// </summary>
        public Location location { set; get; }        
    }

    public class Attributes
    {
        /// <summary>
        /// 打电话
        /// </summary>
        public Behavior cellphone { set; get; }
        /// <summary>
        /// 打哈欠，实际应用时，可结合闭眼综合判断疲劳，避免普通张嘴、说话等情况下被误判
        /// </summary>
        public Behavior yawning { set; get; }

        public Behavior not_buckling_up { set; get; }
        /// <summary>
        /// 未正确佩戴口罩，包含戴了口罩、但口鼻外露这类未戴好的情况
        /// </summary>
        public Behavior no_face_mask { set; get; }
        /// <summary>
        /// 双手离开方向盘
        /// </summary>
        public Behavior both_hands_leaving_wheel { set; get; }
        /// <summary>
        /// 闭眼，实际应用时，可结合打哈欠综合判断疲劳，避免正常眨眼等情况下被误判
        /// </summary>
        public Behavior eyes_closed { set; get; }
        /// <summary>
        /// 低头，实际应用时，可结合闭眼、视角未朝前方综合判断分心、疲劳，避免单一属性引起误判
        /// </summary>
        public Behavior head_lowered { set; get; }
        /// <summary>
        /// 吸烟
        /// </summary>
        public Behavior smoke { set; get; }
        /// <summary>
        /// 视角未朝前方
        /// </summary>
        public Behavior not_facing_front { set; get; }
    }
    /// <summary>
    /// 行为
    /// </summary>
    public class Behavior
    {
        /// <summary>
        /// 建议阈值，仅作为参考，实际应用中根据测试情况选取合适的score阈值即可
        /// </summary>
        public float threshold { set; get; }
        /// <summary>
        ///对应概率分数
        /// </summary>
        public double score { set; get; }
    }
    /// <summary>
    /// 位置
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 检测区域宽度
        /// </summary>
        public int width { set; get; }
        /// <summary>
        /// 检测区域在原图的上起开始位置
        /// </summary>
        public int top { set; get; }
        /// <summary>
        /// 对应概率分数
        /// </summary>
        public double score { set; get; }
        /// <summary>
        /// 检测区域在原图的左起开始位置
        /// </summary>
        public int left { set; get; }
        /// <summary>
        /// 检测区域高度
        /// </summary>
        public int height { set; get; }
    }
}
