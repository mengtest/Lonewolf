using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Bullet")
        {
            print(col.transform.position);
            Destroy(col.gameObject);
        }
    }
}
