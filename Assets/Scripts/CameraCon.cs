using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour {

    public float time = 0;
    public float CD = 5;
    public static float Speed = 0.1f;
    public Vector3 OldCameraPos;
    public RectTransform View;
    public GameObject Bullet;

    public GameObject Mask;
    private static Vector3 velocity = Vector3.zero;
    private int OnEnterStatic = 1;
    public GameObject CrossHair;

    Vector3 TargetPos = Vector3.zero;
    public float i = 0;

    private bool OneMove;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > CD)
        {
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x + Random.Range(-0.2f, 0.2f) * Speed ,
                gameObject.transform.position.y + Random.Range(-0.2f, 0.2f) * Speed ,
                gameObject.transform.position.z
                );
        }
        if (CameraFollow.MouseMoveDirection != Vector2.zero)
        {
            time = 0;
        }
    }

    /// 
    /// FSM Message
    /// OnEnter || OnExit || OnUpadate 

    public void OnChangeBulletOne() {
        if (OnEnterStatic == 1)
        {
            OnEnterStatic += 1;
            OldCameraPos = transform.position;
            //print("旧位置 : " + OldCameraPos);
            TargetPos = gameObject.transform.position + new Vector3(2 + Random.Range(-1.0f,1.0f), -2 + Random.Range(-1.0f, 1.0f), 0);
        }
        if (TargetPos != (Vector3.zero + OldCameraPos))
        {
            CrossHair.transform.localEulerAngles = Vector3.Lerp(CrossHair.transform.localEulerAngles, new Vector3(0, 0, 5), 0.3f);
            //Vector3.MoveTowards(gameObject.transform.position, TargetPos, 1f);
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, TargetPos, ref velocity, 0.2f);
            //transform.position = Vector3.Lerp(transform.position, TargetPos, 0.1f);
        }

    }
    public void OnChangeBulletTwo()
    {
        if (OnEnterStatic == 1)
        {
           // CrossHair.transform.localEulerAngles = new Vector3(0, 0, 10);
            OnEnterStatic += 1;
            TargetPos = gameObject.transform.position + new Vector3(0, -2 + Random.Range(-1.0f, 1.0f), 0);

        }
        if (TargetPos != (Vector3.zero + OldCameraPos))
        {
            CrossHair.transform.localEulerAngles = Vector3.Lerp(CrossHair.transform.localEulerAngles, new Vector3(0, 0, 7), 0.3f);
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, TargetPos, ref velocity, 0.2f);
            //transform.position = Vector3.Lerp(transform.position, TargetPos, 0.1f);
        }

    }
    public void OnChangeBulletThree()
    {
        if (OnEnterStatic == 1)
        {
            //CrossHair.transform.localEulerAngles = new Vector3(0, 0, 10);
            OnEnterStatic += 1;
            TargetPos = gameObject.transform.position + new Vector3(0, 2 + Random.Range(-1.0f, 1.0f), 0);

        }
        if (TargetPos != (Vector3.zero + OldCameraPos))
        {
            CrossHair.transform.localEulerAngles = Vector3.Lerp(CrossHair.transform.localEulerAngles, new Vector3(0, 0, 5), 0.3f);
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, TargetPos, ref velocity, 0.2f);
            //transform.position = Vector3.Lerp(transform.position, TargetPos, 0.1f);
        }

    }
    public void OnChangeBulletFour()
    {
        if (OnEnterStatic == 1)
        {
            CrossHair.transform.localEulerAngles = new Vector3(0, 0, 10);
            OnEnterStatic += 1;
            TargetPos = gameObject.transform.position + new Vector3(-1.5f + Random.Range(-1.0f, 1.0f), 8 + Random.Range(-1.0f, 1.0f), 0);

        }
        if (TargetPos != (Vector3.zero + OldCameraPos))
        {
            CrossHair.transform.localEulerAngles = Vector3.Lerp(CrossHair.transform.localEulerAngles, new Vector3(0, 0, 5), 0.3f);
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, TargetPos, ref velocity, 0.2f);
            //transform.position = Vector3.Lerp(transform.position, TargetPos, 0.1f);
        }

    }
    public void OnChangeBulletFive()
    {
        if (OnEnterStatic == 1)
        {
            OnEnterStatic += 1;
        }
        if (TargetPos != (Vector3.zero + OldCameraPos))
        {
            CrossHair.transform.localEulerAngles = Vector3.Lerp(CrossHair.transform.localEulerAngles, new Vector3(0, 0, 0), 0.3f);
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, OldCameraPos, ref velocity, 0.1f);
            //transform.position = Vector3.Lerp(transform.position, OldCameraPos, 0.1f);
        }

    }

    public void OnClearStatic() {
        OnEnterStatic = 1;
        TargetPos = Vector3.zero;
        OneMove = false;
        GetComponent<Animator>().SetFloat("Fire", 0.5f);
    }

    public void OnEnterIdle() {
        CameraFollow.CanMove = true;
        ButtonFunction.CanFire = true;
        OnButtonPressed.OnLongPressTime = 0;
        gameObject.GetComponent<Animator>().SetFloat("LongPress", OnButtonPressed.OnLongPressTime);
        View.localScale = new Vector3(1, 1, 1);
        CameraFollow.MouseSensitivity = 0.5f;
        Speed = 0.1f;
    }

    public void OnExitIdle() {
        CameraFollow.CanMove = false;
        ButtonFunction.CanFire = false;
    }

    public void OnFireMaskScale() {
        if (Mask.GetComponent<SpriteRenderer>().color.a<1.0f  && Mask.GetComponent<SpriteRenderer>().color.a > 0.0f)
        {
            if (OnEnterStatic == 1)
            {
                OnEnterStatic += 1;
                View.localScale = new Vector3(2, 2, 1);
                
            }
            if (View.localScale != new Vector3(1, 1, 1))
            {
                View.localScale = Vector3.SmoothDamp(View.localScale, new Vector3(1, 1, 1), ref velocity, 0.2f);
            }
        }
    }

    public void OnChangeCameraPos() {
        transform.position = gameObject.transform.position + new Vector3(0, 2, 0);
    }

    public void OnLongPress() {
        CameraFollow.CanMove = true;
        ButtonFunction.CanFire = true;
        CameraFollow.MouseSensitivity = 0.1f;
        Speed = 0.05f;
        View.localScale = Vector3.SmoothDamp(View.localScale, new Vector3(1.3f, 1.3f, 1), ref velocity, 0.2f);
    }

    public void BulletFire() {
        Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
    }
}
