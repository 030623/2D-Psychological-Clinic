using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;          // �ƶ��ٶ�
    public float stopDistance = 0.1f;     // ֹͣ������ֵ

    [Header("References")]
    public Animator animator;             // ����������
    public SpriteRenderer spriteRenderer;// ���ڷ�ת��ɫ����

    private Vector3 targetPosition;       // Ŀ��λ��
    [SerializeField]
    private bool isMoving = false;        // �ƶ�״̬���

    void Update()
    {
        HandleMouseInput();
        UpdateAnimation();
    }

    // �����������
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �������λ��ת��Ϊ��������
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.z = 0; // ȷ��Z��Ϊ0

            // ����������Ƿ�Ϊ���ƶ�����
            Collider2D hit = Physics2D.OverlapPoint(clickPos);
            if (hit != null && hit.CompareTag("WalkableArea"))
            {
                targetPosition = clickPos;
                if (!isMoving)
                {
                    StartCoroutine(MoveToTarget());
                }
            }
        }
    }

    // ƽ���ƶ�Э��
    private IEnumerator MoveToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            // �����ƶ����򲢷�ת��ɫ����
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            spriteRenderer.flipX = moveDirection.x < 0;

            // ƽ���ƶ�
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        isMoving = false;
    }

    // ���¶���״̬
    private void UpdateAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", isMoving);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        isMoving = false;
    }
}