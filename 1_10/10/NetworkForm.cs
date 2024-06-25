using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

/// <summary>
/// Approach sử dụng WWWForm, dễ sử dụng và add data để gửi đi hơn, và bên server các data cũng đc phân theo field dễ lấy hơn. So với việc phải tự handle UploadHandlerRaw.
/// </summary>
public class NetworkForm : MonoBehaviour
{
  private void SendRequest()
  {
    StartCoroutine(PrepareRequest());
  }

  private IEnumerator PrepareRequest()
  {
    WWWForm form = new();
    // Add text field
    form.AddField("name", "Le Van");

    byte[] uploadByte = Encoding.UTF8.GetBytes("This can be a json file");
    // Add a file in byte array
    //// "image/png": mimeType - media type
    form.AddBinaryData("file", uploadByte, "image.png", "image/png");

    using (var request = UnityWebRequest.Post("api_url", form))
    {
      yield return request.SendWebRequest();

      // Xuống dưới thì xử lí tương tự cách kia, handle error, rồi lấy data từ downloadHandler
    }
  }
}
