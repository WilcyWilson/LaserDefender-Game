using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    public bool singlePlayer;

    public void LoadGameOver()
    {
        StartCoroutine(DelayLoad());
    }

    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        Cursor.visible = true;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayerChoose()
    {
        SceneManager.LoadScene("Player Choose");
        Cursor.visible = true;
    }
    public void OnePlayer()
    {
        singlePlayer = true;
        LoadGameScene();
    }

    public void TwoPlayers()
    {
        singlePlayer = false;
        LoadGameScene();
    }

    public void Control()
    {
        SceneManager.LoadScene("Controls");
    }

   


}
