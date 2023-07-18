using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class PlayerNetwork : NetworkBehaviour
{
  [SerializeField] private Transform spawnObjPrefab;
  private Transform spawnObjTransform;

  private Vector3 moveDir = new Vector3(0, 0, 0);
  private float moveSpeed = 3f;

  private NetworkVariable<int> randomNumber = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

  public override void OnNetworkDespawn()
  {
    randomNumber.OnValueChanged += (int previousValue, int newValue) =>
    {
      Debug.Log(OwnerClientId + "; RandomNumber: " + randomNumber.Value);
    };
  }

  public struct MyCustomData : INetworkSerializable
  {
    public int number;
    public bool boolean;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
      serializer.SerializeValue(ref number);
      serializer.SerializeValue(ref boolean);
    }
  }

  private NetworkVariable<MyCustomData> customVar = new NetworkVariable<MyCustomData>(
                                                        new MyCustomData { number = 10, boolean = false });

  private void Update()
  {
    moveDir = new Vector3(0, 0, 0);
    if (!IsOwner)
    {
      return;
    }

    if (Input.GetKeyDown(KeyCode.T))
    {
      // randomNumber.Value = Random.Range(0, 100);

      // customVar.Value = new MyCustomData { number = 20, boolean = true };

      TestServerRpc(new ServerRpcParams());
      TestClientRpc(new ClientRpcParams { Send = new ClientRpcSendParams { TargetClientIds = new List<ulong> { 1 } } });

      spawnObjTransform = Instantiate(spawnObjPrefab);
      spawnObjTransform.GetComponent<NetworkObject>().Spawn(true);
    }

    if (Input.GetKeyDown(KeyCode.Y))
    {
      spawnObjTransform.GetComponent<NetworkObject>().Despawn();
    }

    if (Input.GetKey(KeyCode.W))
    {
      moveDir.z = 1f;
    }
    if (Input.GetKey(KeyCode.S))
    {
      moveDir.z = -1f;
    }
    if (Input.GetKey(KeyCode.A))
    {
      moveDir.x = -1f;
    }
    if (Input.GetKey(KeyCode.D))
    {
      moveDir.x = 1f;
    }

    transform.position += moveDir * Time.deltaTime * moveSpeed;
  }

  [ServerRpc]
  // private void TestServerRpc(string message)
  // {
  //   Debug.Log(message);
  // }

  private void TestServerRpc(ServerRpcParams serverRpcParams)
  {
    Debug.Log(serverRpcParams.Receive.SenderClientId);
  }

  [ClientRpc]
  // private void TestClientRpc()
  // {
  //   Debug.Log(1);
  // }
  private void TestClientRpc(ClientRpcParams clientRpcParams)
  {
    Debug.Log(1);
  }
}
