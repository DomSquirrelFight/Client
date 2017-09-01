﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {

    BaseActor Owner;
    PlayerManager PlayerMgr;
    public void OnStart(BaseActor ba)
    {
        Owner = ba;
        PlayerMgr = Owner.PlayerMgr;
    }
	
	void Update () {
        PlayerMgr.PlayerMove();        
	}

    void LateUpdate()
    {
        InputSmallJump();
        InputBigJump();
        InputMove();
    }

    //检测是否触发小跳跃
    void InputSmallJump() {
        PlayerMgr.CalJumpInput();
    }

    //检测是否触发大跳跃
    void InputBigJump() { }

    //检查是否平移
    void InputMove() {
        PlayerMgr.CalMoveInput();//计算平移输入
    }
}
