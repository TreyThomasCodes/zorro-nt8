using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTraderAddOnProject
{
    [ServiceContract]
    interface IZorroService
    {
        [OperationContract]
        string SayHello(string name);
    }
}
