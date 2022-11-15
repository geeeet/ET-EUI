﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class AccountSessionsComponentDestorySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDic.Clear();
        }

    }

    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionDic.TryGetValue(accountId, out long sessionInstanceId))
            {
                return 0;
            }

            return sessionInstanceId;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanceId)
        {
            if (self.AccountSessionDic.ContainsKey(accountId))
            {
                self.AccountSessionDic[accountId] = sessionInstanceId;
            }
            else
            {
                self.AccountSessionDic.Add(accountId, sessionInstanceId);
            }
        }

        public static bool Remove(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionDic.ContainsKey(accountId))
            {
                self.AccountSessionDic.Remove(accountId);
                return true;
            }
            return false;
        }
    }
}
