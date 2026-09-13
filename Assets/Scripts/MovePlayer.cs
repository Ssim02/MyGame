using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody rb;
    private Vector3 moveDir; // 어느 방향으로 움직여야 하는지

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A, D, <-, ->
        float vertical = Input.GetAxisRaw("Vertical"); // W, S, ↑, ↓

        moveDir = new Vector3(horizontal, 0.0f, vertical);
        moveDir = Vector3.ClampMagnitude(moveDir, 1.0f); // 이동 방향 최대 길이를 1로 제한. 대각선 이동 속도가 빨라지는 걸 방지하기 위해
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = moveDir * moveSpeed;

        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z); // linearVelocity : Rigidbody의 이동 속도
    }
}
