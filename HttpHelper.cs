﻿using Newtonsoft.Json;
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

        public async Task<RestResponse> SendAsync(string address, string url, string method, int mode, string input, Dictionary<string, string> formdata)
        {
            try
            { 
                var client = new RestClient(address);
                string data = ""; 
                // 创建请求
                var request = new RestRequest(url, ConvertMethod(method));
                // 根据 mode 设置请求体
                switch (mode)
                {
                    case 1:
                        request.AddParameter("application/json", data, ParameterType.RequestBody);
                        break;
                    case 2: 
                        AddObjectAsDic(request, formdata);
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

        public static Dictionary<string, string> ConvertFormData(object obj, Dictionary<string, string> formdata)
        {
            if (formdata != null && formdata.Count > 0)
            {
                var dic = new Dictionary<string, string>();
                foreach (var item in formdata)
                {
                    dic.Add(item.Key, obj is IDictionary ? ReplaceTemplateWithDictionary(item.Value, obj as IDictionary) : ReplaceTemplateWithObjectProperties(item.Value, obj)); 
                }

                return dic;
            }

            return formdata;
        }

        public static string ConvertFormData(string input, object obj)
        {
            if (obj != null && !string.IsNullOrWhiteSpace(input))
            {
                return obj is IDictionary ? ReplaceTemplateWithDictionary(input, obj as IDictionary) : ReplaceTemplateWithObjectProperties(input, obj);
            }

            return input;
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
        private void AddObjectAsDic(RestRequest request, Dictionary<string, string> obj)
        { 
            foreach (var property in obj)
            {
                var key = property.Key;
                var value = property.Value;

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
            if (obj == null)
            {
                return template;
            }
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
