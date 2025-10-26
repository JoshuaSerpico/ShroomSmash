using UnityEngine;

public class CloseButtonMainMenu : MonoBehaviour
{
    public MenuController menuController;

    public void OnMouseDown()
    {
        menuController.hintMenu = false;
    }
}
