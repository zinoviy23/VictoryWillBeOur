using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour {

    /// <summary>
    /// Префаб взрыва
    /// </summary>
    public GameObject explosion;

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

    private void OnTriggerEnter(Collider other)
    {
        var exp = Instantiate(explosion);
        exp.transform.position = transform.position;
        Destroy(gameObject);
    }
}
