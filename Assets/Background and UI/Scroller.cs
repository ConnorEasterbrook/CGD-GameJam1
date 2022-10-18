using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Scroller : MonoBehaviour {
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    public float multipleSpeed;

    GameObject TimeHandler;

    void Start()
    {
        TimeHandler = GameObject.FindWithTag("Time");
    }
 
    void Update()
    {
        _x = TimeHandler.GetComponent<UniversalTimeController>().initialTime;
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x * multipleSpeed,_y) * Time.deltaTime,_img.uvRect.size);
    }
}
 