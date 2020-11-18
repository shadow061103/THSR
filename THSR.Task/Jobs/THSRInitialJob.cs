using System;
using System.ComponentModel;
using Hangfire.Console;
using Hangfire.Server;
using THSR.Service.Interface;
using THSR.Task.Interfaces;

namespace THSR.Task.Jobs
{
    /// <summary>
    /// 初始化高鐵資料Job
    /// </summary>
    /// <seealso cref="THSR.Task.Interfaces.ITHSRInitialJob"/>
    public class THSRInitialJob : ITHSRInitialJob
    {
        private IStationService _stationService;

        private IFareService _fareService;

        public THSRInitialJob(IStationService stationService, IFareService fareService)
        {
            _stationService = stationService;
            _fareService = fareService;
        }

        /// <summary>
        /// 排程工作 資料表初始建立資料
        /// </summary>
        /// <param name="context">The context.</param>
        [DisplayName("排程工作 資料表初始建立資料")]
        public async System.Threading.Tasks.Task DataBaseDataInitialCreate(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now} Start Run InsertStation Job");

            await _stationService.InsertAsync();

            await _fareService.InsertASync();

            context.WriteLine($"{DateTime.Now} End Run InsertStation Job");
        }
    }
}