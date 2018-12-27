using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationHandler : MonoBehaviour {

    public string m_BackButtonNavigation = "[Name of Scene To Load]";
	
	
	// Update is called once per frame
	void Update () {
        // On Android, the Back button is mapped to the Esc key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            HandleBackButtonPressed();
        }
    }

    public void HandleBackButtonPressed()
    {
        if (SceneManager.GetActiveScene().name != m_BackButtonNavigation)
            SceneManager.LoadScene(m_BackButtonNavigation);
        
    }
}
