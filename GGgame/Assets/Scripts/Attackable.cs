using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Attackable : MonoBehaviour {
    /// <summary>
    /// Кол-во жизней
    /// </summary>
    [Range(10, 30)]
    public int hp;


    /// <summary>
    /// Нужно вызывать в дочерних методах
    /// </summary>
	// Use this for initialization
	protected virtual void Start () {
        StartCoroutine(CheckDeath());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    /// <summary>
    /// Проверка на смерть
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckDeath()
    {
        while (true)
        {
            if (hp < 0)
                Die();
            yield return null;
        }
    }

    /// <summary>
    /// Обработка смерти
    /// </summary>
    protected abstract void Die();
}
