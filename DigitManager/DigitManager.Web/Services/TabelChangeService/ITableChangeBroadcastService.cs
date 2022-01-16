using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient.Base.Enums;
using DigitManager.ModelLibrary;

namespace DigitManager.Web.Services.TableChangeService
{
    public delegate void SubDigitChangeDelegate(object sender, SubDigitChangeChangeEventArgs args);

    public class SubDigitChangeChangeEventArgs : EventArgs
    {
        //public SubDigit NewValue { get; }
        //public SubDigit OldValue { get; }
        //public ChangeType ChangeType { get; set; }

        public SubDigitChangeChangeEventArgs(/*SubDigit newValue, SubDigit oldValue, ChangeType changeType*/)
        {
            //this.NewValue = newValue;
            //this.OldValue = oldValue;
            //this.ChangeType = changeType;
        }
    }

    public interface ITableChangeBroadcastService
    {
        event SubDigitChangeDelegate OnTwoDShortcutChanged;
        //Task<IList<SubDigit>> GetCurrentValues();
    }
}
