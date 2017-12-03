using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSpeed : MonoBehaviour {

    /// <summary>
    /// Контроллер от первого лица
    /// </summary>
    private FirstPersonController fpc;
    /// <summary>
    /// Нормальная скорость
    /// </summary>
    private float speed;
    /// <summary>
    /// Все куски снега, с которыми игрок пересекается
    /// </summary>
    private HashSet<GameObject> set = new HashSet<GameObject>();

    // Use this for initialization
    void Start () {
        fpc = transform.parent.GetComponent<FirstPersonController>();
        speed = fpc.m_WalkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        float max = 0f;
        List<GameObject> needToDelete = new List<GameObject>(); // если их уничтожили, то надо удалить
        foreach (GameObject obj in set)
        {
            if (obj == null)
            {
                needToDelete.Add(obj);
                continue;
            }

            if (max < obj.transform.localScale.y)
                max = obj.transform.localScale.y;
        }
        fpc.m_WalkSpeed = speed / (1 + max);
        fpc.m_RunSpeed = fpc.m_WalkSpeed;
    }



    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "SnowElement")
        {
            set.Add(col.gameObject);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "SnowElement")
        {
            set.Remove(col.gameObject);
        }
    }
}
