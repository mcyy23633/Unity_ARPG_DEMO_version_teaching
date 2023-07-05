using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 猫控制脚本。
/// </summary>
public class MaoController : MonoBehaviour
{
    public Rigidbody rBody;
    public float speed;
    Vector3 controlSignal = Vector3.zero;
    public Transform Target;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }   

    void FixedUpdate()
    {
        //用W、A、S、D按键控制猫移动。
        controlSignal.x = Input.GetAxis("Horizontal");
        controlSignal.z = Input.GetAxis("Vertical");
        rBody.AddForce(controlSignal * speed);
        // 猫和老鼠之间的距离变量。
        float distanceToTarget = Vector3.Distance(this.transform.position,
                                                  Target.position);
        // 当距离变量小于1.42米时，猫捉到老鼠。
        if (distanceToTarget < 1.42f)
        {
            // 当老鼠被捉到后，逃跑到一个随机位置。
            Target.position = new Vector3(Random.value * 8 - 4,
                                          0.5f,
                                          Random.value * 8 - 4);
        }
    }
}
