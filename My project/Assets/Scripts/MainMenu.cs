using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    public CreditMenu creditMenu;
    public OptionMenu optionMenu;
    // Start is called before the first frame update
    void Start()
    {
        setBtnActions();
    }

    private void setBtnActions()
    {
        Transform playButton = transform.Find("PlayButton");
        playButton.GetComponent<Button>().onClick.AddListener(delegate { playClicked(); });
        Transform soundButton = transform.Find("OptionsButton");
        soundButton.GetComponent<Button>().onClick.AddListener(delegate { optionsClicked(); });
        Transform creditsButton = transform.Find("CreditsButton");
        creditsButton.GetComponent<Button>().onClick.AddListener(delegate { creditsClicked(); });
        Transform quitButton = transform.Find("QuitButton");
        quitButton.GetComponent<Button>().onClick.AddListener(delegate { quitClicked(); });
    }
    private void playClicked()
    {
        SceneManager.LoadSceneAsync("map");
    }
    private void optionsClicked()
    {
        optionMenu.show(true);
        show(false);
    }
    private void creditsClicked()
    {
        creditMenu.show(true);
        show(false);
    }
    private void quitClicked()
    {
        Application.Quit();
    }
}
