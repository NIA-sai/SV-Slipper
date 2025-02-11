using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroqApiLibrary;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

public class ChatWithGroq : MonoBehaviour
{
    private string apiKey = "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";
    [SerializeField]
    private string prePrompt;

    private GroqApiClient groqApi;
    private TMP_Text text;
    //private InputField inputField;
    void Start()
    {
        groqApi = new GroqApiClient(apiKey);
        text = GetComponent<TMP_Text>();
        text.text = "  ";
    }
    public  void Sends(string userMessage)
    {
        print(userMessage);
        for (int i = 0; i < 10; i++)
        {
            text.text += userMessage;
        }
    }
    public async void Send(string userMessage)
    {
        userMessage = prePrompt + "\n" + userMessage;
        if (!string.IsNullOrEmpty(userMessage))
        {
            var request = new JObject
            {
                ["model"] = "deepseek-r1-distill-llama-70b",
                ["temperature"] = 0.6,
                ["max_tokens"] = 100,
                ["top_p"] = 1,
                ["stream"] = true,
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
        var result = groqApi.CreateChatCompletionStreamAsync(request);
        await foreach (var word in result)
        {
            text.text += word;
            print(word);
        }
    }
    private void Update()
    {
    }
}
