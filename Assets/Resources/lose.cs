using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartClick(){
        SceneManager.LoadScene("playgame"); 
    }
    public void menuClick(){
        SceneManager.LoadScene("mainmenu");
    }
}
