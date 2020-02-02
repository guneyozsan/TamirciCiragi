using UnityEngine;

public class CarLeaver : MonoBehaviour
{
    [SerializeField] private float leavingVelocity;

    private Car car;
    private Collider2D carCollider;
    private Rigidbody2D carRigidbody;

    private void Awake()
    {
        carCollider = GetComponent<Collider2D>();
        carRigidbody = GetComponent<Rigidbody2D>();
        car = GetComponent<Car>();
        car.Repaired += Car_Repaired;
    }

    private void Car_Repaired()
    {
        carCollider.enabled = false;
        float angle = transform.localEulerAngles.z;
        carRigidbody.velocity = new Vector2(
            Mathf.Sin(angle * Mathf.PI / 180) * leavingVelocity,
            -1f * Mathf.Abs(Mathf.Cos(angle * Mathf.PI / 180) * leavingVelocity));
    }
}