using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string MainScenePath = "MainScene";
    [SerializeField] private string InfoScenePath = "InfoScene";
    [SerializeField] private string MenuScenePath = "MenuScene";
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
}
