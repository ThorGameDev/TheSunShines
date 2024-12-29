using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int pickupsCollected;
    public int pickupsLeft;
    public PlayerBehavior player;

    public TMP_Text score;
    public TMP_Text progressText;
    public GameObject loosePannel;
    public GameObject wonPannel;

    void Start()
    {
        Time.timeScale = 1;
    }
    
    public void Win()
    {
        Time.timeScale = 0;
        wonPannel.SetActive(true); 
        progressText.text = "";
        score.text = "";
    }
    public void Loose()
    {
        Time.timeScale = 0;
        loosePannel.SetActive(true); 
        Destroy(player);
        progressText.text = "";
        score.text = "";
        Utilities.UpdateDeathCount();
    }
    // Update is called once per frame
    void Update()
    {
        score.text = $"Player Health: {player.health}\nItems Collected: {pickupsCollected} / {pickupsLeft + pickupsCollected}\n";
        if(player.lastFire > player.timePerFire)
        {
            score.text += "Bullet loaded!";
        }
        if (player.health <= 0)
        {
            Loose();
        }
        if (pickupsLeft == 0)
        {
            Win();
        }
    }

    public void Hit()
    {
        int Damage = Random.Range(3, 8);
        player.health = Mathf.Clamp(player.health - Damage, 0, 10);
        progressText.text = $"That hurt! {Damage} Damage!";
    }

    public void Restart()
    {
        Utilities.RestartLevel();
    }
}
