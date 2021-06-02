using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject text_delay;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float delay_time = Mathf.Round(player.GetComponent<Player_controller>().get_skill_reload_delay());
        if (delay_time > 0){
            text_delay.SetActive(true);
            GetComponent<Button>().interactable = false;
            text_delay.GetComponent<TMPro.TextMeshProUGUI>().text = delay_time.ToString();
        } else {
            text_delay.SetActive(false);
            if (!player.GetComponent<Player_controller>().is_enough_energy()){
                GetComponent<Button>().interactable = false;
            } else GetComponent<Button>().interactable = true;
        }
        
    }
}
