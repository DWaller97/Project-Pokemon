using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public Transform playerPosition, enemyPosition;
    public GameManager managerRef;
    static Dictionary<string, Object> loadedBundles;
    void Start()
    {
        loadedBundles = new Dictionary<string, Object>();
        managerRef = GameManager.GetGameManager();
        //Go through all the Pokemon and load any.
        //Check for duplicates.
        LoadTrainerPokemon(managerRef.playerTrainer, playerPosition.position);
        //LoadTrainerPokemon(GameManager.trainer, enemyPosition.position);
    }

    IEnumerator LoadAsset(string bundleName){
        if(loadedBundles.ContainsKey(bundleName))
        {
            Debug.LogWarning($"{bundleName} already loaded.");
            yield break;
        }

        AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync($"Assets/Bundles/Mac/pokemon.{bundleName}");
        yield return req;
        AssetBundle bundle = req.assetBundle;
        if(bundle == null){
            Debug.LogError("Asset failed to load");
            yield break;
        }
        AssetBundleRequest assetLoadReq = bundle.LoadAssetAsync<GameObject>(bundleName);
        yield return assetLoadReq;

        GameObject prefab = assetLoadReq.asset as GameObject;
        
        loadedBundles.Add(bundleName, assetLoadReq.asset);
    }
    void LoadTrainerPokemon(Trainer trainer, Vector3 position){
        if(!loadedBundles.ContainsKey(trainer.pokemon[0].species.name))
            StartCoroutine(LoadAsset(trainer.pokemon[0].species.name));
        Object pkmn;
        loadedBundles.TryGetValue(trainer.pokemon[0].species.name, out pkmn);

        Instantiate(pkmn as GameObject, position, Quaternion.identity);
    }


    void Update()
    {
        
    }
}
