using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveState
{
    internal static string fileName;

    internal static bool CheckSave(GameObject saveObject)
    {
        fileName = "Saves/" + saveObject.name + "Prefab";
        string localPath = "Assets/Resources/" + fileName + ".prefab";
        return File.Exists(localPath);
    }

    internal static void Save(GameObject saveObject)
    {
        if (!Directory.Exists("Assets/Resources/Saves"))
        {
            AssetDatabase.CreateFolder("Assets", "Resources");
            AssetDatabase.CreateFolder("Resources", "Saves");
        }
        fileName = "Saves/" + saveObject.name + "Prefab";
        string localPath = "Assets/Resources/"+ fileName +".prefab";
        if (!File.Exists(localPath)) {

            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            bool prefabSuccess = true;
            //PrefabUtility.SaveAsPrefabAsset(saveObject, localPath, out prefabSuccess);
            if (prefabSuccess == true)
            {
                Debug.Log("Prefab was saved successfully");
            }
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
        }
        else
        {
            File.Delete(localPath);
            bool prefabSuccess = true;
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            //PrefabUtility.SaveAsPrefabAsset(saveObject, localPath, out prefabSuccess);
            if (prefabSuccess == true)
            {
                Debug.Log("Prefab was saved successfully");
            }
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
        }

    }
}
