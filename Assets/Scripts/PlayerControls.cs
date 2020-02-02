using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Vector2 targetPosition;
    [SerializeField] private Vector2 direction;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (targetPosition - (Vector2)transform.position).normalized;
            playerRigidbody.velocity = speed * direction;
        }
    }

    private void FixedUpdate()
    {
        Vector2 deltaPosition = targetPosition - (Vector2)transform.position;

        float signX = Mathf.Sign(deltaPosition.x * direction.x);
        float signY = Mathf.Sign(deltaPosition.y * direction.y);

        if (signX < 0 || signY < 0)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerRigidbody.velocity = Vector2.zero;
    }
}