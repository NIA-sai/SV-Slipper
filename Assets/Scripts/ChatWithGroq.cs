using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroqApiLibrary;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

public class ChatWithGroq : MonoBehaviour
{
    private const string apiKey = "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";
    [SerializeField]
    private string prePrompt;
    [SerializeField]
    private string preWords;
    [SerializeField]
    private GameObject lastChatPanel;
    private GroqApiClient groqApi;
    private TMP_Text text;
    //private InputField inputField;
    private bool finishOutPut = false;
    private bool skipDelay = false;
    public bool FinishOutPut { get => finishOutPut; }
    void Awake()
    {
        groqApi = new GroqApiClient(apiKey);
        text = GetComponent<TMP_Text>();
        text.text = preWords;
        finishOutPut = false;
        skipDelay = false;
    }
    void OnEnable()
    {
        Awake();
    }
    void Start()
    {

    }

    public async void Send(string userMessage)
    {
        userMessage = "(" + prePrompt + ")\n" + userMessage;
        if (!string.IsNullOrEmpty(userMessage))
        {
            var request = new JObject
            {
                ["model"] = "deepseek-r1-distill-llama-70b",
                ["temperature"] = 0.6,
                ["max_tokens"] = 1000,
                ["top_p"] = 1,
                //["stream"] = true,
                ["messages"] = new JArray
                {
                    new JObject { ["role"] = "user", ["content"] = userMessage }
                }
            };

            await GetChatCompletion(request);
        }
    }
    private async Task GetChatCompletion(JObject request)
    {
        text.text += "(请求中...)";
        var result = await groqApi.CreateChatCompletionAsync(request);
        var words = result?["choices"]?[0]?["message"]?["content"]?.ToString();
        if (words != null)
            words = words.Split("think")?[2] ?? "   无有效返回！";
        else
            words = "   无有效返回！";
        words = words.Substring(3);
        text.text = preWords;
        foreach (var word in words)
        {
            text.text += word;
            if (!skipDelay)
                await Task.Delay(100);
        }
        finishOutPut = true;
    }
    private void Update()
    {
        skipDelay = Input.GetKey(KeyCode.Space);
        if (finishOutPut && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
        {
            transform.parent.parent.gameObject.SetActive(false);
            lastChatPanel.SetActive(true);
        }
    }
}
