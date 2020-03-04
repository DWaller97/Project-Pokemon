using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    private static GameManager gameManagerRef;

    public static GameManager GetGameManager(){
        return gameManagerRef;
    }
    private void Start() {
        gameManagerRef = this;
        DontDestroyOnLoad(gameObject);
    }

    public enum GameState{
        Overworld,
        Battle,
        Menu
    };

    private static GameState gameState = GameState.Battle;
    public static Trainer trainer;
    public Trainer playerTrainer;
    private static bool stateLoaded = false;
    private void Update(){
        if(!stateLoaded){
            switch(gameState){
                case GameState.Overworld:
                stateLoaded = true;
                break;
                case GameState.Menu:
                stateLoaded = true;
                break;
                case GameState.Battle:
                StartBattle(trainer);
                stateLoaded = true;
                break;
                default:
                stateLoaded = true;
                break;
            }
        }
    }

    public static void ChangeGameState(GameState newState){
        gameState = newState;
            stateLoaded = false;
        Debug.Log($"Game State Changed to {newState}");
    }

    public static GameState GetGameState(){
        return gameState;
    }

    private void StartBattle(Trainer trainer){
        if(trainer.pokemon.Count <= 0){
            Debug.LogError($"Trainer: {trainer.trainerName} has no Pokemon");
            return;
        }
        Debug.Log("Start Battle");
        LoadBattleScene(trainer);

    }


    private void LoadBattleScene(Trainer trainer){
        Debug.Log($"Loading battle against: {trainer.trainerTitle} {trainer.name}");
        SceneManager.LoadScene("Battle Scene");
        
    }



}
