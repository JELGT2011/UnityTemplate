using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  public class GameStateService : MonoBehaviour
  {

    public delegate void GameStateChangeEvent();

    public static event GameStateChangeEvent OnUpdate;
    public static event GameStateChangeEvent OnFixedUpdate;
    public static event GameStateChangeEvent OnPause;
    public static event GameStateChangeEvent OnResume;

    protected float TimeScale = 1f;

    protected bool _paused = false;
    public bool Paused
    {
      get { return _paused; }
      set
      {
        if (_paused != value)
        {
          if (value)
          {
            TimeScale = Time.timeScale;
            Time.timeScale = 0;
            if (OnPause != null)
            {
              OnPause();
            }
          }
          else
          {
            Time.timeScale = TimeScale;
            if (OnResume != null)
            {
              OnResume();
            }
          }
        }
        _paused = value;
      }
    }

    void Update()
    {
      if (Paused || OnUpdate != null) return;
      OnUpdate();
    }

    void FixedUpdate()
    {
      if (Paused || OnFixedUpdate == null) return;
      OnFixedUpdate();
    }
  }
}
