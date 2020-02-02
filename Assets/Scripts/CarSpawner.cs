using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private float minCarDistance;
    [Space]
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [Space]
    [SerializeField] private float minAreaX;
    [SerializeField] private float maxAreaX;
    [SerializeField] private float minAreaY;
    [SerializeField] private float maxAreaY;
    [Space]
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;

    private float nextSpawnTime;
    private Vector2 lastCarPosition;

    private void Start() =>
        nextSpawnTime = 0;

    private void Update()
    {
        if (nextSpawnTime - Time.timeSinceLevelLoad > 0)
        {
            return;
        }

        StartCoroutine(InstantiateCar());
        nextSpawnTime += Random.Range(minSpawnTime, maxSpawnTime);
    }

    private IEnumerator InstantiateCar()
    {
        Vector2 carPosition;

        do
        {
            carPosition = new Vector2(
                            Random.Range(minAreaX, maxAreaX),
                            Random.Range(minAreaY, maxAreaY));
            yield return null;
        }
        while ((carPosition - lastCarPosition).magnitude < minCarDistance);

            lastCarPosition = carPosition;
            Quaternion carRotation = Quaternion.Euler(0f, 0f, Random.Range(minRotation, maxRotation));
            Instantiate(carPrefab, carPosition, carRotation);
    }
}