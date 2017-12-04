using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour {

    /// <summary>
    /// Префаб снежка
    /// </summary>
    public GameObject snowball;

    /// <summary>
    /// Маска лопаты
    /// </summary>
    public LayerMask shovelMask;

    /// <summary>
    /// Сила, с которой игрок кидает снежки
    /// </summary>
    [Range(200, 700)]
    public float force = 300;

    /// <summary>
    /// Объект в руке.
    /// Мб только для лопаты
    /// </summary>
    private GameObject hand;

    /// <summary>
    /// Кол-во снежков
    /// </summary>
    private int snowballsCount = 0;

    /// <summary>
    /// 1 - ничего
    /// 2 - снежок
    /// 3 - рука
    /// </summary>
    private int state = 1;

    /// <summary>
    /// Снежок в руке
    /// </summary>
    private GameObject currentSnowBall;

    /// <summary>
    /// Анимирутеся ли снежок
    /// </summary>
    private bool isSnowballAnimating;

	// Use this for initialization
	void Start () {
        StartCoroutine(SwitchState());
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            switch (state)
            {
                case 1:
                    Grub();
                    break;
                case 2:
                    Shoot();
                    break;
                case 3:
                    UseHand();
                    break;
            }
               
        }	
	}

    /// <summary>
    /// Взять что-нибудь
    /// </summary>
    void Grub()
    {
        // может это и не самый оптимизированный способ
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f, shovelMask))
        {
            hand = hit.collider.gameObject;
            hand.transform.parent = transform;
            hand.transform.localPosition = new Vector3(0.7f, 0, 1);
            hand.transform.localRotation = Quaternion.Euler(-120, 50, 10);
            hand.GetComponent<ShovelScript>().SetArm(this);
            state = 3;
        }
    }
    
    /// <summary>
    /// Добавление снежков
    /// </summary>
    /// <param name="cnt"></param>
    public void AddSnowballs(int cnt)
    {
        snowballsCount += cnt;
    }

    /// <summary>
    /// Свойство для получения колва снежков
    /// </summary>
    public int SnowballsCount
    {
        get
        {
            return snowballsCount;
        }
    }

    /// <summary>
    /// Метод для бросания шарика
    /// </summary>
    void Shoot()
    {
        if (currentSnowBall != null)
        {
            Vector3 dir = Camera.main.ScreenPointToRay(
                    new Vector3(Screen.width / 2, Screen.height / 2)).direction;

            currentSnowBall.GetComponent<Rigidbody>().isKinematic = false;
            currentSnowBall.GetComponent<SnowballScript>().IsInArm = false;
            currentSnowBall.GetComponent<Rigidbody>().AddForce(dir * force);
            currentSnowBall.transform.parent = null;
            currentSnowBall = null;
            snowballsCount--;
            ShowSnowball();
        }
    }

    /// <summary>
    /// Использование предмета в руке
    /// </summary>
    private void UseHand()
    {
        hand.GetComponent<ShovelScript>().Attack();
    }

    /// <summary>
    /// Меняет состояние
    /// </summary>
    /// <returns></returns>
    private IEnumerator SwitchState()
    {
        while (true)
        {
            if (hand != null && hand.GetComponent<ShovelScript>().IsWorking)
                yield return null;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = 1;
                HideHand();
                HideSnowball();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = 2;
                HideHand();
                ShowSnowball();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = 3;
                ShowHand();
                HideSnowball();
            }
            yield return null;
        }
    }

    /// <summary>
    /// Спрятать лопату
    /// </summary>
    private void HideHand()
    {
        if (hand != null)
        {

            hand.SetActive(false);
        }
    }

    /// <summary>
    /// Анимация снежка
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitSnowball()
    {
        yield return new WaitForSeconds(0.3f);
        currentSnowBall = Instantiate(snowball, transform);
        currentSnowBall.GetComponent<Rigidbody>().isKinematic = true;
        currentSnowBall.transform.localPosition = Vector3.forward;
        currentSnowBall.GetComponent<SnowballScript>().IsInArm = true;
    }

    /// <summary>
    /// Показать снежок
    /// </summary>
    private void ShowSnowball()
    {
        if (snowballsCount > 0)
        {
            StartCoroutine(WaitSnowball());
        }
    }

    /// <summary>
    /// Убрать снежок
    /// </summary>
    private void HideSnowball()
    {
        Destroy(currentSnowBall);
        currentSnowBall = null;
    }

    /// <summary>
    /// Показать лопату
    /// </summary>
    private void ShowHand()
    {
        if (hand != null)
        {
            hand.SetActive(true);
        }
    }

    /// <summary>
    /// Бережённого бог бережёт
    /// </summary>
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
