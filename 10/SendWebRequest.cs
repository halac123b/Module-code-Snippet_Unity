using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

/// <summary>
/// This approach create a request, specify its upload data and method, then send
/// </summary>
public class SendWebRequest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MakeRequests());
    }

    private IEnumerator MakeRequests()
    {
        // GET
        // Use "using" statement, because when create Web request, some resources are allocated
        //// Socket for connection, buffer for transfer data, memory,..
        using (UnityWebRequest getRequest = CreateRequest("Get_api_url"))
        {
            // Đợi trong khi request đc gửi đi và xử lí
            yield return getRequest.SendWebRequest();

            // Handle error
            // ConnectionError: k connect đc server (lỗi mạng, k establish đc secure channel)
            // ProtocolError: lỗi đc server gửi về liên quan protocol
            if (getRequest.result == UnityWebRequest.Result.ConnectionError || getRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"ERROR {getRequest.error} {getRequest.result}")
            }
            // Lấy phần data đc response từ downloadHandler.text, sau đó convert sang GameObject
            DataJson deserializedGetData = JsonUtility.FromJson<DataJson>(getRequest.downloadHandler.text);
        }

        // POST
        var dataToPost = new DataJson() { data = "John Wick", length = 9001 };
        using (UnityWebRequest postRequest = CreateRequest("Post_api_url", RequestType.POST, dataToPost))
        {
            yield return postRequest.SendWebRequest();
            var deserializedPostData = JsonUtility.FromJson<DataJson>(postRequest.downloadHandler.text);
        }
    }

    // Chuẩn bị đầy đủ các thành phần cho 1 request
    private UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null)
    {
        // First, create a UnityWebRequest obj with path and RequestType
        UnityWebRequest request = new(path, type.ToString());
        if (data != null)
        {
            // Convert an object to json data, then convert it to byte array, ready to be sent
            byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            // uploadHandler: obj chứa các data (byte) cần đc upload lên server khi request
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }
        // Tạo 1 buffer đã download data đc server response
        request.downloadHandler = new DownloadHandlerBuffer();
        // Set header cho request: content dưới dạng json
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }

    private void AttachHeader(UnityWebRequest request, string header, string value)
    {
        request.SetRequestHeader(header, value);
    }
}

public class DataJson
{
    // Tên biến phải khớp hoàn toàn với tên key trong Json
    public string data;
    public int length;
}

public enum RequestType
{
    GET = 0,
    POST = 1,
    PUT = 2
}