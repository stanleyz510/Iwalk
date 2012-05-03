using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Era.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Service1 : IService1
    {
        public string DoWork(int time)
        {
            return "lxf say you " + time;
        }

        public CompositeType GetLoginbyNamePass(string name, string pass)
        {
            if(name == "admin" && pass=="admin")
            {
                return new CompositeType(){BoolValue=true,StringValue="Your are Administor."};
            }
            return new CompositeType() { BoolValue = false, StringValue = "Your are anyonous." };

        }
    }
}
