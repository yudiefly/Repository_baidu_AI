using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Model
{
    public class BaiKeEntity
    {
        /// <summary>
        /// 名称，示例：吉娃莲
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 置信度，示例：0.5321
        /// </summary>
        public UInt32 score { set; get; }
        /// <summary>
        /// 对应的百科词条
        /// </summary>
        public BaikeInfo baike_info { set; get; }
    }
    public class BaikeInfo
    {
        /// <summary>
        /// 对应识别结果百度百科页面链接
        /// </summary>
        public string baike_url { set; get; }
        /// <summary>
        /// 对应识别结果百科图片链接
        /// </summary>
        public string image_url { set; get; }
        /// <summary>
        /// 对应识别结果百科内容描述
        /// </summary>
        public string description { set; get; }
    }
}
