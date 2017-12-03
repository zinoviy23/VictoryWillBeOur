using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFieldScript : MonoBehaviour {
    /// <summary>
    /// Длины по x и y
    /// </summary>
    [Tooltip("Лучше оставить квадратным и целым")]
    public float x, y;

    /// <summary>
    /// Префаб куска снега
    /// </summary>
    public GameObject snowElement;

    /// <summary>
    /// Сетка снега
    /// </summary>
    private SnowElementScript[,] snowGrid;

    /// <summary>
    /// Промежуток между увеличением снега
    /// </summary>
    private readonly float delta = 3f;

	// Use this for initialization
	void Start () {
        Init();
        StartCoroutine(AddSnow());
    }
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// Создаёт снег
    /// </summary>
    private void Init()
    {
        int cntX = (int)(x / transform.localScale.x);
        int cntY = (int)(y / transform.localScale.z);

        snowGrid = new SnowElementScript[cntY, cntX];
        for (int i = 0; i < cntX; i++)
        {
            for (int j = 0; j < cntY; j++)
            {
                snowGrid[j, i] = Instantiate(snowElement, transform).GetComponent<SnowElementScript>();
                snowGrid[j, i].transform.position = new Vector3(i * snowElement.transform.localScale.x - x / 2,
                    0, j * snowElement.transform.localScale.z - y / 2) + Vector3.right / 2 + Vector3.forward / 2;
                snowGrid[j, i].Init(j, i, this);
            }
        }
    }

    /// <summary>
    /// Раз в промежуток увеличивает снег(или создаёт новый)
    /// </summary>
    /// <returns></returns>
    private IEnumerator AddSnow()
    {
        WaitForSeconds wait = new WaitForSeconds(delta);
        while (true)
        {
            yield return wait;

            for (int i = 0; i < snowGrid.GetLength(0); i++)
                for (int j = 0; j < snowGrid.GetLength(1); j++)
                {
                    if (snowGrid[i, j] != null)
                        snowGrid[i, j].transform.localScale += Vector3.up * 0.1f;
                    else
                    {
                        snowGrid[i, j] = Instantiate(snowElement, transform).GetComponent<SnowElementScript>();
                        snowGrid[i, j].transform.position = new Vector3(j * snowElement.transform.localScale.x - x / 2,
                            0, i * snowElement.transform.localScale.z - y / 2) + Vector3.right / 2 + Vector3.forward / 2;
                        snowGrid[i, j].Init(i, j, this);
                    }
                }

        }
    }

    public void DeleteElement(int i, int j)
    {
        snowGrid[i, j] = null;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Отрисовка в unity
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + Vector3.up, new Vector3(x, 1, y));
    }
}
