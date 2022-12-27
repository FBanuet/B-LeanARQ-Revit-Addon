using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace BLEANarq.InternalClasses
{
    public  class DoorAPIcs
    {
        public static bool useCloudServer = false;

        const string baseUrlLocal = "http://localhost:8000/";
        const string baseUrlCloud = "https://mongoRevit.herokuapp.com/";

        public static string RestAPIBaseUrl
        {
            get { return useCloudServer ? baseUrlCloud : baseUrlLocal; }
        }

        public static List<DoorClass> Get(string collectionName)
        {
            RestClient restClient = new RestClient(RestAPIBaseUrl);
            RestRequest request = new RestRequest("/api" + "/" + collectionName, Method.Get);

            RestResponse<List<DoorClass>> response = restClient.Execute<List<DoorClass>>(request);

            return response.Data;
        }

        public static HttpStatusCode PostBatch(out string content, out string errorMessage, string collectionName,
            List<DoorClass> doorData)
        {
            RestClient cLient = new RestClient(RestAPIBaseUrl);
            RestRequest request = new RestRequest("/api" + "/" + collectionName + "/" + "batch", Method.Post );
            request.RequestFormat = DataFormat.Json;
            request.AddBody(doorData);

            RestResponse response = cLient.Execute(request);
            content = response.Content;
            errorMessage = response.ErrorMessage;
            return response.StatusCode;

        } 

        
    }
}
