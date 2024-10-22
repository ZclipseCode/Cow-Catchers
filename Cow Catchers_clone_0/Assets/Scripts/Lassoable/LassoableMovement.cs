using UnityEngine;

public class LassoableMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] bool facingRight;
    Vector2 direction;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        RandomizeDirection();

        if (direction.x >= 0f && !facingRight)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Update()
    {
        Move();
    }

    void RandomizeDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        direction = new Vector2(x, y).normalized;
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("XWall"))
        {
            direction = new Vector2(-direction.x, direction.y);
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else if (collision.collider.CompareTag("YWall"))
        {
            direction = new Vector2(direction.x, -direction.y);
        }
    }
}
