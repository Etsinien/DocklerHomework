using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter;

namespace DataProvider
{
    public interface IBaseDataProvider : INotifyPropertyChanged
    {
        /// <summary>
        /// Trigger data collection from the adapter set
        /// Note: currently the behavior is quite static: hardcoded reference to a single adapter
        /// </summary>
        /// <returns></returns>
        Task FetchDataAsync();

    }
}
