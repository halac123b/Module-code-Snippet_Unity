using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class LearnTween
{
    [SerializeField] private Transform panelMain;
    [SerializeField] private Image _loadingBar;

    public void PlaySequence()
    {
        // Class giúp quản lí 1 chuỗi các tween liên tục
        Sequence seq = DOTween.Sequence();

        // Add các tween vào Sequence
        seq.Append(panelMain.DOScale(new Vector3(1, 1, 1), 0.02f).SetEase(Ease.Linear));
        seq.Append(panelMain.DOScale(new Vector3(1, 1, 1), 0.25f).SetEase(Ease.OutBack));
        // Thêm callback khi kết thúc Sequence
        seq.AppendCallback(() => { });

        // Kill sequence, ngắt các tween chưa đc chạy
        seq.Kill();
    }
}