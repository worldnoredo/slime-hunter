using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_status_render : MonoBehaviour
{
    public GameObject player_max_health;
    public GameObject player_cur_health;
    public GameObject player_max_energy;
    public GameObject player_cur_energy;
    public GameObject target_max_health;
    public GameObject target_cur_health;
    public GameObject lose_panel;
    public GameObject money_render;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //player health
        int player_health_percent = player.GetComponent<common_for_character>().get_cur_health_precent();
        update_width_status(player_max_health,player_cur_health,player_health_percent);
        update_health_color(player_health_percent);
        if (player_health_percent == 0){
            lose_panel.SetActive(true);
            lose_panel.GetComponent<lose>().updateMoney(player.GetComponent<Player_controller>().money);
        }
        //target health
        int target_health_percent = player.GetComponent<Player_controller>().get_target_cur_health_percent();
        if (target_health_percent == 0){
            target_cur_health.SetActive(false);
            target_max_health.SetActive(false);
        }
        else {
            target_cur_health.SetActive(true);
            target_max_health.SetActive(true);
            update_width_status(target_max_health,target_cur_health,target_health_percent);
        }
        //energy
        int player_energy_percent = player.GetComponent<Player_controller>().get_cur_energy_percent();
        update_width_status(player_max_energy,player_cur_energy,player_energy_percent);
        //money
        money_render.GetComponent<TMPro.TextMeshProUGUI>().text = player.GetComponent<Player_controller>().money.ToString();
    }
    public void update_width_status(GameObject max, GameObject cur,int percent){
        //size
        RectTransform max_rt = max.GetComponent (typeof (RectTransform)) as RectTransform;
        RectTransform cur_rt = cur.GetComponent (typeof (RectTransform)) as RectTransform;
        cur_rt.sizeDelta = new Vector2 ( percent * max_rt.sizeDelta.x / 100 , max_rt.sizeDelta.y);
    }
    public void update_health_color(int percent){
        //color, max:(0,0,255) (blue), min (255,0,0)
        Image img = player_cur_health.GetComponent(typeof (Image)) as Image;
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
