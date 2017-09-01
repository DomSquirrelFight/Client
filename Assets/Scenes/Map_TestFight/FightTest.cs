using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class FightTest : MonoBehaviour {

    public eRoleID m_eRoleId = eRoleID.Role_Major;

    public StartPoint m_sp;

    BaseActor m_Player;
	// Use this for initialization
	void Start () {

        //加载主角
        m_Player = BaseActor.CreatePlayer("LocalMajor", m_eRoleId, m_sp.transform.position, m_sp.transform.rotation);

        int a = 0;

		
	}
	

}
