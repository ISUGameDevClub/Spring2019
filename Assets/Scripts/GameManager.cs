using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    //Objects in game...
    public static GameObject player = GameObject.Find("Player");
    //public static GameObject player2 = GameObject.Find("Player2");


    public static void SaveGame()
    {
        SaveSystem.SaveGame(player.GetComponent<Player>());
    }

    public static void LoadGame()
    {
        SaveData data = SaveSystem.LoadGame();

        //Player 1
        player.GetComponent<Player>().level = data.playerLevel;
        player.GetComponent<Player>().maxHealth = data.playerMaxHealth;
        player.GetComponent<Player>().currentHealth = data.playerCurrentHealth;
        Vector2 playerPosition;
        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        player.GetComponent<Player>().transform.position = playerPosition;

        //Player 2
        //player2.GetComponent<Player>().level = data.player2Level;
        //player2.GetComponent<Player>().maxHealth = data.player2MaxHealth;
        //player2.GetComponent<Player>().currentHealth = data.player2CurrentHealth;
        //Vector2 player2Position;
        //player2Position.x = data.player2Position[0];
        //player2Position.y = data.player2Position[1];
        //player2.GetComponent<Player>().transform.position = player2Position;
    }
}
