using UnityEngine.Android;

public class Android {
    public void GetPermission(){
        // Check quyền gửi Noti
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            // Show popup hỏi quyền gửi Noti
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }
}

