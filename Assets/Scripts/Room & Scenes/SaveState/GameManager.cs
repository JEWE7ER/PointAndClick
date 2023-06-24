using UnityEngine.SceneManagement;
using UnityEngine;
using static SaveState;

public class GameManager : MonoBehaviour
{
    internal bool destroy = false;
    private GameObject enableObject;

    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        //if (SaveState.scenesState.ContainsKey(index))
        //{
        //    destroy = true;
        //    Destroy(destroyObject);
        //    //SceneManager.SetActiveScene(SaveState.GetScene(index));
        //}
        for (int i = 0; i < SaveState.scenesState.Count; i++)
        {
            string nameTag = SaveState.GetScene(i);
            enableObject = GameObject.FindGameObjectWithTag(nameTag);
            if (i != index)
                enableObject.SetActive(false);
            else
                enableObject.SetActive(true);
        }
    }

}
