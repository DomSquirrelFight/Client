using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class FightTest : MonoBehaviour {

    public int m_eRoleId = 101;

    public StartPoint m_sp;

    BaseActor m_Player;
	// Use this for initialization
	void Awake () {
        //加载主角
        m_Player = BaseActor.CreatePlayer(m_eRoleId, m_sp.transform.position, m_sp.transform.rotation, Vector3.one);
	}
	

}
