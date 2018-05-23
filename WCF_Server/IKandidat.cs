using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKandidat" in both code and config file together.
    [ServiceContract]
    public interface IKandidat
    {
        [OperationContract]
        List<KandidatInfo> ShowKandidat();

        [OperationContract]
        bool validateUser(string ID);

        [OperationContract]
        int doVote(VoteInfo suara);
    }
}
