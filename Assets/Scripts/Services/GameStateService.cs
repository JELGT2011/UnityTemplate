using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  public class GameStateService : MonoBehaviour
  {

    public delegate void GameStateChangeEvent();

    public static event GameStateChangeEvent OnAwake;
    public static event GameStateChangeEvent OnStart;
    public static event GameStateChangeEvent OnUpdate;
    public static event GameStateChangeEvent OnFixedUpdate;
    public static event GameStateChangeEvent OnPause;
    public static event GameStateChangeEvent OnResume;

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
            Time.timeScale = 0;
            OnPause?.Invoke();
          }
          else
          {
            Time.timeScale = 1;
            OnResume?.Invoke();
          }
        }
        _paused = value;
      }
    }

    void Awake()
    {
      OnAwake?.Invoke();
    }

    void Start()
    {
      OnStart?.Invoke();
    }

    void Update()
    {
      if (!Paused)
      {
        OnUpdate?.Invoke();
      }
    }

    void FixedUpdate()
    {
      if (!Paused)
      {
        OnFixedUpdate?.Invoke();
      }
    }
  }
}
