using UnityEngine;

public class NonVisibleDestroyer : MonoBehaviour
{
    [SerializeField] private float minDistanceY;

    private Rigidbody2D rigidbody2;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigidbody2.velocity == Vector2.zero && 
            transform.localPosition.y < -1f * minDistanceY)
        {
            Destroy(gameObject);
        }
    }
}