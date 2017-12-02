using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFollowing : MonoBehaviour {

    /// <summary>
    /// Позиция игрока
    /// </summary>
    private Transform playersTransform;
    /// <summary>
    /// Разница между игроком и снегом
    /// </summary>
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        playersTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playersTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playersTransform.position + offset;
	}
}
