using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move bullet forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy destroyed!");
            Destroy(collision.gameObject); // remove enemy
            Destroy(gameObject);           // remove bullet

            // Notify GameManager
            if (GameManager.Instance != null)
                GameManager.Instance.OnEnemyDestroyed();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Prevent bullets flying forever
        }
    }
}
