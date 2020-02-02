using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private const int maxAnger = 100;

    [SerializeField] private float angerIncreaseRatePerSecond;
    [SerializeField] private float angerDecreaseAmount;

    private float anger;

    private void Start() =>
        anger = 0;

    private void Update()
    {
        anger += angerIncreaseRatePerSecond * Time.deltaTime;

        if (anger > maxAnger)
        {
            BossIsAngry?.Invoke();
        }
    }

    public event Action BossIsAngry;

    public void OnCarRepaired() =>
        anger -= angerDecreaseAmount;
}