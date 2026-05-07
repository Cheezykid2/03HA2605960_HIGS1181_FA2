using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float speed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintMultiplier : moveSpeed;

        transform.Translate(new Vector2(h, v) * speed * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
