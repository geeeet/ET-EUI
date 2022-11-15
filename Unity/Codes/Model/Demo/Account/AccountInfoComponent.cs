using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class AccountInfoComponent : Entity, IAwake, IDestroy
    {
        private string token;
        private long accountId;

        public string Token { get => token; set => token = value; }
        public long AccountId { get => accountId; set => accountId = value; }
    }


}
