using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class InputFieldController : MonoBehaviour
{
    private TMP_InputField inputField;
    [SerializeField]
    private GameObject nextChatPanel;
    [SerializeField]
    private UnityEvent<string> sendTo;
    void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }
    public void StartInput()
    {
        inputField.text = "";
        StartCoroutine(SelectInputField());
        Debug.Log(inputField.isFocused);
    }
    private IEnumerator SelectInputField()
    {
        yield return null;
        inputField.Select();
        inputField.ActivateInputField();
    }
    void OnEnable()
    {
        StartInput();
    }
    public void SentInput()
    {
        if (inputField.text.Length < 1) return;
        if (nextChatPanel != null)
        {
            transform.parent.gameObject.SetActive(false);
            nextChatPanel.SetActive(true);
            sendTo.Invoke(inputField.text);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.parent.parent.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SentInput();
        }
    }
}
