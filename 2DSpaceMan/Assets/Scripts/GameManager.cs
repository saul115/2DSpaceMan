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
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && currentState != GameState.inGame)
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

        }

        if(gameState == GameState.inGameOver)
        {

        }

        this.currentState = gameState;
    }
}
