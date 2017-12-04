using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanHP : Attackable {

	// Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Уничтожаться, если умираешь
    /// </summary>
    protected override void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Проверка на колизию с снежком
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        GameObject go = col.gameObject;
        if (go.tag == "Snowball")
        {
            hp -= 5;
        }
    }


}
