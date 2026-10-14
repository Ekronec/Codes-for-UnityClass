using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float patrolDistance = 3f;

    private float startX;
    private int direction = 1;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(
            Vector2.right * direction * speed * Time.deltaTime,
            Space.World
        );

        float rightLimit = startX + patrolDistance;
        float leftLimit = startX - patrolDistance;

        if (direction == 1 && transform.position.x >= rightLimit)
        {
            ChangeDirection();
        }
        else if (direction == -1 && transform.position.x <= leftLimit)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        direction *= -1;
    }
}