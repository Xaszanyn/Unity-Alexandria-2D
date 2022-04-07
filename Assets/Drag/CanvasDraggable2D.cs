using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasDraggable2D : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] bool xLock;
    [SerializeField] bool yLock;
    RectTransform RT;
    float xBase;
    float yBase;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    void Awake()
    {
        RT = GetComponent<RectTransform>();
    }
    void Start()
    {
        xBase = RT.anchoredPosition.x;
        yBase = RT.anchoredPosition.y;

        if(maxX == 0) {
            maxX = float.MaxValue;
        }
        if(minX == 0) {
            minX = float.MinValue;
        }
        if(maxY == 0) {
            maxY = float.MaxValue;
        }
        if(minY == 0) {
            minY = float.MinValue;
        }
    }
    public void OnPointerDown(PointerEventData eventData) {}
    public void OnBeginDrag(PointerEventData eventData) {}
    public void OnDrag(PointerEventData eventData)
    {
        RT.anchoredPosition += eventData.delta; // Can be dividable Canvas.scaleFactor for different scales.

        if(RT.anchoredPosition.x > maxX) RT.anchoredPosition = new Vector2(maxX, RT.anchoredPosition.y); // Object drags amount of what mouse or touch move when collides the limit.
        if(RT.anchoredPosition.y > maxY) RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, maxY);

        if(RT.anchoredPosition.x < minX) RT.anchoredPosition = new Vector2(minX, RT.anchoredPosition.y);
        if(RT.anchoredPosition.y < minY) RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, minY);

        if(xLock) RT.anchoredPosition = new Vector2(xBase, RT.anchoredPosition.y);
        if(yLock) RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, yBase);
    }
    public void OnEndDrag(PointerEventData eventData) {}
}