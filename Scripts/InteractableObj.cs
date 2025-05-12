using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObj : MonoBehaviour
{
    public string target;
    public UnityEvent onInteract;
    public UnityEvent onMouseClick; // �����������ʱִ�е��¼�
    public bool isMouseClickEnabled = false; // �������ж��Ƿ�������������ܵĲ���ֵ

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
        // ����Ƿ�������������ܣ������������Ƿ񱻰���
        if (isMouseClickEnabled && Input.GetMouseButtonDown(0))
        {
            // �������Ļ����ת��Ϊ��������
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            // �������߼���Ƿ�������ǰ����
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                onMouseClick.Invoke();
                Debug.Log("InteractableObj: Mouse clicked on the object");
            }
        }
    }
}