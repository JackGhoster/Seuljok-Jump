using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string MainScenePath = "MainScene";
    [SerializeField] private string InfoScenePath = "InfoScene";
    [SerializeField] private string MenuScenePath = "MenuScene";

    public Button SoundButton;
    public Sprite mutedSound;
    public Sprite unmutedSound;
    public Sprite mutedSoundHighlight;
    public Sprite unmutedSoundHighlight;
    private bool soundToggle = true;

    private void Start()
    {
        if (AudioListener.volume == 0)
        {
            ButtonSpriteAndHighlightChanger(SoundButton, unmutedSound, unmutedSoundHighlight);
            soundToggle = false;
        }
        else
        {
            soundToggle = true;
            ButtonSpriteAndHighlightChanger(SoundButton, mutedSound, mutedSoundHighlight);
        }
        Debug.Log(soundToggle);
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(MainScenePath);
    }

    public void OnInfoButton()
    {
        SceneManager.LoadScene(InfoScenePath);
    }

    public void OnReturnButton()
    {
        SceneManager.LoadScene(MenuScenePath);
    }

    public void OnSoundButton()
    {
        soundToggle = !soundToggle;


        if (soundToggle == false)
        {
            AudioListener.volume = 0;
            ButtonSpriteAndHighlightChanger(SoundButton, unmutedSound, unmutedSoundHighlight);
        }
        else
        {
            AudioListener.volume = 1;
            ButtonSpriteAndHighlightChanger(SoundButton,mutedSound,mutedSoundHighlight);
        }
    }

    protected void ButtonSpriteAndHighlightChanger(Button btn,Sprite sprite, Sprite highlight)
    {
        btn.image.sprite = sprite;
        SpriteState ss = new SpriteState();
        ss.highlightedSprite = highlight;
        btn.spriteState = ss;
    }
}
