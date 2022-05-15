using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditMenu : Menu
{
    public MainMenu mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        Transform playButton = transform.Find("BackButton");
        playButton.GetComponent<Button>().onClick.AddListener(delegate { backClicked(); });
    }
    private void backClicked()
    {
        show(false);
        mainMenu.show(true);

    }

}
