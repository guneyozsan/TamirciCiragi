using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    private const int maxHealth = 100;

    [SerializeField] private int healAmount;
    [SerializeField] private int health;

    private Boss boss;

    private void Awake()
    {
        boss = FindObjectOfType<Boss>();

        if (boss != null)
        {
            HealthUpdated += boss.OnCarRepaired;
        }
    }

    private void Start() =>
        Health = Random.Range(0, maxHealth);

    private void OnMouseUp() =>
        Health += healAmount;

    private void OnDestroy()
    {
        if (boss != null)
        {
            HealthUpdated -= boss.OnCarRepaired;
        }
    }

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

    public event Action HealthUpdated;

    private void OnHealthUpdated()
    {
        HealthUpdated?.Invoke();

        if (Health < maxHealth)
        {
            return;
        }

        OnCarRepaired();
    }

    private void OnCarRepaired() =>
        Destroy(gameObject);
}