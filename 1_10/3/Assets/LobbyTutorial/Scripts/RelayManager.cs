using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using System;

// public static TestRelay Instance { get; private set; }
public class RelayManager : Monobehaviour
{
  public static RelayManager Instance { get; private set; }


  private void Awake()
  {
    Instance = this;
  }

  public async Task<string> CreateRelay()
  {
    try
    {
      // Send request tạo relay tới U.S với 3 member (1 host + 3 player)
      Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);
      // Lấy join code của relay
      string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

      // Sau khi tạo relay, để người khác có thể join vào đc cần cung cấp thông tin cho package network của game
      // Tạo data của relay để gắn nó vào Network của game
      RelayServerData relayServerData = new RelayServerData(allocation, "dtls");

      // Get UnityTransport method và gắn data của relay vào
      NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

      NetworkManager.Singleton.StartHost();

      return joinCode;
    }
    catch (RelayServiceException e)
    {
      Debug.Log(e);
      return null;
    }
  }

  public async void JoinRelay(string joinCode)
  {
    try
    {
      Debug.Log("Joining Relay with " + joinCode);
      // Send request join relay thông qua join code
      JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

      // Tương tự với bên host, client cũng phải gắn data cho network
      RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
      NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

      NetworkManager.Singleton.StartClient();
    }
    catch (RelayServiceException e)
    {
      Debug.Log(e);
    }
  }
}
