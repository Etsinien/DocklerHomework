using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Adapter
{
    /// <summary>
    /// Acces to external resources trough REST API protocol
    /// Each adapter has its own data repository with IDataElement
    /// </summary>
    public interface IRestApiAdapter
    {
        /// <summary>
        /// Is updated if data is available after response from server side
        /// </summary>
        bool HasNewData { get; }

        /// <summary>
        /// Requests new data via a specific link
        /// </summary>
        /// <param name="request">request string to external resource</param>
        /// <returns></returns>
        Task GetNewDataAsync(string request);

        /// <summary>
        /// Acces to the data stored in the repository attached to the adapter
        /// </summary>
        /// <returns>Data available</returns>
        IDataRepository GetData();
    }
}
