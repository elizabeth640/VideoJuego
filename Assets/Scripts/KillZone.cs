using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    Vector2 posini;
    // Start is called before the first frame update
    void Start()
    {
        posini = PlayerController.obj.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioController.obj.playCaida();
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.obj.Hit();
            if(PlayerController.obj.health !=0)
            {
                PlayerController.obj.transform.position = posini;
            }
        }
    }
}
