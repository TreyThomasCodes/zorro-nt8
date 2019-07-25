using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace NT8ZorroBridge
{
    [ServiceContract]
    public interface IZorroService
    {
        [OperationContract]
        [WebGet(UriTemplate = "hello?name={name}", ResponseFormat = WebMessageFormat.Json)]
        string SayHello(string name);
    }
}
