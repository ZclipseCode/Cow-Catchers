using UnityEngine;

public class LassoableMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] bool facingRight;
    float xSpeed;
    float ySpeed;
    Vector2 direction;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        xSpeed = speed;
        ySpeed = speed;

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
        float x = Random.Range(0f, 360f);
        float y = Random.Range(0f, 460f);

        direction = new Vector2(x, y);
    }

    void Move()
    {
        float offset = 0.001f;

        transform.Translate(direction * speed * offset * Time.deltaTime);
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
