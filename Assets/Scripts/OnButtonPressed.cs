using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;
// 继承：按下，抬起和离开的三个接口
public class OnButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    // 延迟时间
    private float delay = 0.5f;

    // 按钮是否是按下状态
    private bool isDown = false;

    // 按钮最后一次是被按住状态时候的时间
    private float lastIsDownTime;

    public Camera Sniping_Camera;
    public GameObject View;
    public static bool OnLongPressed =false;

    public static float OnLongPressTime = 1;


    void Update()
    {
        // 如果按钮是被按下状态
        if (isDown)
        {
            // 当前时间 -  按钮最后一次被按下的时间 > 延迟时间
            if (Time.time - lastIsDownTime > delay)
            {
                OnLongPressTime += 1;
                // 触发长按方法
                OnLongPressed = true;
                Sniping_Camera.GetComponent<Animator>().SetFloat("LongPress", OnLongPressTime);
                // 记录按钮最后一次被按下的时间
                lastIsDownTime = Time.time;
            }
        }
    }

    // 当按钮被按下后系统自动调用此方法
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        lastIsDownTime = Time.time;
    }

    // 当按钮抬起的时候自动调用此方法
    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        OnLongPressed = false;
        Fire();
    }

    // 当鼠标从按钮上离开的时候自动调用此方法
    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
    }


    //开火
    public void Fire()
    {
        if (ButtonFunction.CanFire)
        {
            float a = Random.Range(0, 1.0f);
            if (a == 0.5f)
            {
                a = 0.2f;
            }
            Sniping_Camera.GetComponent<Animator>().SetFloat("Fire", a);
        }
    }
}