using System.Collections;
using Unity.Notifications.iOS;
using UnityEngine;

public class NotificationController
{
    IEnumerator RequestAuthorization()
    {
#if UNITY_IOS
        // Alert: noti sẽ hiện thông báo bằng popup trên màn hình (nếu k noti chỉ hiện trong NotiCenter của máy và user phải tự vào xem mới thấy đc)
        /// Badge: noti sẽ hiện số badge trên icon app
        // register for remote notifications: true, đăng kí nhận noti từ server
        using (AuthorizationRequest req = new(AuthorizationOption.Alert | AuthorizationOption.Badge | AuthorizationOption.Sound, true))
        {
            Debug.Log(req.IsFinished);
            while (!req.IsFinished)
            {
                yield return null;
            }

            string res = "\n RequestAuthorization:";
            res += "\n finished: " + req.IsFinished;
            res += "\n granted :  " + req.Granted;
            res += "\n error:  " + req.Error;
            // DeviceToken: mã token của thiết bị, nếu server cần gửi noti đến cụ thể từng device thì cần mã này
            res += "\n deviceToken:  " + req.DeviceToken;
            Debug.Log(res);
        }
#endif
        yield return null;
    }

    private void NotiInteract()
    {
        iOSNotificationSettings setting = iOSNotificationCenter.GetNotificationSettings();
        // Check if user has authorized local notifications
        if (setting.AuthorizationStatus == AuthorizationStatus.Authorized)
        {
            Debug.Log("User has allowed notifications");
        }
    }
}

