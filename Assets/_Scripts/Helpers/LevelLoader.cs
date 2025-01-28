using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        AudioManager.instance.PlayClickSFX();
        SceneManager.LoadScene(SceneNames.GameScene);
    }
    public void LoadMainMenu()
    {
        AudioManager.instance.PlayClickSFX();
        AudioManager.instance.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(SceneNames.MainMenuScene);
    }
}
