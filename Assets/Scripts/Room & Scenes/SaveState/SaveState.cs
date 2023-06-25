using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveState
{
    //internal static Dictionary<int, Scene> scenesState = new Dictionary<int, Scene>();
    internal static Dictionary<int, string> scenesState = new Dictionary<int, string>();
    
    internal static void Save(GameObject saveObject)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (!scenesState.ContainsKey(index))
        {
            if (!Directory.Exists("Assets/Resources/Saves"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
                AssetDatabase.CreateFolder("Resources", "Saves");
            }
            string name = "Saves/" + saveObject.name + "Prefab";
            string localPath = "Assets/Resources/Saves/" + saveObject.name + "Prefab.prefab";
            if (File.Exists(localPath))
                File.Delete(localPath);

            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            bool prefabSuccess;
            PrefabUtility.SaveAsPrefabAsset(saveObject, localPath, out prefabSuccess);
            if (prefabSuccess == true)
            {
                scenesState.Add(index, name);
                Debug.Log("Prefab was saved successfully");
            }
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
        }
        else
        {
            string localPath = "Assets/Resources/Saves/" + saveObject.name + "Prefab.prefab";
            File.Delete(localPath);
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAsset(saveObject, localPath);
        }            
    }
    //internal static GameObject GetScene(int index)
    //{
    //    //return scenesState[index];
    //}
}
