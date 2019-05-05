﻿using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class Logic
    {

        RestClient restClient = new RestClient("http://localhost:8080");

        public ClientResponseDTO[] GetAllClients()
        {
            String response = Get("http://localhost:8080/client/");
            ClientResponseDTO[] mappedObject = Deserialize<ClientResponseDTO[]>(response);
            return mappedObject;
        }

        public ClientResponseDTO GetClientWithId(String clientId)
        {
            String response = Get("http://localhost:8080/client/" + clientId);
            ClientResponseDTO mappedObject = Deserialize<ClientResponseDTO>(response);
            return mappedObject;
        }

        public DeviceResponseDTO[] GetAllDevices()
        {
            String response = Get("http://localhost:8080/device/");
            DeviceResponseDTO[] mappedObject = Deserialize<DeviceResponseDTO[]>(response);
            return mappedObject;
        }

        public DeviceResponseDTO GetDeviceWithId(String deviceId)
        {
            String response = Get("http://localhost:8080/device/" + deviceId);
            DeviceResponseDTO mappedObject = Deserialize<DeviceResponseDTO>(response);
            return mappedObject;
        }

        public OrderResponseDTO[] GetAllOrders()
        {
            String response = Get("http://localhost:8080/order/");
            OrderResponseDTO[] mappedObject = Deserialize<OrderResponseDTO[]>(response);
            return mappedObject;
        }

        public OrderResponseDTO GetOrderWithId(String orderId)
        {
            String response = Get("http://localhost:8080/order/" + orderId);
            OrderResponseDTO mappedObject = Deserialize<OrderResponseDTO>(response);
            return mappedObject;
        }

        public static T Deserialize<T>(string json)
        {
            Newtonsoft.Json.JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

        
        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


 

        public IRestResponse Post(object requestObject, String url)
        {
            string json = JsonConvert.SerializeObject(requestObject);
            RestRequest request = new RestRequest(url, Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept", "application/json");
            request.AddJsonBody(json);
            IRestResponse response = this.restClient.Execute(request);
            return response;
        }

    }
}
