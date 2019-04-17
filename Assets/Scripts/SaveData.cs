using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will store all data that we want our game to save when saved.
[System.Serializable]
public class SaveData
{
    //Variables
    //All data wanting to save.
    //Player data...
    public int playerLevel;
    public int playerCurrentHealth;
    public int playerMaxHealth;
    public float[] playerPosition;

    //public int player2Level;
    //public int player2CurrentHealth;
    //public int player2MaxHealth;
    //public float[] player2Position;

    public SaveData(Player player) //Include all necessary objects as parameters.
    {
        //Player data...
        playerLevel = player.level;
        playerMaxHealth = player.maxHealth;
        playerCurrentHealth = player.currentHealth;

        playerPosition = new float[2]; //Brackey's tutorial did 3 positions but since we are 2d, we may only need 2?
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;

        //Player 2 data
        //player2Level = player2.level;
        //player2MaxHealth = player2.maxHealth;
        //player2CurrentHealth = player2.currentHealth;

        //player2Position = new float[2]; //Brackey's tutorial did 3 positions but since we are 2d, we may only need 2?
        //player2Position[0] = player2.transform.position.x;
        //player2Position[1] = player2.transform.position.y;
    }
}
