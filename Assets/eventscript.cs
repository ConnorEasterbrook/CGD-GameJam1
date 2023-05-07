using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class eventscript : MonoBehaviour
{
    public GameObject button_1, button_2;
    // Update is called once per frame
    void Update()
    {
        if(button_1 == EventSystem.current.currentSelectedGameObject)
        {
            button_1.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        }
        else
        {
            button_1.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
        if (button_2 == EventSystem.current.currentSelectedGameObject)
        {
            button_2.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        }
        else
        {
            button_2.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }
}
