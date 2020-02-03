using System.Collections;
using UnityEngine;

public class LevelReloader : MonoBehaviour
{
    [SerializeField] private Boss boss;

    private void Awake() =>
        boss.IsAngry += Boss_IsAngry;

    private void Boss_IsAngry()
    {
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}