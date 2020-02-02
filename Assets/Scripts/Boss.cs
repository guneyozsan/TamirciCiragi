using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private const int maxAnger = 100;

    [SerializeField] private float angerIncreaseRatePerSecond;
    [SerializeField] private float angerDecreaseAmount;

    [SerializeField] private float anger;

    private void Start() =>
        anger = 0;

    private void Update()
    {
        anger += angerIncreaseRatePerSecond * Time.deltaTime;

        if (anger > maxAnger)
        {
            OnBossIsAngry();
        }
    }

    public event Action BossIsAngry;

    public void OnCarRepaired() =>
        anger = Mathf.Max(0f, anger - angerDecreaseAmount);

    public void OnBossIsAngry()
    {
        Destroy(gameObject);
        BossIsAngry?.Invoke();
    }
}