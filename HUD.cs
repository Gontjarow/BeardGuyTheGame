using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject IngameOverlay;
    public GameObject PauseMenu;

    public GameObject beardDisplay;

    public void UpdateBeard(int value)
    {
        beardDisplay.GetComponent<Text>().text = value.ToString();
    }

	// Use this for initialization
	void Start()
    {
        //beardDisplay = GameObject.Find("Canvas/Ingame Overlay/Data 1");
        IngameOverlay = GameObject.Find("Canvas/Ingame Overlay");
        PauseMenu = GameObject.Find("Canvas/PauseMenu");
    }
	
	// Update is called once per frame
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            IngameOverlay.SetActive(!IngameOverlay.activeSelf);
            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }
	}
}
