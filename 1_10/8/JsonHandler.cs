using System.IO;
using UnityEngine;

public class JsonHandle : MonoBehaviour
{
  private PlayerInfo _playerInfo;
  private void Start()
  {
    _playerInfo = new PlayerInfo();
  }

  // Save data from GameObject to json file
  public void SaveData()
  {
    // Convert an Object Instance to json string
    // Chỉ các field public của class mới đc convert
    string json = JsonUtility.ToJson(_playerInfo);
    Debug.Log($"Json file {json}");

    using (StreamWriter writer = new(Application.dataPath + Path.DirectorySeparatorChar + "SaveData.json"))
    {
      writer.Write(json);
    }
  }

  // Read data from json file
  public void LoadData()
  {
    string json = string.Empty;
    using (StreamReader reader = new(Application.dataPath + Path.DirectorySeparatorChar + "SaveData.json"))
    {
      json = reader.ReadToEnd();
    }

    // Convert string into GameObject
    PlayerInfo data = JsonUtility.FromJson<PlayerInfo>(json);
    _playerInfo = data;
  }
}

public class PlayerInfo
{
  public string Name;
  public string Description;
}
