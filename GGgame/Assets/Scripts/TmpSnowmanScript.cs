using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpSnowmanScript : MonoBehaviour {

    /// <summary>
    /// Позиция игрока
    /// </summary>
    private Transform playersTransform;

	// Use this for initialization
	void Start () {
        playersTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(playersTransform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
