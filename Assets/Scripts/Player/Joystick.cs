using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickBounds;
    [SerializeField] private Canvas _canvas;

    private Vector3 _frameVelocity;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _joystickBounds.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        float x = (position.x / _joystickBounds.rectTransform.sizeDelta.x);
        float y = (position.y / _joystickBounds.rectTransform.sizeDelta.y);

        Vector3 InputDirection = new Vector3(x, y, 0);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        _joystick.rectTransform.anchoredPosition = new Vector3(
            InputDirection.x * _joystickBounds.rectTransform.sizeDelta.x / 3,
            InputDirection.y * _joystickBounds.rectTransform.sizeDelta.y / 3
        );
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        _joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
