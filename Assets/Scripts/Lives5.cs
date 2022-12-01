using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
         {
            AudioController.obj.playLive();
            PlayerController.obj.addLive();//Añadir una vida
            //PlayerController.obj.Hit();
            UIManager.obj.hidePanelPreg5();
            UIManager.obj.updateLives();
            gameObject.SetActive(false);
            //Destroy(gameObject);
         }
    }
}
