using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    /// <summary>
    /// Префаб звезды
    /// </summary>
    public GameObject star;

    /// <summary>
    /// Высота
    /// </summary>
    public float height;

    /// <summary>
    /// Зона
    /// </summary>
    public float x, y;

    /// <summary>
    /// Кол-во
    /// </summary>
    public int count;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Генерирует
    /// </summary>
    void Init()
    {
        for (int i = 0; i < count; i++)
        {
            float newX = Random.Range(-x / 2, +x / 2);
            float newY = Random.Range(-y / 2, +y / 2);
            GameObject obj = Instantiate(star, transform);
            obj.transform.position = new Vector3(newX, height, newY);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + Vector3.up * height, new Vector3(x, 1, y));
    }
}
