using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using DigitManager.ModelLibrary;
using TableDependency.SqlClient.Base.Enums;

namespace DigitManager.Web.Services.TableChangeService
{
    public class TableChangeBroadcastService : ITableChangeBroadcastService, IDisposable
    {
        //[Inject]
        //public NavigationManager NavigationManager { get; set; }

        private const string TableName = "SubDigits";
        private SqlTableDependency<SubDigit> _notifier;
        private IConfiguration _configuration;
        //private readonly IDigitService digitService;

        public event SubDigitChangeDelegate OnTwoDShortcutChanged;

        public TableChangeBroadcastService(IConfiguration configuration/*, IDigitService digitService*/)
        {
            _configuration = configuration;
            //this.digitService = digitService;

            // SqlTableDependency will trigger an event 
            // for any record change on monitored table

            _notifier = new SqlTableDependency<SubDigit>(
         _configuration.GetConnectionString("DigitManagerDBConnectionString"),
         TableName);
            _notifier.OnChanged += this.TableDependency_Changed;
            _notifier.Start();
        }

        // This method will notify the Blazor component about the stock price change stock
        private void TableDependency_Changed(object sender, RecordChangedEventArgs<SubDigit> e)
        {
            //IList<TwoDSource> twoDSources = db.TwoDSources.ToList();
            this.OnTwoDShortcutChanged(this, new SubDigitChangeChangeEventArgs(/*e.Entity, e.EntityOldValues, e.ChangeType*/));
        }

        // This method is used to populate the HTML view 
        // when it is rendered for the first time
        //public async Task<IList<SubDigit>> GetCurrentValues()
        //{
            
        //    _notifier.Start();
        //    var result = new List<SubDigit>();
        //    result = await digitService.GetAllDigit();

        //    #region Ado.Net Data Fetching

        //    //var result = await twoDSourceService.GetTwoDSources();

        //    //using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("TwoDManagerDBConnection")))
        //    //{
        //    //    sqlConnection.Open();

        //    //    using (var command = sqlConnection.CreateCommand())
        //    //    {
        //    //        command.CommandText = "SELECT * FROM " + TableName;
        //    //        command.CommandType = CommandType.Text;

        //    //        using (SqlDataReader reader = command.ExecuteReader())
        //    //        {
        //    //            if (reader.HasRows)
        //    //            {
        //    //                while (reader.Read())
        //    //                {
        //    //                    result.Add(new TwoDSource
        //    //                    {
        //    //                        TwoDNum = reader.GetString(reader.GetOrdinal("TwoDNum")),
        //    //                        AmoutnOfTwoNum = reader.GetInt32(reader.GetOrdinal("AmoutnOfTwoNum")),
        //    //                        TimeAMPM = (TimeAMPM)(reader.GetInt32(reader.GetOrdinal("TimeAMPM")))
        //    //                    });
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    #endregion

        //    return result;
        //}

        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }
}
