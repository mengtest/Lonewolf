using UnityEngine;
using System.Collections;

public class WindMove : MonoBehaviour
{

    public float Power = 10;//这个代表发射时的速度/力度等，可以通过此来模拟不同的力大小
    public float Angle = 45;//发射的角度，这个就不用解释了吧
    public bool IsOne = false;


    private Vector3 MoveSpeed;//初速度向量
    private Vector3 GritySpeed = Vector3.zero;//重力的速度向量，t时为0
    private float dTime;//已经过去的时间

    private Vector3 currentAngle;

    // Use this for initialization
    void Start()
    {
        MoveSpeed = Quaternion.Euler(new Vector3(0, 0, Angle)) * (Vector3.left) * Power ;
        currentAngle = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (MoveSpeed + GritySpeed) * Time.fixedDeltaTime * 0.6f;
        currentAngle.z = Mathf.Atan((MoveSpeed.y + GritySpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;
        transform.eulerAngles = currentAngle;
    }
}