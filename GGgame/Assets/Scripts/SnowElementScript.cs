using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowElementScript : MonoBehaviour {

    private int i, j;
    private SnowFieldScript snowField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(int i, int j, SnowFieldScript snowField)
    {
        this.i = i;
        this.j = j;
        this.snowField = snowField;
    }

    public void DestroyEl()
    {
        snowField.DeleteElement(i, j);
        Destroy(gameObject);
    }
}
