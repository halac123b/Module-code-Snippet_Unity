using System.Collections.Generic;
using GoogleMobileAds.Api;
// UMP: Unified Mobile Ads Plugin, package giúp quản lí Ads trên các loại device 1 cách thống nhất
using GoogleMobileAds.Ump.Api;
using UnityEngine;


public class GoogleAds {
    private void SetupAds(){
        // Setup các field phục vụ mục đích debug
        ConsentDebugSettings debugSettings = new(){
            // Giả sử máy đang chạy ở EU
            DebugGeography = DebugGeography.EEA,
            // List hash ID của các device test
            /// Các máy này đc bypass consent form (form mà user đọc và đồng ý vs các thoả thuận về thu thập data, privacy,..)
            TestDeviceHashedIds = new List<string>
            {
                // Android
                "A14063A26D097F2D87479B29A34FA54E",
                // iOS
                "C807206C-CD34-4770-9A1A-CE17EA244584"
            }
        };
        // Quản lí các thông tin về consent
        ConsentRequestParameters request = new()
        {
            // Không cân nhắc độ tuổi, tức mặc định user là adult
            TagForUnderAgeOfConsent = false,
            ConsentDebugSettings = debugSettings,   // Phần setting ở trên
        };
        // Update lại các request vừa khai báo, kèm callback
        ConsentInformation.Update(request, OnConsentInfoUpdated);
    }

    // Callback chứa FormError
    private void OnConsentInfoUpdated(FormError error)
    {
        if (error != null)
        {
            Debug.LogError(error);
            return;
        }
        // Nếu k có bug, mở consent form
        CheckAndLoadConsentForm();
    }

    private void CheckAndLoadConsentForm(){
        // Check trạng thái form có dùng đc k
        if (ConsentInformation.IsConsentFormAvailable())
        {
            // Load form, kèm callback
            ConsentForm.Load(OnLoadConsentForm);
        }
    }

    void OnLoadConsentForm(ConsentForm consentForm, FormError error)
    {
        if (error != null)
        {
            // Handle the error.
            Debug.LogError(error);
            return;
        }

        // Check nếu status của consent Info yêu cầu đc show thì mới show
        if (ConsentInformation.ConsentStatus == ConsentStatus.Required)
        {
            // Hàm này mới thực sự show, kèm callback
            consentForm.Show(OnShowForm);
        }
    }

    void OnShowForm(FormError error)
    {
        if (error != null)
        {
            // Handle the error.
            Debug.LogError(error);
            return;
        }

        // Nếu show lỗi thì show lại
        ConsentForm.Load(OnLoadConsentForm);
    }

    public static void ResetConsent()
    {
        ConsentInformation.Reset();
    }
}
