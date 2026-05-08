using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;       // Normal movement speed
    public float sprintMultiplier = 1.5f; // Sprint speed multiplier
    public GameObject bulletPrefab;   // Drag bullet prefab here in Inspector
    public Transform firePoint;       // Empty GameObject at player�s front

    // Removed null coalescing for Unity objects (UNT0007)
    public PlayerController(Transform firePoint)
    {
        if (firePoint == null)
        {
            throw new System.ArgumentNullException(nameof(firePoint));
        }
        this.firePoint = firePoint;
    }

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component missing on Player.");
        }
    }

    void Update()
    {
        // Get WASD input
        if (moveInput != null)
            moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        moveInput.Normalize(); // Prevent faster diagonal movement

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

        // Apply movement
        if (rb != null)
        {
            if (rb != null)
                rb.linearVelocity = moveInput * currentSpeed;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            UnityEngine.Debug.LogWarning("Bullet prefab or fire point not assigned."); // CS0104 fix: fully qualify Debug
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Bullet prefab or fire point not assigned."); // CS0104 fix: fully qualify Debug
        }
    }
}

