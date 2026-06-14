using UnityEngine;
using UnityEngine.UI;

public class UIPanelWithMenuButton : UIPanel
{
    [SerializeField] private SwitchPlane _switchPlane;
    [SerializeField] private UIPanel _menu;
    public Button MenuButton;

    private void Awake()
    {
        ReloadButton.onClick.AddListener(ReloadScene);
        QuitButton.onClick.AddListener(AppQuit);
        MenuButton.onClick.AddListener(GoToMenu);
    }

    private void GoToMenu()
    {      
        _switchPlane.GetScreen(_menu);
    }
}
