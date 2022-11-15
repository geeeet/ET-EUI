using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class TokenComponentSystem
    {
        public static void Add(this TokenComponent self, long key, string token)
        {
            self.TokenDic.Add(key, token);
            self.TimeOutRemoveKey(key, token).Coroutine();
        }

        public static string Get(this TokenComponent self, long key)
        {
            string value = null;
            self.TokenDic.TryGetValue(key, out value);
            return value;
        }

        public static bool Remove(this TokenComponent self, long key)
        {
            if (self.TokenDic.ContainsKey(key))
            {
                self.TokenDic.Remove(key);
                return true;
            }
            return false;
        }

        private static async ETTask TimeOutRemoveKey(this TokenComponent self, long key, string tokenKey)
        {
            //10分钟超时后，令牌失效
            await TimerComponent.Instance.WaitAsync(600000);
            string onlineToken = self.Get(key);
            if (!string.IsNullOrEmpty(onlineToken) && onlineToken == tokenKey)
            {
                self.Remove(key);
            }

        }
    }
}
