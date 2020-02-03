using UnityEngine;

public class OnClickLoadGame : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
