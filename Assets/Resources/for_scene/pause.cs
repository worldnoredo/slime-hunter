using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseOption;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseCLick(){
        Time.timeScale = 0;
        pauseOption.SetActive(true);
    }
    public void continueClick(){
        Time.timeScale = 1;
        pauseOption.SetActive(false);
    }
    public void menuClick(){
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");     
    }
    public void optionClick(){
        SceneManager.LoadScene("musicsetting",LoadSceneMode.Additive);
    }
}
