using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    public void OnOptionsClickX()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnMenuClickOptions()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
