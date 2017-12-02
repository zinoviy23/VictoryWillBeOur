using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour {

    /// <summary>
    /// Префаб снежка
    /// </summary>
    public GameObject snowball;

    /// <summary>
    /// Сила, с которой игрок кидает снежки
    /// </summary>
    [Range(200, 700)]
    public float force = 300;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }	
	}

    /// <summary>
    /// Метод для бросания шарика
    /// </summary>
    void Shoot()
    {
        Vector3 dir = Camera.main.ScreenPointToRay(
                new Vector3(Screen.width / 2, Screen.height / 2)).direction;

        GameObject obj = Instantiate(snowball, transform);
        obj.transform.localPosition = Vector3.forward;

        obj.GetComponent<Rigidbody>().AddForce(dir * force);
        obj.transform.parent = null;
    }
}
