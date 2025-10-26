using UnityEngine;

public class HintButtonMainMenu : MonoBehaviour
{
    public MenuController menuController;
    public void OnMouseDown()
    {
        menuController.hintMenu = true;
    }
}
