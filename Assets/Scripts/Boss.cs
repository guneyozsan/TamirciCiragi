using System;
using UnityEngine;

public class Boss : MonoBehaviour, IProgressUpdated
{
    private const int maxAnger = 100;

    [SerializeField] private float angerIncreaseRatePerSecond;
    [SerializeField] private float angerDecreaseAmount;
    [SerializeField] private ProgressBar progressBar;

    private float anger;

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

    public event Action IsAngry;
    public event Action<float> ProgressUpdated;

    public float Anger
    {
        get { return anger; }
        set
        {
            anger = Mathf.Max(0f, value);
            OnAngerUpdated();
        }
    }

    public void OnCarRepaired() =>
        Anger = Anger - angerDecreaseAmount;

    public void OnBossIsAngry() =>
        IsAngry?.Invoke();

    private void OnAngerUpdated()
    {
        progressBar.BarValue = Anger;
        ProgressUpdated?.Invoke(Anger);
    }
}