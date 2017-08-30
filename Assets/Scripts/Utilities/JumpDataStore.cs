using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataStore : MonoBehaviour {

    public AnimationCurve m_acSmallJump;//小跳跃曲线对象
    //public AnimationCurve m_acBigJump;//大条曲线

    #region 小跳跃持续时间
    [SerializeField]
    private float smallduration;

    public float m_fSmallDuration//持续时间
    {
        get
        {
            return smallduration;
        }
    }
    #endregion

    #region 小跳跃高度
    [SerializeField]
    private float SmallJumpHeight;
    public float m_fSmallHeight//小跳跃高度
    {
        get
        {
            return SmallJumpHeight;
        }
    }
    #endregion

    #region 大跳跃持续时间
    [SerializeField]
    private float bigduration;

    public float m_fBigDuration
    {
        get
        {
            return bigduration;
        }
    }
    #endregion

    #region 大跳跃高度
    [SerializeField]
    private float BigJumpHeight;
    public float m_fBigJumpHeight
    {
        get
        {
            return BigJumpHeight;
        }
    }
    #endregion

    #region 当前的跳跃时长,跳跃高度
    [HideInInspector]
    public float m_CurDuration;
    [HideInInspector]
    public float m_CurJumpHeight;
    [HideInInspector]
    public AnimationCurve m_CurCurve;
    #endregion

    #region 切换到大条的百分比
    [HideInInspector]
    public float m_fChangeBigJumpPercent;
    //public float m_fChangeBigJumpPercent
    //{
    //    get
    //    {
    //        return BigJumpPercent;
    //    }
    //    set
    //    {
    //        if (value != BigJumpPercent)
    //            BigJumpPercent = value;
    //    }
    //}
    #endregion

    void Reset()
    {
        m_acSmallJump = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        //m_acBigJump = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    }

    void Awake()
    {
        //m_acBigJump = new AnimationCurve(
        //     new Keyframe(m_fChangeBigJumpPercent, m_acSmallJump.Evaluate(m_fChangeBigJumpPercent)),
        //     new Keyframe(0.5f, 1f),
        //     new Keyframe(1, 0)

        // );
    }

}
