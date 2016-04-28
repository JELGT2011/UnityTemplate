using System;
using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  public class GlobalServices : MonoBehaviour
  {

    [NonSerialized]
    [HideInInspector]
    public GameStateService GameState;

    [NonSerialized]
    [HideInInspector]
    public InputService Input;

    void Awake()
    {
      if (GameState == null)
      {
        GameObject _gameStateServiceObject = Resources.Load("Prefabs/Services/GameStateService") as GameObject;
        GameState = _gameStateServiceObject.GetComponent<GameStateService>();
      }

      if (Input == null)
      {
        GameObject _inputServiceObject = Resources.Load("Prefabs/Services/InputService") as GameObject;
        Input = _inputServiceObject.GetComponent<InputService>();
      }
    }
  }
}
