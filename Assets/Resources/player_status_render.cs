using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_status_render : MonoBehaviour
{
    public GameObject health;
    public GameObject energy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void update_health(int percent){
        //size
        RectTransform rt = health.GetComponent (typeof (RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2 ( percent * 10 , 30); // max:1000,30
        //color, max:(0,0,255) (blue), min (255,0,0)
        Image img = health.GetComponent(typeof (Image)) as Image;
        float color_r = 0f;
        float color_g = 0f;
        float color_b = 0f;
        if (percent >= 75){
            color_b = 1;
            color_g = (100 - percent) /25f;
        } else if (percent >= 50){
            color_g = 1;
            color_b = (percent - 50) /25f;   
        } else if (percent >=25){
            color_g = 1;
            color_r = (50 - percent) /25f;
        } else {
            color_r = 1;
            color_g = percent /25f;
        }
        img.color = new Color(color_r,color_g,color_b,1);
        
    }
}
