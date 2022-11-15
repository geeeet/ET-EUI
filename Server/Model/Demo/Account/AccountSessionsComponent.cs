using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class AccountSessionsComponent : Entity, IAwake, IDestroy
    {
        private Dictionary<long, long> accountSessionDic = new Dictionary<long, long>();

        public Dictionary<long, long> AccountSessionDic { get => accountSessionDic; set => accountSessionDic = value; }
    }
}
