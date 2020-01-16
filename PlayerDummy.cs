using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour
{
    Animator animController;

	// Use this for initialization
	void Start()
    {
        animController = GetComponent<Animator>();
        Invoke("PickEar", 3);
	}
	
    void PickEar()
    {
        animController.SetTrigger("Idle Funny");
        Invoke("PickEar", Random.Range(15, 60));
    }
}
