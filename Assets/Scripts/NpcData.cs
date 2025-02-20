using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcData : MonoBehaviour
{
    
    public enum GameName
    {
        obstacleAvoid = 1,
        choppingWood = 2,
    }

    public GameName gameName;
    public string npcName;
    public string npcDesc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch((int)gameName)
        {
            case 1:
                Debug.Log(npcName);
                break;
            case 2:
                Debug.Log(npcName);
                break;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("");

        if (Input.GetButton("Interaction"))
        {
            switch ((int)gameName)
            {
                case 1:
                    GameManager.instance.player.speed = 10f;
                    SceneManager.LoadScene("AvoidGame");
                    break;
                case 2:
                    Debug.Log("2");
                    break;
            }
        }
    }
}
