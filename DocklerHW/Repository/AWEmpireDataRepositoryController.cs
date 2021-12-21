using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AWEmpireDataRepositoryController : IDataRepositoryController
    {
        private IDataRepository m_AweRespository = new AWEmpireDataRepository();

        /// <summary>
        /// Empties repository
        /// </summary>
        public void FlushRepository()
        {
            m_AweRespository = null;
            m_AweRespository = new AWEmpireDataRepository();
        }

        /// <summary>
        /// Expose repository to the caller
        /// </summary>
        /// <returns></returns>
        public IDataRepository GetData()
        {
            return m_AweRespository;
        }

        /// <summary>
        /// Check for data availability
        /// </summary>
        /// <returns></returns>
        public bool HasData()
        {
            return m_AweRespository.HasData();
        }

        /// <summary>
        /// Store data in the repository
        /// </summary>
        /// <param name="data"></param>
        public void SetData(IDataRepository data)
        {
            if (m_AweRespository.HasData())
                FlushRepository();

            m_AweRespository = data;
        }
    }
}
