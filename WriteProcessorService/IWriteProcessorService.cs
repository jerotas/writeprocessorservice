using System.ServiceModel;
using System.ServiceModel.Web;
using SharedModels;

namespace WriteProcessorService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWriteProcessorService" in both code and config file together.
    [ServiceContract]
    public interface IWriteProcessorService {
        [OperationContract]
        [WebGet]
        string Hello();

        [OperationContract]
        [WebGet(UriTemplate = "GetData/{value}")]
        string GetData(string value);

        [OperationContract]
        [WebInvoke]
        string PostMemberChange(Member memberChangeEvent);
    }
}
