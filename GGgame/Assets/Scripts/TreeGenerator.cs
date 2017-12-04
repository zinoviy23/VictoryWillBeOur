using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour {

    /// <summary>
    /// Структура для представления зоны
    /// </summary>
    [System.Serializable]
    public struct TreeArea
    {
        public float x, y;
        public Vector3 position;
        public int count;
    }

    /// <summary>
    /// Зоны, где генерятся ёлки
    /// </summary>
    public TreeArea[] areas;

    /// <summary>
    /// Префаб ёлки
    /// </summary>
    public GameObject treePrefab;

    /// <summary>
    /// Координата по y для деревьев
    /// </summary>
    private readonly float treeCoord = 1.6f;

    /// <summary>
    /// Координаты ёлок
    /// </summary>
    private List<Vector3> coords = new List<Vector3>();

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Генерирует ёлки
    /// </summary>
    private void Init()
    {
        foreach(TreeArea area in areas)
        {
            GenArea(area);
        }
    }
    
    /// <summary>
    /// Генерация для конкретной оси
    /// </summary>
    private void GenArea(TreeArea area)
    {
        for (int i = 0; i < area.count; i++)
        {
            GameObject obj = Instantiate(treePrefab);
            float xx = Random.Range(-area.x / 2, area.x / 2) + area.position.x;
            float yy = Random.Range(-area.y / 2, area.y / 2) + area.position.z;
            Quaternion q = Quaternion.Euler(0, Random.Range(0f, 180.0f), 0);
            obj.transform.position = new Vector3(xx, treeCoord, yy);
            obj.transform.rotation = q;
            coords.Add(new Vector3(xx, 0, yy));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        foreach (TreeArea area in areas)
        {
            Gizmos.DrawCube(area.position, Vector3.one);
            Gizmos.DrawWireCube(area.position, new Vector3(area.x, 1, area.y));
        }
        foreach (Vector3 vec in coords)
        {
            Gizmos.DrawCube(vec, Vector3.one / 2);
        }
    }
}
