using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.WayFinding;
public class TestRunningForward : MonoBehaviour {

    public int roleid;

    public PathArea area;

    float m_fCurPercent, m_fPer;

    BaseActor Owner;

    public Transform StartPoint;

	// Use this for initialization
	void Start () {

        Owner = BaseActor.CreatePlayer(101, StartPoint.position, StartPoint.rotation, StartPoint.localScale);

        Owner.SetCurRoleBehavInfos( eRunMode.eRun_Vertical);

	}
	
	// Update is called once per frame
	void Update () {

        float he = Input.GetAxis("Horizontal");

        CalCurvePercent();

        int dir = (int)GlobalHelper.GetDIr(he);

        Owner.CRunFor.VerticalMove(dir, PathArea.GetVectorArray(area), m_fPer, Owner.RoleBehaInfos.CanRoleMoveHorizontal);

	}

    void CalCurvePercent()
    {
        m_fCurPercent += Owner.RoleBehaInfos.RoleMoveSpeed * Time.deltaTime;

        m_fPer = m_fCurPercent % 1f;
    }

    void OnDrawGizmos()
    {

        PathFinding.GizmoDraw(PathArea.GetVectorArray(area), m_fPer);
    }

}
