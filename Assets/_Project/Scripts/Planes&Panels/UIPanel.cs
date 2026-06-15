using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Button ReloadButton;
    public Button QuitButton;   

    private void Awake()
    {
        ReloadButton.onClick.AddListener(ReloadScene);
        QuitButton.onClick.AddListener(AppQuit);     
    }

    public void Deactive() => gameObject.SetActive(false);

    protected void ReloadScene() => SceneManager.LoadScene(1);

    protected void AppQuit() => Application.Quit();
}
