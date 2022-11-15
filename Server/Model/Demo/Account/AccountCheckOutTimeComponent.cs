using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Session))]
    public class AccountCheckOutTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long AccountId;
        public long Timer;
    }
}
