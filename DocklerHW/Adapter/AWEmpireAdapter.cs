using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    /// <summary>
    /// Domain specific adapter which:
    ///     - pulls data from external source ( trough REST API )
    ///     - stores the data in the internal domain specific repository
    /// </summary>
    public class AWEmpireAdapter : IRestApiAdapter
    {
        HttpClient m_httpClient;
        private IDataRepositoryController m_DataRepository;
        private bool m_HasNewData = false;

        public AWEmpireAdapter()
        {
            m_httpClient = new HttpClient();
            m_DataRepository = new AWEmpireDataRepositoryController();
            // Data specific adapter, no need to change the request header
            m_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public bool HasNewData => m_HasNewData;

        /// <summary>
        /// Access to the data repository
        /// </summary>
        /// <returns>Data repository</returns>
        public IDataRepository GetData()
        {
            return m_DataRepository.GetData();
        }

        /// <summary>
        /// Collects data from external source given by the caller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task GetNewDataAsync(string request)
        {
            m_HasNewData = false;
            using (HttpResponseMessage responseMessage = await m_httpClient.GetAsync(request))
            {
                if(responseMessage.IsSuccessStatusCode)
                {
                    AWEmpireDataRepository aweData = await responseMessage.Content.ReadAsAsync<AWEmpireDataRepository>();
                    m_DataRepository.SetData(aweData);
                    m_HasNewData = true;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
                    
            };
            
        }
    }
}
