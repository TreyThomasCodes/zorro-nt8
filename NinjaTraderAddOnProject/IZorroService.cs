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

        [OperationContract]
        [WebGet(UriTemplate = "accounts", ResponseFormat = WebMessageFormat.Json)]
        string[] GetAccountList();

        [OperationContract]
        [WebGet(UriTemplate = "verify?c={accountName}&t={accountType}", ResponseFormat = WebMessageFormat.Json)]
        bool Verify(string accountName, string accountType);

        [OperationContract]
        [WebGet(UriTemplate = "status", ResponseFormat = WebMessageFormat.Json)]
        StatusDTO Status();
    }
}
