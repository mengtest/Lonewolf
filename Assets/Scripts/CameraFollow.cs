using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFollow : MonoBehaviour
{
    private Vector2 MousePositionLast;//用于计算移动方向的起始位置
    private Vector2 MousePositionNew1;//用于计算移动方向的结尾位置
    private Vector2 MousePositionNew2;//用于计算移动方向的结尾位置
    public static Vector2 MouseMoveDirection;//用于表示移动方向
    private Vector3 MouseWorldMoveDirection;//用于在世界坐标系里移动某物体的方向向量
    public Transform MouseObject;//想要在世界坐标系里移动的物体
    public static float MouseSensitivity;//鼠标光标移动速度映射到物体移动速度时的比例或灵敏度

    private Vector3 velocity = Vector3.zero;
    public GameObject Fire;
    public GameObject ReplacementBullets;
    public GameObject ReduceView;
    public GameObject AddView;
    //public GameObject Enter;
    //public GameObject FarFrom;
    public static bool CanMove = true;

    // Update is called once per frame
    void Update()
    {

        if (CanMove)
        {
            //如果需要PC移动 则解注释以下判断语句
            //if(Input.GetMouseButtonDown(0))
            if (Input.touchCount == 1)
            {
                MousePositionLast = MousePositionNew1;
                MousePositionNew1 = Input.touches[0].position;
                //如果需要PC移动 则解注释以下判断语句
                //MousePositionNew1 = Input.mousePosition;
                MouseMoveDirection = MousePositionNew1 - MousePositionLast; //用两个坐标相减，得出鼠标的移动方向向量
                if (IsButton())
                {
                    print("点击按钮上不能移动");
                }
                else{
                    MouseWorldMoveDirection = new Vector3(-MouseMoveDirection.x, MouseMoveDirection.y, 0) * MouseSensitivity;//这个我把二维的方向向量映射到三维的世界坐标系上，这个根据自己需要自己改就好了
                    Vector3 TargetPos = gameObject.transform.position + MouseWorldMoveDirection;
                    if (TargetPos.x > 43)
                    {
                        TargetPos.x = 43;
                    }
                    else if (TargetPos.x < -43)
                    {
                        TargetPos.x = -43;
                    }

                    if (TargetPos.y > 18)
                    {
                        TargetPos.y = 18;
                    }
                    else if (TargetPos.y < -18)
                    {
                        TargetPos.y = -18;
                    }
                    transform.position = Vector3.SmoothDamp(gameObject.transform.position, TargetPos, ref velocity, 0.3f);
                }
            }

            //如果需要PC移动 则注释以下判断语句
            if (Input.touchCount == 2 && OnButtonPressed.OnLongPressed == true)
            {
                Input.touches[1].position = Vector2.zero;
                MousePositionLast = MousePositionNew2;
                MousePositionNew2 = Input.touches[1].position;
                MouseMoveDirection = MousePositionNew2 - MousePositionLast; //用两个坐标相减，得出鼠标的移动方向向量
                if (IsButton())
                {
                    print("点击按钮上不能移动");
                }
                else
                {
                    MouseWorldMoveDirection = new Vector3(-MouseMoveDirection.x, MouseMoveDirection.y, 0) * MouseSensitivity;//这个我把二维的方向向量映射到三维的世界坐标系上，这个根据自己需要自己改就好了
                    Vector3 TargetPos = gameObject.transform.position + MouseWorldMoveDirection;
                    if (TargetPos.x > 43)
                    {
                        TargetPos.x = 43;
                    }
                    else if (TargetPos.x < -43)
                    {
                        TargetPos.x = -43;
                    }

                    if (TargetPos.y > 18)
                    {
                        TargetPos.y = 18;
                    }
                    else if (TargetPos.y < -18)
                    {
                        TargetPos.y = -18;
                    }
                    transform.position = Vector3.SmoothDamp(gameObject.transform.position, TargetPos, ref velocity, 0.3f);
                }
            }

        }

        if (gameObject.transform.position.x > 43)
        {
            gameObject.transform.position = new Vector3(43, gameObject.transform.position.y, gameObject.transform.position.z) ;
        }
        else if (gameObject.transform.position.x < -43)
        {
            gameObject.transform.position = new Vector3(-43, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.y > 18)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 18, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.y < -18)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -18, gameObject.transform.position.z);
        }

    }

    public bool IsButton() {
        if (EventSystem.current.currentSelectedGameObject == ReplacementBullets)
        {
            return true;
        }
        if (EventSystem.current.currentSelectedGameObject == Fire)
        {
            //如果需要PC移动 则解注释以下判断语句
            //if (OnButtonPressed.OnLongPressed == true)
            //{
            //    return false;
            //}
            return true;
        }
        if (EventSystem.current.currentSelectedGameObject == ReduceView)
        {
            return true;
        }
        if (EventSystem.current.currentSelectedGameObject == AddView)
        {
            return true;
        }
        //if (EventSystem.current.currentSelectedGameObject == Enter)
        //{
        //    return true;
        //}
        //if (EventSystem.current.currentSelectedGameObject == FarFrom)
        //{
        //    return true;
        //}
        
        return false;
    }

}