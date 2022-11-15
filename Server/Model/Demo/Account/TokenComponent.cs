using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class TokenComponent : Entity, IAwake
    {
        private readonly Dictionary<long, string> tokenDic = new Dictionary<long, string>();

        public Dictionary<long, string> TokenDic => tokenDic;
    }
}
