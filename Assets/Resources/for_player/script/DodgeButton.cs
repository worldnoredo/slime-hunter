using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DodgeButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject text_delay;
    public GameObject unable_layer;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float delay_time = Mathf.Round(player.GetComponent<Player_controller>().get_dodge_reload_delay() * 10) /10;
        if (delay_time > 0){
            text_delay.SetActive(true);
            GetComponent<Button>().interactable = false;
            text_delay.GetComponent<TMPro.TextMeshProUGUI>().text = delay_time.ToString();
        } else {
            text_delay.SetActive(false);
            GetComponent<Button>().interactable = true;
        }
    }
}
