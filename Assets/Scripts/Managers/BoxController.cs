using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    public float FSpeed;

    public float FDuration;

    Vector3 m_vDir;
    float m_fStartTime;
    void Awake()
    {
        m_fStartTime = 0f;
        m_vDir = Vector3.zero;
    }
    public void OnStart() {
        m_fStartTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (m_fStartTime != 0f)
        {
            if (Time.time - m_fStartTime > FDuration)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(transform.forward * FSpeed * Time.deltaTime, Space.World);
               // transform.position += ( );
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {

    }

}
