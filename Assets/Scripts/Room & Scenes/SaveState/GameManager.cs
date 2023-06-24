using UnityEngine.SceneManagement;
using UnityEngine;
using static SaveState;

public class GameManager : MonoBehaviour
{
    internal bool destroy = false;

    //private GameObject enableObject;

    public GameObject targetObject;

    void Start()
    {
        //int index = SceneManager.GetActiveScene().buildIndex;
        //string nameTag;
        ////if (SaveState.scenesState.ContainsKey(index))
        ////{
        ////    destroy = true;
        ////    Destroy(destroyObject);
        ////    //SceneManager.SetActiveScene(SaveState.GetScene(index));
        ////}
        //for (int i = 0; i < SaveState.scenesState.Count; i++)
        //{
        //    if (index != i)
        //        enableObject.SetActive(false);
        //    else
        //        targetObject.SetActive(true);
        //}
    }

}
