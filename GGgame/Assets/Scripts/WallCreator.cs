using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour {

    /// <summary>
    /// Кусок стены
    /// </summary>
    public GameObject wallEl;
    /// <summary>
    /// Размер карты
    /// </summary>
    public float x, y;

    /// <summary>
    /// Размер стены
    /// </summary>
    private readonly float wallSize = 3.2f;

	// Use this for initialization
	void Start () {
        Init();
	}

    /// <summary>
    /// Создаёт стену
    /// </summary>
    private void Init()
    {
        // передняя стена и задняя
        int cntX = (int)(x / wallSize) + 1;
        for (int i = 0; i < cntX; i++)
        {
            GameObject wallElement = Instantiate(wallEl, transform);
            wallElement.transform.position = new Vector3(wallSize / 2 + i * wallSize - x / 2, wallSize / 2, y / 2);
            wallElement = Instantiate(wallEl, transform);
            wallElement.transform.position = new Vector3(wallSize / 2 + i * wallSize - x / 2, wallSize / 2, -y / 2);
        }
        // правая и левая
        int cntY = (int)(y / wallSize) + 1;
        for (int i = 0; i < cntY; i++)
        {
            GameObject wallElement = Instantiate(wallEl, transform);
            wallElement.transform.position = new Vector3(x / 2, wallSize / 2, wallSize / 2 + i * wallSize - y / 2);
            wallElement.transform.eulerAngles = new Vector3(0, 90, 0);
            wallElement = Instantiate(wallEl, transform);
            wallElement.transform.position = new Vector3(-x / 2, wallSize / 2, wallSize / 2 + i * wallSize - y / 2);
            wallElement.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up, new Vector3(x, 1, y));
    }
}
