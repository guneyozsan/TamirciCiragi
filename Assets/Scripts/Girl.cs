using UnityEngine;

public class Girl : MonoBehaviour
{
    private const int maxLove = 100;

    [SerializeField] private float deltaLove;

    [SerializeField] private float love;

    private void Start()
    {
        love = 0;
    }

    private void OnMouseUp()
    {
        float deltaLoveRatio = deltaLove / (maxLove - love);
        love += deltaLove;
        deltaLove = deltaLoveRatio * (maxLove - love);
    }
}