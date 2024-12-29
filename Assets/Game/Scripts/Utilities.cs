using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeaths;

    public static void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public static void UpdateDeathCount()
    {
        playerDeaths += 1;
        Debug.Log(playerDeaths + "Player Deaths");
    }

}
