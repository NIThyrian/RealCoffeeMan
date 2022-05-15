using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MainMenu
{


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
        Transform controlsButton = transform.Find("ControlsButton");
        controlsButton.GetComponent<Button>().onClick.AddListener(delegate { controlsClicked(); });
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

    private void controlsClicked()
    {
        controlsMenu.show(true);
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
