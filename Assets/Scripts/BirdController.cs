using UnityEngine;

public class BirdController : MonoBehaviour
{
    
    private Vector2 position = Vector2.zero;
    [SerializeField] Animator animator;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // сбрасываем скорость падения
            rb.linearVelocity = Vector2.zero;

            // толчок вверх
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Fly");
        }

        // анимация падения
        if (rb.linearVelocity.y < 0)
        {
            animator.SetTrigger("Idle");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            GameManager.Instance.AddScore();
        }
        
        if (other.CompareTag("Pipe") || other.CompareTag("Ground") || other.CompareTag("AngryBird") )
        {
            GameManager.Instance.GameOver();
        }
    }
}
