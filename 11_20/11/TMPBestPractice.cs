using UnityEngine;
using TMPro;

public class TMPBestPractice : MonoBehaviour
{
  private TextMeshProUGUI _textTMP;

  private void SetTextTMP()
  {
    // Set text theo kiểu format string
    _textTMP.SetText("Data stat {0}", 12);

    // Viết tag như HTML
    _textTMP.text = "This letter is <color=#111111><b>Black</b></color>";
  }
}
