using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObj : MonoBehaviour
{
    public string target;
    public UnityEvent onInteract;
    public UnityEvent onMouseClick; // 新增：鼠标点击时执行的事件
    public bool isMouseClickEnabled = false; // 新增：判断是否启用鼠标点击功能的布尔值

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target))
        {
            onInteract.Invoke();
            Debug.Log("InteractableObj: Interacting with " + target);
        }
    }

    private void Update()
    {
        // 检查是否启用鼠标点击功能，并且鼠标左键是否被按下
        if (isMouseClickEnabled && Input.GetMouseButtonDown(0))
        {
            // 将鼠标屏幕坐标转换为世界坐标
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            // 发射射线检测是否点击到当前对象
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                onMouseClick.Invoke();
                Debug.Log("InteractableObj: Mouse clicked on the object");
            }
        }
    }
}