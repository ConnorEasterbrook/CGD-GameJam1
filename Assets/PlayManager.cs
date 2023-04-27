using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class PlayManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] livesText;
    private int lives = 3;
    private bool hit = false;
    public bool lifeCollected = false;
    public bool Dead = false;
    private Vector3 spawnPos;
    private float cooldown = 1f;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        spawnPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        LifeLossCountdown();
        LifeUpCountdown();
    }

    public void LifeLossCountdown()
    {
        if (hit)
        {
            livesText[0].SetActive(true);
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                livesText[0].SetActive(false);
                cooldown = 1f;
                hit = false;
            }
        }
    }

    public void LifeUpCountdown()
    {
        if (lifeCollected)
        {
            livesText[1].SetActive(true);
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                livesText[1].SetActive(false);
                cooldown = 1f;
                lifeCollected = false;
            }
        }
    }

    public void UpdateDeath()
    {
        hit = true;
        lives -= 1;
        player.transform.position = new Vector3(spawnPos.x, spawnPos.y + 20, spawnPos.z);
    }

    private async void NoDeath()
    {
        Time.timeScale = 0.5f;
        await Task.Delay(100);
        Dead = false;

        await Task.Delay(5000);
        Time.timeScale = 1.0f;
    }
}
