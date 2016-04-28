using System;
using Template.Assets.Scripts.Entities;
using UnityEngine;

namespace Template.Assets.Scripts.Services
{
  /// <summary>
  /// This service provides a wrapper for Unity's default <see cref="Input"/> class, allowing for the
  /// ability to directly call a touch callback on an <see cref="Entity"/> object, as well as functionality
  /// for persisting previous touch events.
  /// </summary>
  public class InputService : MonoBehaviour
  {

    /// ----------
    /// PROPERTIES
    /// ----------

    /// <summary>
    /// The last touch position, translated into world space as a <see cref="Vector2"/>, where the z axis
    /// is 0.
    /// </summary>
    [NonSerialized]
    public Vector2 LastInputPosition;

    /// <summary>
    /// The last entity that was touched.
    /// </summary>
    [NonSerialized]
    public Entity LastInputEntity;

    /// -----------------
    /// PROTECTED METHODS
    /// -----------------

    protected void Update()
    {
      if (Input.touchCount == 0) return;

      Touch touch = Input.touches[0];
      Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
      Ray ray = Camera.main.ScreenPointToRay(touch.position);
      RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction);
      if (!raycastHit2D) return;

      GameObject touched = raycastHit2D.collider.transform.root.gameObject;
      Entity entity = touched.GetComponentInChildren<Entity>();
      if (entity == null) return;

      switch (touch.phase)
      {
        case TouchPhase.Began:
        {
          entity.OnTouchBegan(touchPosition);
          break;
        }
        case TouchPhase.Moved:
        {
          entity.OnTouchMoved(touchPosition);
          break;
        }
        case TouchPhase.Stationary:
        {
          entity.OnTouchStationary(touchPosition);
          break;
        }
        case TouchPhase.Ended:
        {
          entity.OnTouchEnded(touchPosition);
          break;
        }
        case TouchPhase.Canceled:
        {
          entity.OnTouchCanceled(touchPosition);
          break;
        }
        default:
          throw new System.Exception("This case should never happen");
      }

      LastInputEntity = entity;
      LastInputPosition = touchPosition;
    }
  }
}