using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    inMenu,
    inGame,
    inGameOver
}

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameState currentState = GameState.inMenu;

    public static GameManager sharedInstance;

     PlayerController controller;
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Submit") && currentState != GameState.inGame)
        {
            Game();
        }
    }

    public void Menu()
    {
        setGameState(GameState.inMenu);
    }

    public void Game()
    {
        setGameState(GameState.inGame);
    }
    
    public void GameOver()
    {
        setGameState(GameState.inGameOver);
    }


    void setGameState(GameState gameState)
    {
        if(gameState == GameState.inMenu)
        {

        }

        if(gameState == GameState.inGame)
        {
            controller.RestartGame();
        }

        if(gameState == GameState.inGameOver)
        {
            //controller.Die();
        }

        this.currentState = gameState;
    }
}
