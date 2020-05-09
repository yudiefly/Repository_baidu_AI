using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Utilities
{
	/// <summary>
	/// 获取访问BaiduAI的Token
	/// </summary>
    public class AccessToken
    {
		public static String getAccessToken(string clientId,string clientSecret)
		{
			if(!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret))
			{
				String authHost = "https://aip.baidubce.com/oauth/2.0/token";
				HttpClient client = new HttpClient();
				List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
				paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
				paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
				paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

				HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
				String result = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(result);
				return result;
			}
			else
			{
				return "ClientID_OR_ClientSecret_IS_NULL";
			}
			
		}		
	}
}
