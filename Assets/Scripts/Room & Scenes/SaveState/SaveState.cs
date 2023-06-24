using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveState
{
    //internal static Dictionary<int, Scene> scenesState = new Dictionary<int, Scene>();
    internal static Dictionary<int, GameObject> scenesState = new Dictionary<int, GameObject>();
    
    internal static void Save(GameObject saveObject)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (!scenesState.ContainsKey(index))
            scenesState.Add(index, saveObject);

        else
            scenesState[index] = saveObject;
    }
    internal static GameObject GetScene(int index)
    {
        return scenesState[index];
    }
}
