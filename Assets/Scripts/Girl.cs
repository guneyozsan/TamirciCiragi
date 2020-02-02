using UnityEngine;

public class Girl : MonoBehaviour
{
    private const int maxLove = 100;

    [SerializeField] private float loveIncreaseAmount;
    [SerializeField] private float loveDecreaseRate;
    [SerializeField] private ProgressBar progressBar;

    private float love;

    private void Start() =>
        Love = 0;

    private void FixedUpdate() =>
        Love -= loveDecreaseRate * Time.deltaTime;

    private void OnMouseUp()
    {
        float deltaLoveRatio = loveIncreaseAmount / (maxLove - Love);
        Love += loveIncreaseAmount;
        loveIncreaseAmount = deltaLoveRatio * (maxLove - Love);
    }

    public float Love
    {
        get { return love; }
        set
        {
            love = Mathf.Max(0f, value);
            OnLoveChanged();
        }
    }

    private void OnLoveChanged() =>
        progressBar.BarValue = Love;
}