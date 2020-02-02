using UnityEngine;

public class CarParker : MonoBehaviour
{
    [SerializeField] private float initialVelocity;

    private Rigidbody2D carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float angle = transform.localEulerAngles.z;
        carRigidbody.velocity = new Vector2(
            -1f * Mathf.Sin(angle * Mathf.PI / 180) * initialVelocity,
            Mathf.Cos(angle) * initialVelocity);
    }
}