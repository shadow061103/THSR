using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using THSR.Repository.Infrastructure.Helpers;
using THSR.Repository.Interfaces;
using THSR.Repository.Models;

namespace THSR.Repository.Implements
{
    public class StationRepository : IStationRepository
    {
        public async Task<List<RailStation>> GetStation()
        {
            string APPID = "XXX";
            string APPKey = "XXX";

            //取得當下UTC時間
            string xdate = DateTime.Now.ToUniversalTime().ToString("r");
            string SignDate = "x-date: " + xdate;
            //取得加密簽章
            string Signature = HMACHelper.Signature(SignDate, APPKey);
            string sAuth = "hmac username=\"" + APPID + "\", algorithm=\"hmac-sha1\", headers=\"x-date\", signature=\"" + Signature + "\"";

            List<RailStation> Data = new List<RailStation>();
            //欲呼叫之API網址(此範例為台鐵車站資料)
            var APIUrl = "https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/Station?$top=30&$format=JSON";
            string Result = string.Empty;

            using (HttpClient Client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
            {
                Client.DefaultRequestHeaders.Add("Authorization", sAuth);
                Client.DefaultRequestHeaders.Add("x-date", xdate);
                Result = await Client.GetStringAsync(APIUrl);
            }

            Data = JsonConvert.DeserializeObject<List<RailStation>>(Result);
            return Data;
        }
    }
}