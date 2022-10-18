using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static public float DifficultySpeed;
    GameObject TimeHandler;
    private int Tier = 0;
    public GameObject Tier2;
    public GameObject Top1;
    public GameObject Top2;
    public GameObject Top3;

    void Start()
    {
        TimeHandler = GameObject.FindWithTag("Time");
    }

    private void Update()
    {
        DifficultySpeed = TimeHandler.GetComponent<UniversalTimeController>().initialTime;
        if (DifficultySpeed >= 1.5 && Tier == 0)
        {
            Tier2.SetActive(true);
            Tier = 1;
            Debug.Log("Funtime");
        }

        if (DifficultySpeed >= 2 && Tier == 1)
        {
            Top1.GetComponent<DownObjectRight>().enabled = true;
            Top2.GetComponent<Beam>().enabled = true;
            Top3.GetComponent<DownObjectRight>().enabled = true;
            Tier = 2;
            Debug.Log("Funtime2");
        }
        // Debug.Log(DifficultySpeed);
    }
}
