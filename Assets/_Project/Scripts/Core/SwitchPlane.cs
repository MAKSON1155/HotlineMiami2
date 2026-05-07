using UnityEngine;

public class SwitchPlane : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    public UIPanel menu;
    public UIPanel win;

    //private void OnEnable()
    //{
    //    _player.HasDamaged += ActiveScreenMenu;
    //    _enemy.HasDamaged += ActiveScreenWin;
    //}

    //private void OnDisable()
    //{
    //    _player.HasDamaged -= ActiveScreenMenu;
    //    _enemy.HasDamaged -= ActiveScreenWin;
    //}

    public void ActiveScreenMenu()
    {
        menu.gameObject.SetActive(true);
    }

    public void DeactiveScreenMenu()
    {
        menu.gameObject.SetActive(false);
    }

    public void ActiveScreenWin()
    {
        win.gameObject.SetActive(true);
    }

    public void DeactiveScreenWin()
    {
        win.gameObject.SetActive(false);
    }

}
