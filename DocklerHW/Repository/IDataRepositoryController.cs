using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataRepositoryController
    {
        bool HasData();
        IDataRepository GetData();
        void FlushRepository();
        void SetData(IDataRepository data);

    }
}
