using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : common_for_character
{
    public player_status_render player_status_render;
    public lose lose_panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update health renderer
        player_status_render.update_health(get_cur_health_precent());
        if (get_cur_health() <= 0){
            is_die();
        }
    }
    void is_die(){
        lose_panel.gameObject.SetActive(true);
    }
}
