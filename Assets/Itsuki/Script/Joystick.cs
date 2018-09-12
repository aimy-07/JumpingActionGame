using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : Graphic, IPointerDownHandler, IPointerUpHandler, IEndDragHandler, IDragHandler
{
    [SerializeField][Header("実際に動くスティック部分（自動設定）")]
    private GameObject _stick = null;
    private const string STICK_NAME = "Stick";

    [SerializeField][Header("スティックが動く範囲の半径")]
    private float _radius = 100;

    [SerializeField][Header("指を離した時にスティックが中心に戻るか")]
    private bool _shouldResetPosition = true;

    [SerializeField][Header("現在地（自動更新）")]
    private Vector2 _position = Vector2.zero;
    public Vector2 Position { get { return _position; } }

    private Vector3 _stickPosition
    {
        set
        {
            _stick.transform.localPosition = value;
            _position = new Vector2(_stick.transform.localPosition.x / _radius, _stick.transform.localPosition.y / _radius);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        Init();
    }

    private void Init()
    {
        CreateStickIfneeded();
        _stickPosition = Vector3.zero;


        Image stickImage = _stick.GetComponent<Image>();
        if (stickImage == null)
        {
            stickImage = _stick.AddComponent<Image>();
        }
        stickImage.raycastTarget = false;

        raycastTarget = true;

        color = new Color(0, 0, 0, 0);
    }

    private void CreateStickIfneeded()
    {
        if (_stick != null)
        {
            return;
        }

        if (transform.Find(STICK_NAME) != null)
        {
            _stick = transform.Find(STICK_NAME).gameObject;
            return;
        }

        _stick = new GameObject(STICK_NAME);
        _stick.transform.SetParent(gameObject.transform);
        _stick.transform.localRotation = Quaternion.identity;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnEndDrag(eventData);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (_shouldResetPosition)
        {
            _stickPosition = Vector3.zero;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 screenPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), new Vector2(Input.mousePosition.x, Input.mousePosition.y), null, out screenPos);

        _stickPosition = screenPos;

        float currentRadius = Vector3.Distance(Vector3.zero, _stick.transform.localPosition);
        if (currentRadius > _radius)
        {
            float radian = Mathf.Atan2(_stick.transform.localPosition.y, _stick.transform.localPosition.x);

            Vector3 limitedPosition = Vector3.zero;
            limitedPosition.x = _radius * Mathf.Cos(radian);
            limitedPosition.y = _radius * Mathf.Sin(radian);

            _stickPosition = limitedPosition;
        }

    }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _radius * 0.5f);
    }
#endif


}
