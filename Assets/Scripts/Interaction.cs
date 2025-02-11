using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private UnityEvent unityEvent;
    [SerializeField]
    private KeyCode keyCode;
    private bool isPlayerEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        text?.gameObject?.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (text != null)
                text?.gameObject?.SetActive(true);
            isPlayerEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (text != null)
                text?.gameObject?.SetActive(false);
            isPlayerEnter = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerEnter && Input.GetKeyDown(keyCode))
           unityEvent?.Invoke();
           //  UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
