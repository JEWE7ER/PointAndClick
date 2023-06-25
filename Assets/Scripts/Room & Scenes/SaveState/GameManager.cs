using UnityEngine.SceneManagement;
using UnityEngine;
using static SaveState;

public class GameManager : MonoBehaviour
{
    internal bool isDefault = true;

    private GameObject prefab;

    public GameObject targetObject;

    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (SaveState.scenesState.ContainsKey(index))
        {
            Destroy(targetObject);
            prefab = Instantiate(Resources.Load<GameObject>(scenesState[index]), transform, false);
            prefab.name = targetObject.name;
            prefab.transform.SetParent(targetObject.transform.parent);
            prefab.transform.SetSiblingIndex(targetObject.transform.GetSiblingIndex());
            isDefault = false;
        }
    }
}
