using UnityEngine;
using System;
using UnityEngine.Events;

public class HandleEvent : MonoBehaviour
{
  public event EventHandler<CustomEventArg> OnEventTrigger;

  public class CustomEventArg : EventArgs
  {
    public int spaceCount;
  }

  // Delegate
  public delegate void TestDelegate(float f);
  public event TestDelegate OnFloatEvent;

  private void OnSpacePressed(object sender, EventArgs e)
  {
    Debug.Log("Event");
  }

  // Unity Built-in Event
  public UnityEvent OnUnityEvent;

  private void Start()
  {
    OnEventTrigger += OnSpacePressed;
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      OnEventTrigger?.Invoke(this, new CustomEventArg
      {
        spaceCount = 10
      });

      OnFloatEvent?.Invoke(5.5f);

      OnUnityEvent?.Invoke();
    }
  }
}
