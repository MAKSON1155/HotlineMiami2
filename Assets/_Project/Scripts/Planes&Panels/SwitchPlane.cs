using UnityEngine;

public class SwitchPlane : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _spawner;

    [SerializeField] private UIPanel _menu;
    [SerializeField] private UIPanel _win;

    private void OnEnable()
    {
        _player.HasDamaged += SwitchToScreenMenu;
        _spawner.HasDamaged += SwitchToScreenWin;
    }

    private void OnDisable()
    {
        _player.HasDamaged -= SwitchToScreenMenu;
        _spawner.HasDamaged -= SwitchToScreenWin;
    }

    public void SwitchToScreenMenu()
    {
        _menu.gameObject.SetActive(true);
        DeactiveScreenWin();
    }

    public void DeactiveScreenMenu()
    {
        _menu.gameObject.SetActive(false);
    }

    public void SwitchToScreenWin()
    {
        _win.gameObject.SetActive(true);
        DeactiveScreenMenu();
    }

    public void DeactiveScreenWin()
    {
        _win.gameObject.SetActive(false);
    }
}
