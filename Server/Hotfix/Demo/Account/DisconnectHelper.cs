using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class DisconnectHelper
    {
        public static async ETTask Disconnect(this Session self)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            long instanceId = self.InstanceId;
            await TimerComponent.Instance.WaitAsync(1000);

            //等待一秒后，假设该InstanceId还为一致，说明是同一个Session
            if (self.InstanceId != instanceId)
            {
                return;
            }

            //Dispose 时会将InstanceId设为0
            self.Dispose();
        }
    }
}
