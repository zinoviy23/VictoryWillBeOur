using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public GameObject standartCanvas;
    public GameObject diedCanvas;

    public void Die()
    {
        Time.timeScale = 0;
        standartCanvas.SetActive(false);
        diedCanvas.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Кнопка restart
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
