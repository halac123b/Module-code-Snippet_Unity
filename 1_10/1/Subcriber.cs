using UnityEngine;
using System;

public class Subcriber : MonoBehaviour
{
  private HandleEvent handler;

  private void Start()
  {
    handler = GetComponent<HandleEvent>();
    handler.OnEventTrigger += OnSubcribe;

    // handler.OnEventTrigger -= OnSubcribe;
  }

  private void OnSubcribe(object sender, HandleEvent.CustomEventArg e)
  {
    Debug.Log("Subcribe " + e.spaceCount);
  }

  private void OnFloatTrigget(float f)
  {
    Debug.Log("Delegate as Event " + f);
  }
}

