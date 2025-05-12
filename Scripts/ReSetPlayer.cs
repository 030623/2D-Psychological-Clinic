using UnityEngine;

public class ReSetPlayer : MonoBehaviour
{
    public Transform playerTransform;

    Vector3 startPos;


    private void Awake()
    {
        startPos = playerTransform.position;
    }

    public void OnEnable()
    {
        playerTransform.position = startPos;
    }
}
