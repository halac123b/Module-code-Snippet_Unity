using DG.Tweening;

public class LearnTween {
    [SerializeField] private Image _loadingBar;
    public void Tween(){
        // Dịch chuyển dần fill amount đến giá trị chỉ định (0.4) trong vòng 2s
        _loadingBar.DOFillAmount(0.4f, 2);
    }

    public void CallDelay(){
        // Giống các công cụ khác để delay rồi gọi 1 hàm (Invoke, Coroutine)
        /// Nhưng k block như Invoke
        DOVirtual.DelayedCall(2, () => {});
    }
}