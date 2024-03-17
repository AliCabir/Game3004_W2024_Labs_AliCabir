using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            LoadGame();
        }
    }
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("SavedPositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("SavedPositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("SavedPositionZ", player.transform.position.z);

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedPositionX"))
        {
            float x = PlayerPrefs.GetFloat("SavedPositionX");
            float y = PlayerPrefs.GetFloat("SavedPositionY");
            float z = PlayerPrefs.GetFloat("SavedPositionZ");

            player.GetComponent<CharacterController>().enabled = false;
            player.position = new Vector3(x, y, z);
            player.GetComponent<CharacterController>().enabled = true;


            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    void ResetData()
    {
        PlayerPrefs.DeleteAll(); 
        
        Debug.Log("Data reset complete");
    }

}
