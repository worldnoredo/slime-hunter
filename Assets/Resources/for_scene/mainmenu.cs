using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playCLick(){
        SceneManager.LoadScene("playgame");
    }
    public void quit(){
        Application.Quit();
    }
    public void upgradeClick(){
        SceneManager.LoadScene("upgrade");
    }
    public void optionClick(){
        SceneManager.LoadScene("musicsetting",LoadSceneMode.Additive);
    }
}
