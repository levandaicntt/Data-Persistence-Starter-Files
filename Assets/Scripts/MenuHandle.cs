using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandle : MonoBehaviour
{
    TextMeshProUGUI highScoreText;
    TextMeshProUGUI nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
    }

    void Start()
    {
        highScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        Debug.Log(MenuData.instance != null ? "MenuData.instance exists!" : "MenuData.instance is NULL!");
        if (MenuData.instance != null)
        {
            highScoreText.text = "Best Score: " + MenuData.instance.highScoreData.name + " : " + MenuData.instance.highScoreData.score;
        }

        TMP_InputField nameInput = GameObject.FindFirstObjectByType<TMP_InputField>();
        if (nameInput != null)
        {
            nameText = nameInput.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void StartButton()
    {
        if (nameText != null)
        {
            MenuData.instance.presentData.name = nameText.text;
        }
        SceneManager.LoadScene("Main");
    }

    public void ExitButton()
    {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
