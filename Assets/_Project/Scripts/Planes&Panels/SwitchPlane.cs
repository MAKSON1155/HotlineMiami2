using UnityEngine;

public class SwitchPlane : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _spawner;

    [SerializeField] private UIPanel _menu;
    [SerializeField] private UIPanel _win;
    [SerializeField] private UIPanel _lose;
    private UIPanel _currentScreen;
    private void OnEnable()
    {
        _player.HasDamaged += GetScreenLose;
        _spawner.HasDamaged += GetScreenWin;
    }

    private void OnDisable()
    {
        _player.HasDamaged -= GetScreenLose;
        _spawner.HasDamaged -= GetScreenWin;
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
        _currentScreen.gameObject.SetActive(true);
        DeacriveOtherScreens();
    }

    private void GetScreenLose() => _currentScreen = _lose;
    private void GetScreenWin() => _currentScreen = _win;

    private void DeacriveOtherScreens()
    {
        if (_currentScreen == _menu)
        {
            _win.Deactive();
            _lose.Deactive();
        }
        else if (_currentScreen == _win)
        {
            _menu.Deactive();
            _lose.Deactive();
        }
        else
        {
            _menu.Deactive();
            _win.Deactive();
        }
    }
}
