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
        //Go through all the Pokemon and load any.
        //Check for duplicates.
        if(managerRef.playerTrainer.pokemon[0] == GameManager.trainer.pokemon[0]){
            StartCoroutine(LoadTrainerPokemon(GameManager.trainer, enemyPosition.position));
        }else{
            StartCoroutine(LoadTrainerPokemon(managerRef.playerTrainer, playerPosition.position));
            StartCoroutine(LoadTrainerPokemon(GameManager.trainer, enemyPosition.position));
        }
    }

    IEnumerator LoadTrainerPokemon(Trainer trainer, Vector3 position){
        AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync($"Assets/Bundles/Mac/pokemon.charizard");
        if(req.assetBundle == null)
            yield break;
        while(!req.isDone){
            yield return null;
        }
        Debug.Log(req.assetBundle.name);
        AssetBundleRequest bundle = req.assetBundle.LoadAssetAsync<GameObject>(trainer.pokemon[0].name);
        while(!bundle.isDone){
            yield return null;
        }
        GameObject obj = (GameObject)bundle.asset;
        Instantiate(obj, position, Quaternion.identity);
    }


    void Update()
    {
        
    }
}
