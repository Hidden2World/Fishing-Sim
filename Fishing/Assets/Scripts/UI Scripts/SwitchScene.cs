using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] string newGameScene;
void Update()
{

}

public void NextScene()
{
    SceneManager.LoadScene(newGameScene);
}

public void QuitGame()
    {
        Application.Quit();
    }
}
