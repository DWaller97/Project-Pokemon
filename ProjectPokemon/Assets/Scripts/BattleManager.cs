using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public Transform playerPosition, enemyPosition;
    public GameManager managerRef;
    void Start()
    {
        managerRef = GameManager.GetGameManager();
        StartCoroutine(LoadTrainerPokemon(GameManager.trainer, enemyPosition.position));
        StartCoroutine(LoadTrainerPokemon(managerRef.playerTrainer, playerPosition.position));
    }

    IEnumerator LoadTrainerPokemon(Trainer trainer, Vector3 position){
        AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync($"Assets/Bundles/Mac/Pokemon.{trainer.pokemon[0].species.name}");
        while(!req.isDone){
            yield return null;
        }
        Debug.Log(req.assetBundle.name);
        Instantiate(req.assetBundle, position, Quaternion.identity);
    }


    void Update()
    {
        
    }
}
