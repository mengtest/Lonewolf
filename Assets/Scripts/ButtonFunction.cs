using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour {

    public Camera Sniping_Camera;
    public Text Distance;
    public GameObject Bullet;
    public GameObject Mask;
    public static bool CanFire = true;

    void Update() {
        Distance.text = "距离：" + (Sniping_Camera.transform.position.z ).ToString();
    }


    public void ReplacementBullets() {
        Sniping_Camera.GetComponent<Animator>().SetTrigger("ChangeBullet");
    }

    public void ReduceView(int changeSize) {
        if (Sniping_Camera.orthographicSize > 9 && CameraFollow.CanMove)
        {
            Sniping_Camera.orthographicSize -= changeSize;
        }
    }

    public void AddView(int changeSize ) {
        if (Sniping_Camera.orthographicSize < 15 && CameraFollow.CanMove)
        {
            Sniping_Camera.orthographicSize += changeSize;
        }
    }
    

    public void FarFrom() {
        if (Sniping_Camera.transform.position.z < 300 && CameraFollow.CanMove)
        {
            Sniping_Camera.transform.position = new Vector3(
                Sniping_Camera.transform.position.x,
                Sniping_Camera.transform.position.y,
                Sniping_Camera.transform.position.z + 100
                );
        }

    }

    public void Enter()
    {
        if (Sniping_Camera.transform.position.z > 100 && CameraFollow.CanMove)
        {
            Sniping_Camera.transform.position = new Vector3(
            Sniping_Camera.transform.position.x,
            Sniping_Camera.transform.position.y,
            Sniping_Camera.transform.position.z - 100
            );
        }
    }

   

}
