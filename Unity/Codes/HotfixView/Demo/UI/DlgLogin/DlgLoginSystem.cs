using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{
    public static class DlgLoginSystem
    {

        public static void RegisterUIEvent(this DlgLogin self)
        {
            //点击后，禁用点击，当事件完成后，再恢复点击
            self.View.E_LoginButton.AddListenerAsync(() => { return self.OnLoginClickHandler(); });
        }

        public static void ShowWindow(this DlgLogin self, Entity contextData = null)
        {

        }

        public static async ETTask OnLoginClickHandler(this DlgLogin self)
        {
            try
            {
                int errorCode = await LoginHelper.Login(
                  self.DomainScene(),
                  ConstValue.LoginAddress,
                  self.View.E_AccountInputField.GetComponent<InputField>().text,
                  self.View.E_PasswordInputField.GetComponent<InputField>().text);

                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                }

                //TODO 登陆成功
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                throw;
            }
        }

        public static void HideWindow(this DlgLogin self)
        {

        }

    }
}
