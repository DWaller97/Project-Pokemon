using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager gameManagerRef;

    public static GameManager GetGameManager(){
        return gameManagerRef;
    }
    private void Start() {
        gameManagerRef = this;
    }

    public enum GameState{
        Overworld,
        Battle,
        Menu
    };

    public static GameState gameState = GameState.Overworld;
    private void Update(){
        
        if(Input.GetKeyDown(KeyCode.A)){
            gameState = GameState.Battle;
        }
        
        switch(gameState){
            case GameState.Overworld:
            break;
            case GameState.Menu:
            break;
            case GameState.Battle:

            break;
            default:
            break;
        }
    
    }

    private void StartBattle(Trainer trainer){
        if(trainer.pokemon.Count <= 0){
            Debug.LogError($"Trainer: {trainer.trainerName} has no Pokemon");
            return;
        }
    }





}
