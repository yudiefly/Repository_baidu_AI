using System;
using Utilities;

namespace UtilitiesAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var token = AccessToken.getAccessToken("", "");
            if(token== "ClientID_OR_ClientSecret_IS_NULL")
            {
                Console.WriteLine("获取Token错误，应用ID与Secret值不能为空！");
            }
            Console.Read();
        }
    }
}
