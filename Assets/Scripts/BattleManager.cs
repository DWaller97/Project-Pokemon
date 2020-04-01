using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public Transform playerPosition, enemyPosition;
    public GameManager managerRef;
    static Dictionary<string, Object> loadedBundles;

    public enum AttackEffectiveness{
        NoEffect,
        NotVeryEffective,
        Normal,
        SuperEffective
    };

    void Start()
    {
        loadedBundles = new Dictionary<string, Object>();
        managerRef = GameManager.GetGameManager();
        //Go through all the Pokemon and load any.
        //Check for duplicates.
        // LoadAndInstantiate(managerRef.playerTrainer, playerPosition.position, Quaternion.identity); //Make it work ASync
        // LoadAndInstantiate(GameManager.trainer, enemyPosition.position, Quaternion.Euler(0, 180, 0));
        LoadTrainerPokemon(managerRef.playerTrainer, playerPosition.position);
        LoadTrainerPokemon(GameManager.trainer, enemyPosition.position);
    }

    void LoadAndInstantiate(Trainer trainer, Vector3 pos, Quaternion rot){
        GameObject obj;
        Object objToConvert;
        string bundleName = trainer.pokemon[0].species.name;
        if(loadedBundles.ContainsKey(bundleName)){
            if(loadedBundles.TryGetValue(bundleName, out objToConvert)){
                obj = Instantiate((GameObject)objToConvert, pos, rot);
            }
        }else{
            AssetBundle bundle = AssetBundle.LoadFromFile($"Assets/Bundles/Mac/pokemon.{bundleName}");
            objToConvert = bundle.LoadAsset(bundleName);
            loadedBundles.Add(bundleName, objToConvert);
            obj = Instantiate(objToConvert as GameObject, pos, rot);
        }
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
