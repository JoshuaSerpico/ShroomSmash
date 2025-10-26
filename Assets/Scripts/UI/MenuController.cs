using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public bool hintMenu = false;
    public GameObject menu;
    public GameObject hint;

    public void Update()
    {
        if (hint == null) return;
        if (menu == null) return;
        {
            
        }
        if (hintMenu)
        {
            hint.SetActive(true);
            menu.SetActive(false);
        }
        else 
        {
            hint.SetActive(false);
            menu.SetActive(true);
        }
    }
}
