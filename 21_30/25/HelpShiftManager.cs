using System.Collections.Generic;
using Helpshift;
using UnityEngine;

[HelpURL("https://developers.helpshift.com/sdkx-unity/getting-started-android")]
public class HelpShiftManager
{
    private HelpshiftSdk _help;
    [SerializeField] private string _appId, _domainName;
    public void Init()
    {
        // Đầu tiên lên website của HelpShift tạo 1 project, nhận đc API Key, AppID (PlatformID) và DomainID

        // Tạo 1 SDK instance
        _help = HelpshiftSdk.GetInstance();
        // Config Map chứa các setting
        Dictionary<string, object> configMap = new();
        // Install SDK vào app, sau bước này mới bắt đầu dùng đc
        _help.Install(_appId, _domainName, configMap);
    }
}
