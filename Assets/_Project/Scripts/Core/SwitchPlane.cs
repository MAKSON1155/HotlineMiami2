using UnityEngine;

public class SwitchPlane : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyCounter _enemyCounter;

    public UIPanel menu;
    public UIPanel win;

    private void OnEnable()
    {
        _player.HasDamaged += SwitchToScreenMenu;
        _enemyCounter.HasWon += SwitchToScreenWin;
    }

    private void OnDisable()
    {
        _player.HasDamaged -= SwitchToScreenMenu;
        _enemyCounter.HasWon -= SwitchToScreenWin;
    }

    public void SwitchToScreenMenu()
    {
        menu.gameObject.SetActive(true);
        DeactiveScreenWin();
    }

    public void DeactiveScreenMenu()
    {
        menu.gameObject.SetActive(false);
    }

    public void SwitchToScreenWin()
    {
        win.gameObject.SetActive(true);
        DeactiveScreenMenu();
    }

    public void DeactiveScreenWin()
    {
        win.gameObject.SetActive(false);
    }
}
