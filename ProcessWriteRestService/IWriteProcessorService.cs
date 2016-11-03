using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ProcessWriteRestService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWriteProcessorService" in both code and config file together.
    [ServiceContract]
    public interface IWriteProcessorService {

        [OperationContract]
        [WebGet]
        string GetData(int value);

        [OperationContract]
        [WebGet(UriTemplate = "/GetData/{value}")]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType {
        [DataMember]
        public bool BoolValue { get; set; } = true;

        [DataMember]
        public string StringValue { get; set; } = "Hello ";
    }
}
