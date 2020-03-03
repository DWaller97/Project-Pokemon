using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAssetBundles
{
    [MenuItem("Project Pokemon/Create Bundles (OSX x64)")]
    public static void CreateAssetBundleMac(){
        BuildPipeline.BuildAssetBundles($"Assets/Bundles/Mac", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
    }
        [MenuItem("Project Pokemon/Create Bundles (W10 x64)")]
    public static void CreateAssetBundleWindows(){
        BuildPipeline.BuildAssetBundles($"Assets/Bundles/Windows", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
