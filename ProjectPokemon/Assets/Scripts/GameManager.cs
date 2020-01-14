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

    private static GameState gameState = GameState.Overworld;
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
    private void StartBattle(Trainer trainer){
        if(trainer.pokemon.Count <= 0){
            Debug.LogError($"Trainer: {trainer.trainerName} has no Pokemon");
            return;
        }
        Debug.Log("Start Battle");
        StartCoroutine(LoadBattleScene(trainer));

    }


    private IEnumerator LoadBattleScene(Trainer trainer){
        Debug.Log($"Loading battle against: {trainer.trainerTitle} {trainer.name}");
        AsyncOperation op = SceneManager.LoadSceneAsync("Battle Scene");
        while(!op.isDone){
            yield return null;
        }
        
    }



}
