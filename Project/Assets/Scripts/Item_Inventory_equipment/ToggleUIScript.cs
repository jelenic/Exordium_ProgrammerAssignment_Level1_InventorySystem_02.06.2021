using UnityEngine;

public class ToggleUIScript : MonoBehaviour
{
    public GameObject btn;
    public GameObject menu;
    // Update is called once per frame
    public void OnClick()
    {
        if (btn.activeSelf)
        {
            btn.SetActive(false);
            menu.SetActive(true);
        }
        else
        {
            btn.SetActive(true);
            menu.SetActive(false);
        }
        
    }

}
