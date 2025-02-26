using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoadController : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    UnityEvent unityEvent;

    public void LoadScene()
    {
        if (sceneName == null)
            return;
        if (unityEvent != null) unityEvent.Invoke();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
}
