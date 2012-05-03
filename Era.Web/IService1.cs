using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Era.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string DoWork(int time);

        [OperationContract]
        CompositeType GetLoginbyNamePass(string name, string pass);
    }
    [DataContract]
    public class CompositeType
    {
        [DataMember]
        public bool BoolValue { get; set; }
        [DataMember]

        public string StringValue { get; set; }
    }
}
