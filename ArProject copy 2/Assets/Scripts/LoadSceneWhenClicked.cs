using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWhenClicked : MonoBehaviour {

    public void LoadByIndex (int sceneIndex)
    {
        
        SceneManager.LoadScene(sceneIndex);
        
    }

    public void LoadSceneFromStart(int sceneIdx)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadlevel(string sceneName)
    {
        Application.LoadLevel(sceneName);
        
    }
    public void closeCanvasOnClick(GameObject canvas)
    {
        canvas.SetActive(false);
       
    }
    public void hintCanvas(GameObject hintDialog)
    {
        
        if (hintDialog.active == false)
        {
            hintDialog.SetActive(true);
        }
    }


}
