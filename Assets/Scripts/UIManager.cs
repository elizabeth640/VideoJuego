using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;

    public Text livesLbl;
    public Text scoreLbl;
    public bool gamePause;
    public Transform uiPanel;
    public Transform uiPanelPreg;
    public Transform uiPanelPreg2;
    public Transform uiPanelPreg3;
    public Transform uiPanelPreg4;
    public Transform uiPanelPreg5;
    public Transform uiPanelPreg6;
    public int maxHealth = 5;//maximo de vidas
    public int score = 0;
    public int ScoreGive = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        obj = this;
    }

    void Start()
    {
        gamePause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives()
    {
        livesLbl.text = "" + PlayerController.obj.health;
    }

    public void updateScore()
    {
        scoreLbl.text = "" + score;
    }

    public void startGame()
    {
        AudioController.obj.playGui();
        gamePause = true;
        uiPanel.gameObject.SetActive(true);
        uiPanelPreg.gameObject.SetActive(false);
        uiPanelPreg2.gameObject.SetActive(false);
        uiPanelPreg3.gameObject.SetActive(false);
        uiPanelPreg4.gameObject.SetActive(false);
        uiPanelPreg5.gameObject.SetActive(false);
        uiPanelPreg6.gameObject.SetActive(false);
    }

    public void hidePanelPreg()
    {
        uiPanelPreg.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg2()
    {
        uiPanelPreg2.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg3()
    {
        uiPanelPreg3.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg4()
    {
        uiPanelPreg4.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg5()
    {
        uiPanelPreg5.gameObject.SetActive(true);
        gamePause = true;
    }

    public void hidePanelPreg6()
    {
        uiPanelPreg6.gameObject.SetActive(true);
        gamePause = true;
    }

    public void RIncorrecta()
    {
        AudioController.obj.playError();
    }

    public void RCorrecta()
    {
        AudioController.obj.playGood();
        gamePause = false;
        uiPanelPreg.gameObject.SetActive(false);
        uiPanelPreg2.gameObject.SetActive(false);
        uiPanelPreg3.gameObject.SetActive(false);
        uiPanelPreg4.gameObject.SetActive(false);
        uiPanelPreg5.gameObject.SetActive(false);
        uiPanelPreg6.gameObject.SetActive(false);
        //PlayerController.obj.addLive();
    }

    public void hideInitPanel()
    {
        AudioController.obj.playGui();
        gamePause = false;
        uiPanel.gameObject.SetActive(false);
    }

    public void addScore(int ScoreGive)
    {
        score += ScoreGive;
    }
    private void OnDestroy()
    {
        obj = null;
    }

}
