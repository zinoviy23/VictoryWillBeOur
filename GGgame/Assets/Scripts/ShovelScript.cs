using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {
    /// <summary>
    /// Скорость поворота
    /// </summary>
    public float attackRotationSpeed = 100;
    /// <summary>
    /// Скорость движения
    /// </summary>
    public float attackSpeed = 10;
    /// <summary>
    /// Маска снега
    /// </summary>
    public LayerMask mask;

    /// <summary>
    /// Работает ли
    /// </summary>
    private bool isWorking = false;
    /// <summary>
    /// Поворачивается ли
    /// </summary>
    private bool isRotatingX = false;
    /// <summary>
    /// Остановить ли
    /// </summary>
    private bool isStop = false;
    /// <summary>
    /// Двигается ли
    /// </summary>
    private bool isMoving = false;

    /// <summary>
    /// Ссылка на armScript
    /// </summary>
    private ArmScript arm;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Метод для удара
    /// </summary>
    public void Attack()
    {
        if (!isWorking)
        {
            StartCoroutine(AnimateAttack());
            CheckCollision();
        }
    }

    /// <summary>
    /// Присвоить arm
    /// </summary>
    /// <param name="arm"></param>
    public void SetArm(ArmScript arm)
    {
        this.arm = arm;
    }

    /// <summary>
    /// Корутин для анимации атаки
    /// </summary>
    /// <returns></returns>
    private IEnumerator AnimateAttack()
    {
        isWorking = true;
        StartCoroutine(RotateX(-60));
        StartCoroutine(Move(Vector3.forward * 0.7f, 1));
        while (isRotatingX || isMoving)
            yield return null;

        yield return new WaitForSeconds(0.2f);

        StartCoroutine(RotateX(60));
        StartCoroutine(Move(-Vector3.forward * 0.7f, 1));
        while (isRotatingX || isMoving)
            yield return null;


        isWorking = false;
        arm.AddSnowballs(5);
        yield break;
    }

    /// <summary>
    /// Проверяет пересечение со снегом
    /// </summary>
    private void CheckCollision()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f, mask))
        {
            hit.collider.gameObject.GetComponent<SnowElementScript>().DestroyEl();
        }
    }

    /// <summary>
    /// Поворот по x
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    private IEnumerator RotateX(float angle)
    {
        isRotatingX = true;

        float rotationTime = Mathf.Abs(angle) / attackRotationSpeed;
        int countRotation = (int)(rotationTime / Time.fixedDeltaTime) + 1;
        float currentAngle = 0;
        for (int i = 0; i < countRotation; i++)
        {
            if (isStop)
                yield break;
            float delta = attackRotationSpeed * Time.fixedDeltaTime;
            if (Mathf.Abs(delta) > Mathf.Abs(angle - currentAngle))
            {
                transform.Rotate(new Vector3(angle - currentAngle, 0));
                currentAngle += angle - currentAngle;
            }
            else
            {
                transform.Rotate(new Vector3(delta * Mathf.Sign(angle), 0));
                currentAngle += Mathf.Sign(angle) * delta;
            }

            yield return new WaitForFixedUpdate();
        }

        isRotatingX = false;
        yield break;
    }

    private IEnumerator Move(Vector3 delta, float speedMult)
    {
        float startTime = Time.time;
        isMoving = true;
        Vector3 target = transform.localPosition + delta;
        while (target != transform.localPosition && !isStop)
        {
            //print(transform.position + " " + target);
            //print(speedMult);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, attackSpeed * Time.fixedDeltaTime * speedMult);
            yield return new WaitForFixedUpdate();
        }
        isMoving = false;
        yield break;
    }

    /// <summary>
    /// Свойство для проверки на анимацию
    /// </summary>
    public bool IsWorking
    {
        get
        {
            return isWorking;
        }
    }
}
