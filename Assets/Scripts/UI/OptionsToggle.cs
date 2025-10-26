using UnityEngine;

public class OptionsToggle : MonoBehaviour
{
    public GameObject soundCheck;
    public GameObject musicCheck;
    public void OnMouseDown()
    {
        switch (gameObject.transform.name) 
        {
            case "Music On":
                MusicManager.mute = false;
                musicCheck.transform.localPosition += new Vector3(-186, 0, 0);
                break;
            case "Music Off":
                MusicManager.mute = true;
                musicCheck.transform.localPosition += new Vector3(186, 0, 0);
                break;
            case "Sound On":
                sfxManager.mute = false;
                soundCheck.transform.localPosition += new Vector3(-186, 0, 0);
                break;
            case "Sound Off":
                sfxManager.mute = true;
                soundCheck.transform.localPosition += new Vector3(186, 0, 0);
                break;
        }
    }
}
