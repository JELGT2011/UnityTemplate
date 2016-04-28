using System;
using Template.Assets.Scripts.Services;
using UnityEngine;

namespace Template.Assets.Scripts.Entities
{
  public class Entity : MonoBehaviour
  {

    [NonSerialized]
    protected GlobalServices Services;

    public void OnTouchBegan(Vector2 touchPosition)
    {

    }

    public void OnTouchCanceled(Vector2 touchPosition)
    {

    }

    public void OnTouchMoved(Vector2 touchPosition)
    {

    }

    public void OnTouchEnded(Vector2 touchPosition)
    {

    }

    public void OnTouchStationary(Vector2 touchPosition)
    {

    }

    protected void OnEnable()
    {
      GameStateService.OnPause += OnPause;
      GameStateService.OnResume += OnResume;
      GameStateService.OnUpdate += OnUpdate;
      GameStateService.OnFixedUpdate += OnFixedUpdate;
    }

    protected void OnDisable()
    {
      GameStateService.OnPause -= OnPause;
      GameStateService.OnResume -= OnResume;
      GameStateService.OnUpdate -= OnUpdate;
      GameStateService.OnFixedUpdate -= OnFixedUpdate;
    }

    protected void Awake()
    {
      if (Services == null)
      {
        GameObject _servicesObject = GameObject.Find("GlobalServices") as GameObject;
        Services = _servicesObject.GetComponent<GlobalServices>();
      }
    }

    protected void OnUpdate()
    {

    }

    protected void OnFixedUpdate()
    {

    }

    protected void OnPause()
    {

    }

    protected void OnResume()
    {

    }
  }
}
