using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;          // 移动速度
    public float stopDistance = 0.1f;     // 停止距离阈值

    [Header("References")]
    public Animator animator;             // 动画控制器
    public SpriteRenderer spriteRenderer;// 用于翻转角色朝向

    private Vector3 targetPosition;       // 目标位置
    [SerializeField]
    private bool isMoving = false;        // 移动状态标记

    void Update()
    {
        HandleMouseInput();
        UpdateAnimation();
    }

    // 处理鼠标输入
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 将鼠标点击位置转换为世界坐标
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.z = 0; // 确保Z轴为0

            // 检测点击区域是否为可移动区域
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

    // 平滑移动协程
    private IEnumerator MoveToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            // 计算移动方向并翻转角色朝向
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            spriteRenderer.flipX = moveDirection.x < 0;

            // 平滑移动
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        isMoving = false;
    }

    // 更新动画状态
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