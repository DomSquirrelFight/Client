using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataStore : MonoBehaviour {


    public AnimationCurve m_acJump;
    public float m_fDuration;
    public float m_fHeight;

    void Reset()
    {
         m_acJump = new AnimationCurve(new Keyframe(0, 0), new Keyframe (1, 1));
    }
}
