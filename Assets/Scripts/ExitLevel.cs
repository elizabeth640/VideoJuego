using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public int scene;
    public GameObject transition;
    public GameObject canvas;
    public GameObject canvasGameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioController.obj.playExit();
            transition.SetActive(true);
            canvas.SetActive(false);
            Invoke("ChangeLevel", 5.0f);
        }
    }

    private void Update()
    {
        if(PlayerController.obj.health == 0)
        {
            AudioController.obj.playGameOver();
            transition.SetActive(true);
            canvas.SetActive(false);
            canvasGameOver.SetActive(true);
        }
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(scene);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
