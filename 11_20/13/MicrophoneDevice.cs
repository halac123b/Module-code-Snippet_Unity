using UnityEngine;

public class MicrophoneDevice
{
  public void GetMicrophoneList()
  {
    // Get list<string> of micro name
    string[] listMic = Microphone.devices;

    // Tần số min, max thu đc từ âm thanh micro
    int minimumFrequency, maximumFrequency;
    // Get thông số (min, max frequency) của 1 device theo tên
    Microphone.GetDeviceCaps($"{listMic[0]}", out minimumFrequency, out maximumFrequency);

    // Bắt đầu record với micro và lưu vào 1 AudioClip, input:
    /// Loop (true): có lặp lại k, nếu có sẽ liên tục record sau khi hết thời gian
    /// LengthSec (1): độ dài của clip ghi âm, nếu có loop thì sẽ tự record lại từ đầu
    AudioClip microphone = Microphone.Start(listMic[0], true, 1, maximumFrequency);
  }
}
