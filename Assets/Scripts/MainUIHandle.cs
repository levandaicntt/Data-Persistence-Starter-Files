using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandle : MonoBehaviour
{
    public void ReturnButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
