using System;


namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount loginAccount = null;
            Session accountSession = null;

            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                //密码进行加密
                password = MD5Helper.StringMD5(password);
                loginAccount = (A2C_LoginAccount)await accountSession.Call(new C2A_LoginAccount()
                {
                    AccountName = account,
                    Password = password,
                });
            }
            catch (Exception e)
            {
                accountSession?.Dispose();
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
                throw;
            }

            if (loginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return loginAccount.Error;
            }

            //保存Session链接
            zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            //PingComponent保证隔一段时间检测心跳包，保证客户端没有断开
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

            zoneScene.GetComponent<AccountInfoComponent>().Token = loginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = loginAccount.AccountId;

            return ErrorCode.ERR_Success;

            //try
            //{
            //    // 创建一个ETModel层的Session
            //    R2C_Login r2CLogin;
            //    Session session = null;
            //    try
            //    {
            //        session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
            //        {
            //            r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = password });
            //        }
            //    }
            //    finally
            //    {
            //        session?.Dispose();
            //    }

            //    // 创建一个gate Session,并且保存到SessionComponent中
            //    Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
            //    gateSession.AddComponent<PingComponent>();
            //    zoneScene.AddComponent<SessionComponent>().Session = gateSession;

            //    G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
            //        new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

            //    Log.Debug("登陆gate成功!");

            //    Game.EventSystem.PublishAsync(new EventType.LoginFinish() {ZoneScene = zoneScene}).Coroutine();
            //}
            //catch (Exception e)
            //{
            //    Log.Error(e);
            //}
        }
    }
}