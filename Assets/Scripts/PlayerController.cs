using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Object;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string playerDataFileName;
    private SaveController<PlayerData> saveController;
    void Start()
    {
        saveController = new SaveController<PlayerData> { fileName = playerDataFileName };
        saveController.Start();
        PlayerData playerData = saveController.LoadSaveData();
        if (playerData == null)
        {
            playerData = new PlayerData() { posX = transform.position.x, posY = transform.position.y };
            saveController.SaveSaveData(playerData);
        }
        else
        {
            print("Load Player Data" + playerDataFileName + ":" + playerData.posX + ":" + playerData.posY);
            transform.position = new Vector2(playerData.posX, playerData.posY);
        }
    }
    public void SavePlayerData()
    {
        PlayerData playerData = new PlayerData() { posX = transform.position.x, posY = transform.position.y };
        saveController.SaveSaveData(playerData);
    }
}
