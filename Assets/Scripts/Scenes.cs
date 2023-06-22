using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    internal void LoadRoom(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    //internal void PrevRoom(string Name)
    //{
    //    var index = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(Name);
    //}
}
