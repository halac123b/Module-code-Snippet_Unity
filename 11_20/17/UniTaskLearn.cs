using UnityEngine;
using Cysharp.Threading.Tasks;

public class UniTaskLearn
{
  async void Start()
  {
    // Gọi await với UniTask như bình thường
    await DoSomethingAsync();
    Debug.Log("UniTask completed after delay.");
  }

  // Hàm UniTask có return type UniTask
  private async UniTask DoSomethingAsync()
  {
    await UniTask.Delay(2000);
  }

  // Khi muốn return 1 value
  private async UniTask<int> DoSomethingAsync()
  {
    await UniTask.Delay(2000);
    return 100;
  }
}
