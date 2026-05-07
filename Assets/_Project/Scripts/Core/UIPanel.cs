using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{ 
    public Button ReloadButton;
    public Button QuitButton;

    private void Update()
    {
        ReloadButton.onClick.AddListener(ReloadScene);
        QuitButton.onClick.AddListener(AppQuit);
    }

    private void ReloadScene() => SceneManager.LoadScene(0);

    private void AppQuit() => Application.Quit();
}
