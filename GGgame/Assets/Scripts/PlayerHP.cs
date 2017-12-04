using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : Attackable {
    /// <summary>
    /// Кол-во угольков
    /// </summary>
    private int cntCoal;
    /// <summary>
    /// Высота сугроба
    /// </summary>
    private int coldLevel;
    /// <summary>
    /// Коэффициент уровня снега
    /// </summary>
    private readonly int coldLevelMult = 4;
    /// <summary>
    /// Ссылка на руки
    /// </summary>
    private ArmScript arm;
    /// <summary>
    /// Максимальный холод
    /// </summary>
    private readonly int coldMax = 100;

    /// <summary>
    /// UI
    /// </summary>
    private UIScript ui;

    /// <summary>
    /// Что делать, когда игрок умирает
    /// </summary>
    protected override void Die()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>().Die();
    }

    // Use this for initialization
    new void Start () {
        base.Start();
        arm = transform.GetChild(0).GetComponent<ArmScript>();
        ui = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIScript>();
        StartCoroutine(CheckCold());
        cntCoal = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ui.SnowballsCount = arm.SnowballsCount;
        ui.CoalCount = cntCoal;
	}

    /// <summary>
    /// Атака игрока
    /// </summary>
    /// <param name="isSnowball"> снежки или угольки </param>
    /// <param name="cnt"> сколько </param>
    public void Attack(bool isSnowball, int cnt)
    {
        if (isSnowball)
        {
            arm.AddSnowballs(cnt);
        }
        else
        {
            cntCoal += cnt;
        }
    }

    /// <summary>
    /// Проверка на замороженность
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckCold()
    {
        while (true)
        {
            int result = coldLevel * coldLevelMult + arm.SnowballsCount;
            ui.ColdScrenValue = (result * 1.0f) / coldMax;
            if (result > 10)
            {
                Die();
                yield break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Начальное сжатие снега
    /// </summary>
    private readonly float standart = 0.01f;
    /// <summary>
    /// Шаг снега
    /// </summary>
    private readonly float step = 0.1f;
    /// <summary>
    /// Какой уровень снега
    /// </summary>
    public float SnowScale
    {
        set
        {
            coldLevel = (int)(Mathf.Clamp((value - standart) / step, 0, 1000000));
        }
    }

    /// <summary>
    /// Лишним не будет
    /// </summary>
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
