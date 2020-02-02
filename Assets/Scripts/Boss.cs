using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private const int maxAnger = 100;

    [SerializeField] private float angerIncreaseRatePerSecond;
    [SerializeField] private float angerDecreaseAmount;
    [SerializeField] private ProgressBar progressBar;

    private float anger;

    public float Anger
    {
        get { return anger; }
        set
        {
            anger = value;
            OnAngerUpdated();
        }
    }

    private void Start() =>
        Anger = 0;

    private void Update()
    {
        Anger += angerIncreaseRatePerSecond * Time.deltaTime;

        if (Anger > maxAnger)
        {
            OnBossIsAngry();
        }
    }

    public event Action BossIsAngry;

    public void OnCarRepaired() =>
        Anger = Mathf.Max(0f, Anger - angerDecreaseAmount);

    public void OnBossIsAngry()
    {
        Destroy(gameObject);
        BossIsAngry?.Invoke();
    }

    private void OnAngerUpdated()
    {
        progressBar.BarValue = anger;
    }
}