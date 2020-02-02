using UnityEngine;

public class GameOverDialog : MonoBehaviour
{
    [SerializeField] private Boss boss;

    [SerializeField] private GameObject gameOverDialogPrefab;
    [SerializeField] private Vector2 dialogPosition;
    private GameObject gameOverDialog;

    private void Awake() =>
        boss.IsAngry += Boss_IsAngry;

    private void Boss_IsAngry()
    {
        if (gameOverDialog != null)
        {
            return;
        }

        gameOverDialog = Instantiate(gameOverDialogPrefab, (Vector3)dialogPosition + new Vector3(0f, 0f, -9f), Quaternion.identity);
    }
}