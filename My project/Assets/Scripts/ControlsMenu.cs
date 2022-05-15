using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : Menu
{
    public MainMenu mainMenu;

    void Start() {
        Transform playButton = transform.Find("BackButton");
        playButton.GetComponent<Button>().onClick.AddListener(delegate { backClicked(); });
    }

    private void backClicked() {
        show(false);
        mainMenu.show(true);
    }
}