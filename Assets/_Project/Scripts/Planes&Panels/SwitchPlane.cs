using UnityEngine;

public class SwitchPlane : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _spawner;

    [SerializeField] private UIPanel _menu;
    [SerializeField] private UIPanel _win;
    [SerializeField] private UIPanel _lose;
    [SerializeField] private PlayerUI _UI;
    private UIPanel _currentScreen;

    private void OnEnable()
    {
        _player.HasDamaged += GetScreenLose;
        _spawner.HasNoMore += GetScreenWin;
    }

    private void OnDisable()
    {
        _player.HasDamaged -= GetScreenLose;
        _spawner.HasNoMore -= GetScreenWin;
    }

    private void Update()
    {
        if (_currentScreen == null)
            return;

        SwitchScreen();
    }

    public void GetScreen(UIPanel panel) => _currentScreen = panel;

    public void SwitchScreen()
    {
        if (_currentScreen == null)
            return;

        _currentScreen.gameObject.SetActive(true);
        DeactiveOtherScreens();
    }

    private void GetScreenLose() => _currentScreen = _lose;
    private void GetScreenWin() => _currentScreen = _win;

    private void DeactiveOtherScreens()
    {
        if (_currentScreen == _menu)
        {
            _win.Deactive();
            _lose.Deactive();
            _UI.Deactive();
        }
        else if (_currentScreen == _win)
        {
            _menu.Deactive();
            _lose.Deactive();
            _UI.Deactive();
        }
        else
        {
            _menu.Deactive();
            _win.Deactive();
            _UI.Deactive();
        }
    }
}
