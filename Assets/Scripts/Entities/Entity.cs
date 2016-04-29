using System;
using UnityEngine;

using Template.Assets.Scripts.Services;

namespace Template.Assets.Scripts.Entities
{
  /// <summary>
  /// This is the base class for an Entity.  An entity is a <see cref="GameObject"/> that players can
  /// interact with (e.g. a weapon, enemy, etc).  You should ALWAYS inherit from this class, and you
  /// should NOT use the default Update, and FixedUpdate functions.  Instead, use the inherited
  /// OnUpdate, and OnFixedUpdate.  Additionally functions included:
  /// <list type="additional methods">
  ///   OnTouchBegan
  ///   OnTouchCanceled
  ///   OnTouchMoved
  ///   OnTouchEnded
  ///   OnTouchStationary
  ///   OnEnable (must make call to super)
  ///   OnDisable (must make call to super)
  ///   OnUpdate
  ///   OnFixedUpdate
  ///   OnPause
  ///   OnResume
  /// </list>
  /// </summary>
  [RequireComponent(typeof(Collider))]
  public class Entity : MonoBehaviour
  {

    /// ----------
    /// PROPERTIES
    /// ----------

    /// <summary>
    /// Reference to <see cref="GlobalServices"/>.  It has references to all other services.
    /// </summary>
    [NonSerialized]
    protected GlobalServices Services;

    /// --------------
    /// PUBLIC METHODS
    /// --------------

    /// <summary>
    /// Called by <see cref="InputService"/> when this GameObject is touched and the
    /// <see cref="TouchPhase"/> is TouchPhase.Began.
    /// </summary>
    public void OnTouchBegan(Vector2 touchPosition)
    {

    }

    /// <summary>
    /// Called by <see cref="InputService"/> when this GameObject is touched and the
    /// <see cref="TouchPhase"/> is TouchPhase.Canceled.
    /// </summary>
    public void OnTouchCanceled(Vector2 touchPosition)
    {

    }

    /// <summary>
    /// Called by <see cref="InputService"/> when this GameObject is touched and the
    /// <see cref="TouchPhase"/> is TouchPhase.Moved.
    /// </summary>
    public void OnTouchMoved(Vector2 touchPosition)
    {

    }

    /// <summary>
    /// Called by <see cref="InputService"/> when this GameObject is touched and the
    /// <see cref="TouchPhase"/> is TouchPhase.Ended.
    /// </summary>
    public void OnTouchEnded(Vector2 touchPosition)
    {

    }

    /// <summary>
    /// Called by <see cref="InputService"/> when this GameObject is touched and the
    /// <see cref="TouchPhase"/> is TouchPhase.Stationary.
    /// </summary>
    public void OnTouchStationary(Vector2 touchPosition)
    {

    }

    /// -----------------
    /// PROTECTED METHODS
    /// -----------------

    protected void Awake()
    {
      if (Services == null)
      {
        GameObject _servicesObject = GameObject.Find("GlobalServices") as GameObject;
        Services = _servicesObject.GetComponent<GlobalServices>();
      }
    }

    /// <summary>
    /// This function allows the <see cref="GameStateService"/> to delegate the OnPause, OnResume,
    /// OnUpdate, and OnFixedUpdate functions.  You MUST make a call to super if you are going to
    /// use this function in inheriting classes.
    /// </summary>
    protected void OnEnable()
    {
      GameStateService.OnPause += OnPause;
      GameStateService.OnResume += OnResume;
      GameStateService.OnUpdate += OnUpdate;
      GameStateService.OnFixedUpdate += OnFixedUpdate;
    }

    /// <summary>
    /// This function allows the <see cref="GameStateService"/> to clean up the delegated functions.
    /// You MUST make a call to super if you are going to use this function in inheriting classes.
    /// </summary>
    protected void OnDisable()
    {
      GameStateService.OnPause -= OnPause;
      GameStateService.OnResume -= OnResume;
      GameStateService.OnUpdate -= OnUpdate;
      GameStateService.OnFixedUpdate -= OnFixedUpdate;
    }

    /// <summary>
    /// A wrapper function for the <see cref="MonoBehaviour"/> Update method, which accounts for the
    /// pause functionality.
    /// </summary>
    protected void OnUpdate()
    {

    }

    /// <summary>
    /// A wrapper function for the <see cref="MonoBehaviour"/> FixedUpdate method, which accounts for
    /// the pause functionality.
    /// </summary>
    protected void OnFixedUpdate()
    {

    }

    /// <summary>
    /// This will get called by <see cref="GameStateService"/> when its Paused property flips to true.
    /// </summary>
    protected void OnPause()
    {

    }

    /// <summary>
    /// This will get called by <see cref="GameStateService"/> when its Paused property flips to false.
    /// </summary>
    protected void OnResume()
    {

    }
  }
}
