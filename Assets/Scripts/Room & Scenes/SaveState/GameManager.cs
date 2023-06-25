using UnityEngine.SceneManagement;
using UnityEngine;
using static SaveState;

public class GameManager : MonoBehaviour
{
    internal bool isDefault = true;

    private GameObject prefab;

    public GameObject targetObject;

    void Awake()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (SaveState.scenesState.ContainsKey(index))
        {
            string Name = targetObject.name;
            Destroy(targetObject);
            prefab = Instantiate(Resources.Load<GameObject>(scenesState[index]), transform, false);
            prefab.name = Name;
            isDefault = false;
        }
    }
}
