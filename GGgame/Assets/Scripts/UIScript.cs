using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    /// <summary>
    /// Синий экран
    /// </summary>
    public Image coldScreen;
    /// <summary>
    /// Текст для количества снежков
    /// </summary>
    public Text snowBallsText;

    /// <summary>
    /// Текст для количества угольков
    /// </summary>
    public Text coalText;

    /// <summary>
    /// Максимальная не прозрачность
    /// </summary>
    private readonly float maxAlpha = 127f;

    /// <summary>
    /// Как холодно
    /// </summary>
    public float ColdScrenValue
    {
        set
        {
            coldScreen.color = new Color(coldScreen.color.r, coldScreen.color.g, coldScreen.color.b,
                value / 255f  * maxAlpha);
        }
    }

    /// <summary>
    /// Отображение снежков
    /// </summary>
    public int SnowballsCount
    {
        set
        {
            snowBallsText.text = "X " + value;
        }
    }

    /// <summary>
    /// Отображение угольков
    /// </summary>
    public int CoalCount
    {
        set
        {
            coalText.text = "X " + value;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
