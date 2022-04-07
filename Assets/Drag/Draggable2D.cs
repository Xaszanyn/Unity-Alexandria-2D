using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable2D : MonoBehaviour
{
    [SerializeField] bool xLock;
    [SerializeField] bool yLock;
    [SerializeField] float speed;
    Vector3 offset;
    float xBase;
    float yBase;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    Camera C;
    void Awake() {
        C = Camera.main; // Useful for not using over and over again.
    }
    void Start() {
        xBase = transform.position.x;
        yBase = transform.position.y;

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
    void OnMouseDown()
    {
        offset = transform.position - C.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnMouseDrag()
    {
        if (speed == -1) transform.position = C.ScreenToWorldPoint(Input.mousePosition) + offset;
        else transform.position = Vector3.MoveTowards(transform.position, C.ScreenToWorldPoint(Input.mousePosition) + offset, speed * Time.deltaTime);

        if(transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, 0);
        if(transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, 0);

        if(transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, 0);
        if(transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, 0);

        if(xLock) transform.position = new Vector3(xBase, transform.position.y, 0);
        if(yLock) transform.position = new Vector3(transform.position.x, yBase, 0);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}