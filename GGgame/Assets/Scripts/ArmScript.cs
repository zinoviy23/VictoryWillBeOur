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
    /// 1 - ничего
    /// 2 - снежок
    /// 3 - рука
    /// </summary>
    private int state = 1;

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
            state = 3;
        }
    }


    /// <summary>
    /// Метод для бросания шарика
    /// </summary>
    void Shoot()
    {
        Vector3 dir = Camera.main.ScreenPointToRay(
                new Vector3(Screen.width / 2, Screen.height / 2)).direction;

        GameObject obj = Instantiate(snowball, transform);
        obj.transform.localPosition = Vector3.forward;

        obj.GetComponent<Rigidbody>().AddForce(dir * force);
        obj.transform.parent = null;
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
    IEnumerator SwitchState()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                state = 1;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                state = 2;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                state = 3;
            yield return null;
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
