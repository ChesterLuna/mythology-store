using UnityEngine;

public class Draggable : MonoBehaviour
{
    private TargetJoint2D tg;
    private bool isDragging = false;

    void Start()
    {
        tg = GetComponent<TargetJoint2D>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        tg.enabled = true;
        Vector3 offset = -(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
        tg.anchor = new Vector2(offset.x / transform.localScale.x, offset.y / transform.localScale.y);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            tg.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseUp()
    {
        tg.enabled = false;
        tg.target = Vector2.zero;
        tg.anchor = Vector2.zero;
    }
    
}
