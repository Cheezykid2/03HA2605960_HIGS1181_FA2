using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;              // Normal movement speed
    public float sprintMultiplier = 1.5f;     // Sprint speed multiplier
    public GameObject bulletPrefab;           // Drag bullet prefab here in Inspector
    public Transform firePoint;               // Empty GameObject at player's front

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component missing on Player.");
        }
    }

    void Update()
    {
        // Get WASD / arrow keys input
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        // Prevent faster diagonal movement
        if (moveInput.sqrMagnitude > 1f)
            moveInput.Normalize();

        // Fire bullet on left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = moveSpeed;

        // Sprint when Shift is held
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // Apply movement using Rigidbody2D velocity
        if (rb != null)
        {
            rb.linearVelocity = moveInput * currentSpeed;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Bullet prefab or fire point not assigned.");
            return;
        }

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit by enemy!");
            ResetPlayer();
        }
    }
    public Vector2 startPosition = new Vector2(0, 0);

    private void ResetPlayer()
    {
        // Stop movement and move to the configured start position.
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
        Debug.Log("Player respawned at start.");
    }

}
