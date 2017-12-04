using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{

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

    public bool IsInArm { get; set; }

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
        if (!IsInArm)
        {
            var exp = Instantiate(explosion);
            exp.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
