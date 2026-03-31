using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float patrolRange = 3f;
    public int damage = 1; // You can change this in the Inspector
    private Vector3 startPos;

    void Start() { startPos = transform.position; }

    void Update()
    {
        float x = startPos.x + Mathf.PingPong(Time.time * speed, patrolRange);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    // This part connects to your PlayerHealth script
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}