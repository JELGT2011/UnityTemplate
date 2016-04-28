using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  public class GlobalServices : MonoBehaviour
  {

    public GameStateService GameState;

    void Awake()
    {
      if (GameState == null)
      {
        GameObject _gameStateServiceObject = Resources.Load("Prefabs/Services/GameStateService") as GameObject;
        GameState = _gameStateServiceObject.GetComponent<GameStateService>();
      }
    }
  }
}
