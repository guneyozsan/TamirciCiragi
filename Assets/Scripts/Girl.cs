using UnityEngine;

public class Girl : MonoBehaviour
{
    private const int maxLove = 100;

    [SerializeField] private float deltaLove;
    [SerializeField] private ProgressBar progressBar;

    private float love;

    public float Love
    {
        get { return love; }
        set
        {
            love = value;
            OnLoveChanged();
        }
    }

    private void Start() =>
        Love = 0;

    private void OnMouseUp()
    {
        float deltaLoveRatio = deltaLove / (maxLove - Love);
        Love += deltaLove;
        deltaLove = deltaLoveRatio * (maxLove - Love);
    }

    private void OnLoveChanged() =>
        progressBar.BarValue = Love;
}