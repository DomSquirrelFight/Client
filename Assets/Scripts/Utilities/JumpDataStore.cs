using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataStore : MonoBehaviour {


    public AnimationCurve m_acSmallJump;//小跳跃曲线对象

    [SerializeField]//跳跃持续时间
    private float duration;
    public float m_fDuration//持续时间
    {
        get
        {
            return duration;
        }
    }

    [SerializeField]//跳跃高度
    private float JumpHeight;
    public float m_fHeight//跳跃高度
    {
        get
        {
            return JumpHeight;
        }
    }

    [Range(0f, 0.45f)][SerializeField]//切换到大条的百分比
    private float BigJumpPercent;
    public float m_fChangeBigJumpPercent
    {
        get
        {
            return BigJumpPercent;
        }
    }

    public AnimationCurve m_acBigJump;//大条曲线
    
    void Reset()
    {
        m_acSmallJump = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    }

    void Awake()
    {
        m_acBigJump = new AnimationCurve(
             new Keyframe(m_fChangeBigJumpPercent, m_acSmallJump.Evaluate(m_fChangeBigJumpPercent)),
             new Keyframe(0.5f, 1f),
             new Keyframe(1, 0)

         );
    }

}
