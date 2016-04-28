using Template.Assets.Scripts.Entities;
using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  /// <summary>
  /// This is a global service that controls the state of the game.  It calls the OnUpdate, OnFixedUpdate,
  /// OnPause, and OnResume on all <see cref="Entity"/> instances that subscribe via the OnEnable base
  /// function.
  /// </summary>
  public class GameStateService : MonoBehaviour
  {

    /// ----------
    /// PROPERTIES
    /// ----------

    /// <summary>
    /// Delegate type that the OnUpdate, OnFixedUpdate, OnPause, and OnResume subscribe to.
    /// </summary>
    public delegate void GameStateChangeEvent();

    /// <summary>
    /// Events that will be called on all <see cref="Entity"/> instances.
    /// </summary>
    public static event GameStateChangeEvent OnUpdate;
    public static event GameStateChangeEvent OnFixedUpdate;
    public static event GameStateChangeEvent OnPause;
    public static event GameStateChangeEvent OnResume;

    /// property that keeps track of the <see cref="Time.timeScale"/> property before it is overritten for pause.
    protected float TimeScale = 1f;

    /// property that has an OnPropertyChange listener, which calls OnPause, and OnResume when this property changes
    /// between true and false, respectively.
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

    /// -----------------
    /// PROTECTED METHODS
    /// -----------------

    /// <summary>
    /// Uses the default <see cref="MonoBehaviour.Update"/> function to wrap the pause functionality.
    /// </summary>
    void Update()
    {
      if (Paused || OnUpdate != null) return;
      OnUpdate();
    }

    /// <summary>
    /// Uses the default <see cref="MonoBehaviour.FixedUpdate"/> function to wrap the pause functionality.
    /// </summary>
    void FixedUpdate()
    {
      if (Paused || OnFixedUpdate == null) return;
      OnFixedUpdate();
    }
  }
}
