using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class updateStat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject number;
    public GameObject button;
    public void updateText(string newText){
        number.GetComponent<TMPro.TextMeshProUGUI>().text = newText;
    }
    public void updateButton(bool clickable){
        button.GetComponent<Button>().interactable = clickable;
    }
}
