using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicalAPIWand
{
    public class HttpHelper
    {
        public async Task<RestResponse> SendAsync(string address, string url, string method, int mode, string input, object obj)
        {
            try
            { 
                var client = new RestClient(address);
                string data;
                try
                {
                    data = obj is IDictionary ? ReplaceTemplateWithDictionary(input, obj as IDictionary) : ReplaceTemplateWithObjectProperties(input, obj);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Convert Data with Tpl Is Error :" + ex.Message);
                }
                if (string.IsNullOrWhiteSpace(data))
                {
                    throw new ArgumentException("Convert Data with Tpl Is Null");
                }
                // 创建请求
                var request = new RestRequest(url, ConvertMethod(method));
                // 根据 mode 设置请求体
                switch (mode)
                {
                    case 1:
                        request.AddParameter("application/json", data, ParameterType.RequestBody);
                        break;
                    case 2:
                        var formData = JsonConvert.DeserializeObject(data) ?? throw new ArgumentException("Convert FormData Is Null");
                        AddObjectAsParameters(request, formData);
                        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                        break;
                    default:
                        throw new ArgumentException("Invalid mode. Use 1 for JSON or 2 for FormData.");
                }

                // 执行请求
                try
                {
                    return await client.ExecuteAsync(request);
                }
                catch (Exception ex)
                {
                    throw new Exception("Execute Error :" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Send Error :" + ex.Message);
            }
        }

        private void AddObjectAsParameters(RestRequest request, object obj)
        { 
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            { 
                var key = property.Name;
                var value = property.GetValue(obj);
                 
                if (value != null)
                {
                    request.AddParameter(key, value.ToString());
                }
            }
        }

        private Method ConvertMethod(string method)
        {
            return method switch
            {
                "GET" => Method.Get,
                "POST" => Method.Post,
                "PUT" => Method.Put,
                "DELETE" => Method.Delete,
                "PATCH" => Method.Patch,
                _ => throw new ArgumentException("Invalid Method"),
            };
        }

        public static string ReplaceTemplateWithDictionary(string template, IDictionary dict)
        {
            string pattern = @"\{\{(\w+)\}\}";
            return Regex.Replace(template, pattern, match =>
            {
                string key = match.Groups[1].Value;
                if (dict.Contains(key))
                {
                    return dict[key]?.ToString();
                }
                else
                {
                    return match.Value; // 如果键不存在，返回原占位符
                }
            });
        }

        public static string ReplaceTemplateWithObjectProperties(string template, object obj)
        {
            // 使用正则表达式匹配 {{...}} 形式的占位符
            string pattern = @"\{\{(\w+)\}\}";
            return Regex.Replace(template, pattern, match =>
            {
                // 获取占位符中的属性名
                string propertyName = match.Groups[1].Value;

                // 使用反射获取对象的属性值
                PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null && propertyInfo.CanRead)
                {
                    // 返回属性值（转换为字符串）
                    return propertyInfo.GetValue(obj)?.ToString();
                }
                else
                {
                    // 如果属性不存在，返回原占位符
                    return match.Value;
                }
            });
        }
    }
}
