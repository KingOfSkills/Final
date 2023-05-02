using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
