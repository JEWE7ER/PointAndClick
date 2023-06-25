using UnityEngine.SceneManagement;
using UnityEngine;
using static SaveState;
using System;

public class GameManager : MonoBehaviour
{
    private GameObject loadState;

    public GameObject targetObject;
    public GameObject[] Rooms;

    private void Awake()
    {
        if (SaveState.CheckSave(targetObject))
        {
            Destroy(targetObject);
            loadState = Instantiate(Resources.Load<GameObject>(SaveState.fileName), transform, false);
            loadState.name = targetObject.name;
            loadState.transform.SetParent(targetObject.transform.parent);
            loadState.transform.SetSiblingIndex(targetObject.transform.GetSiblingIndex());
        }
    }

    internal void Transitions(string name)
    {
        GameObject SelectRoom = null;
        foreach (var room in Rooms) 
        {
            if (room.name.Equals(name))
            {
                SelectRoom = room;
            }
            room.SetActive(false);
        }
        SelectRoom.SetActive(true);
    }
}
