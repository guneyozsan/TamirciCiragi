using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    private const int maxHealth = 100;

    [SerializeField] private int healAmount;
    [SerializeField] private int health;

    private void Start() =>
        Health = Random.Range(0, maxHealth);
    
    private int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            OnHealthUpdated();
        }
    }

    private void OnMouseUp() =>
        Health += healAmount;

    private void OnHealthUpdated()
    {
        if (Health < maxHealth)
        {
            return;
        }

        OnCarRepaired();
    }

    private void OnCarRepaired() =>
        Destroy(gameObject);
}