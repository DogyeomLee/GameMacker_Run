using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveManager
{
    private static GameSaveManager m_instance = null;

    private GameSaveManager() { }

    public static GameSaveManager Instance()
    {
        return m_instance ?? new GameSaveManager();
    }

    public void SaveGame(Transform playerTransform)
    {
        Debug.Log(JsonUtility.ToJson(playerTransform.position));

        PlayerPrefs.SetString("PlayerPosition", JsonUtility.ToJson(playerTransform.position));
        PlayerPrefs.SetString("PlayerRotation", JsonUtility.ToJson(playerTransform.rotation.eulerAngles));
        PlayerPrefs.Save();
        Debug.Log("Game Data Saved");
    }

    public void LoadGame(Transform playerTransform)
    {
        if(PlayerPrefs.HasKey("PlayerPosition"))
        {
            playerTransform.gameObject.GetComponent<CharacterController>().enabled = false;
            playerTransform.position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("PlayerPosition"));
            playerTransform.rotation = Quaternion.Euler(JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("PlayerRotation")));
            playerTransform.gameObject.GetComponent<CharacterController>().enabled = true;
            Debug.Log("Game Data Loaded");
        }
        else 
        {
            Debug.LogError("No Game Data Found!");
        }
        
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Game Data Cleared");
    }

}
