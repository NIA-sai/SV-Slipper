using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChatCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject trigger;
    private PlayerMovement playerMovement;
    void Start()
    {
        if (player != null)
            playerMovement = player.GetComponent<PlayerMovement>();
    }

    void OnEnable()
    {
        if (playerMovement != null)
            playerMovement.MovAble = false;

        if (trigger != null)
            trigger.SetActive(false);
    }
    void OnDisable()
    {
        if (playerMovement != null)
            playerMovement.MovAble = true;
        if (trigger != null)
            trigger.SetActive(true);
    }
    public void Update()
    {
        if (playerMovement?.MovAble ?? false && gameObject.activeSelf)
            OnEnable();
    }
}
