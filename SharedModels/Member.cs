using System.Runtime.Serialization;

namespace SharedModels {
    [DataContract]
    public class Member {
        [DataMember]
        public string MiddleInitial { get; set; }
        [DataMember]
        public int MemberSourceKey { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public int GroupSourceKey { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
