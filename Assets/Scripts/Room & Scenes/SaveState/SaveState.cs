using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveState
{
    //internal static Dictionary<int, Scene> scenesState = new Dictionary<int, Scene>();
    internal static Dictionary<int, string> scenesState = new Dictionary<int, string>();
    
    internal static void Save()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        string sceneValue = SceneManager.GetActiveScene().name;
        if (!scenesState.ContainsKey(index))
            scenesState.Add(index, sceneValue);

        else
            scenesState[index] = sceneValue;
    }
    internal static string GetScene(int index)
    {
        return scenesState[index];
    }
}
