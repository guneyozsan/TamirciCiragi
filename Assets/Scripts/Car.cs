using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    private const int maxHealth = 100;

    [SerializeField] private int healAmount;
    [SerializeField] private ProgressBarCircle progressBar;

    private int health;

    private Boss boss;
    private bool collidePlayer;
    private bool interactPlayer;

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

    private void OnMouseUpAsButton()
    {
        interactPlayer = true;
        OnInteraction();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.transform.CompareTag("Player"))
        {
            collidePlayer = true;
            OnInteraction();
        }
        else
        {
            collidePlayer = false;
        }
    }

    private void OnInteraction()
    {
        if (!collidePlayer || !interactPlayer)
        {
            return;
        }

        Health += healAmount;

        interactPlayer = false;
        collidePlayer = false;
    }

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
    public event Action Repaired;

    private void OnHealthUpdated()
    {
        HealthUpdated?.Invoke();
        progressBar.BarValue = Health;

        if (Health < maxHealth)
        {
            return;
        }

        OnCarRepaired();
    }

    private void OnCarRepaired() =>
        Repaired?.Invoke();
}