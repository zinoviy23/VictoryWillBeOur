using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Die(5f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Метод для уничтожения объекта
    /// </summary>
    /// <param name="dieTime"></param>
    /// <returns></returns>
    IEnumerator Die(float dieTime)
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
}
