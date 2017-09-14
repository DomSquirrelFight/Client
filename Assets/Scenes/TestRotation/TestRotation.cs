using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour {

    public Transform m_tOrig;


    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 50, 50), "Rotate"))
        {
            StartCoroutine(Rotating());
        }
    }

    float PI = 3.1415926f;
    float raidus = 2f;

    IEnumerator Rotating()
    {

        Vector3 dir = (m_tOrig.position - transform.position).normalized;

        float v = 2 * PI * raidus;

        while (Mathf.Abs (m_tOrig.position.x - transform.position.x) > 0.1f) {
                transform.LookAt(m_tOrig);

                transform.Translate(Vector3.up * v * Time.deltaTime) ;

                yield return null;
        }




      
    }

}
