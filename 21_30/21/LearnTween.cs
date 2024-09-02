using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LearnTween
{
    [SerializeField] private Image _loadingBar;
    public void Tween()
    {
        // Dịch chuyển dần fill amount đến giá trị chỉ định (0.4) trong vòng 2s
        _loadingBar.DOFillAmount(0.4f, 2);

        // Tween localScale của transform
        /// SetEase: set tốc độ của tween:
        /// Linear: giữ nguyên từ đầu đến cuối
        /// OutBack: vượt qua giá trị cần set 1 mức nhỏ, sau đó mới quay lại mức đó (tạo hiệu ứng nảy)
        /// default: OutQuad: bắt đầu nhanh, rồi chậm dần
        _loadingBar.transform.DOScale(new Vector3(1, 1, 1), 0.02f).SetEase(Ease.Linear);
    }

    public void CallDelay()
    {
        // Giống các công cụ khác để delay rồi gọi 1 hàm (Invoke, Coroutine)
        /// Nhưng k block như Invoke
        DOVirtual.DelayedCall(2, () => { });
    }
}