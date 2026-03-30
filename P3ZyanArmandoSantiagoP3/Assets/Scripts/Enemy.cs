using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float patrolRange = 3f;
    private Vector3 startPos;

    void Start() { startPos = transform.position; }

    void Update()
    {
        float x = startPos.x + Mathf.PingPong(Time.time * speed, patrolRange);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}

