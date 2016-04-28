using System;
using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  /// <summary>
  /// The base service that has references to all other references.  Its only job is to make sure it
  /// keeps all of those references.
  /// </summary>
  public class GlobalServices : MonoBehaviour
  {

    /// ----------
    /// PROPERTIES
    /// ----------

    /// <summary>
    /// A reference to an instance of <see cref="GameStateService"/>.
    /// </summary>
    [NonSerialized]
    [HideInInspector]
    public GameStateService GameState;

    /// <summary>
    /// A refernce to an instance of <see cref="InputService"/>.
    /// </summary>
    [NonSerialized]
    [HideInInspector]
    public InputService Input;

    /// -----------------
    /// PROTECTED METHODS
    /// -----------------

    protected void Awake()
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
