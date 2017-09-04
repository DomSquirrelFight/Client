using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class CameraController : MonoBehaviour {

    [SerializeField]
    private eCamMoveDir BirthMoveDir = eCamMoveDir.CamMove_Right;

    private Vector3 cammovevector = Vector3.zero;
    public Vector3 m_vCamMoveVector
    {
        get
        {
            return cammovevector;
        }
    }
   
    #region 当前的运动方向
    private eCamMoveDir cammovedir;
    public eCamMoveDir CamMoveDir
    {
        get
        {
            return cammovedir;
        }
        set
        {
            if (value != cammovedir)
            {
                cammovedir = value;
                switch (cammovedir)
                {
                    case eCamMoveDir.CamMove_Left:
                        {
                            cammovevector = Vector3.left;
                            break;
                        }
                    case eCamMoveDir.CamMove_Right:
                        {
                            cammovevector = Vector3.right;
                            break;
                        }
                    case eCamMoveDir.CamMove_Up:
                        {
                            cammovevector = Vector3.up;
                            break;
                        }
                    case eCamMoveDir.CamMove_Down:
                        {
                            cammovevector = Vector3.down;
                            break;
                        }

                }
            }
               
        }
    }
    #endregion

    private BaseActor owner;
    public BaseActor Owner
    {
        get
        {
            return owner;
        }
    }

    void Update()
    {
        //todo_erric
        //switch (cammovedir)
        //{
        //    case eCamMoveDir.CamMove_Right:
        //        {
        //            if (Owner.ActorTrans.transform.position.x > m_vMiddlePoint.x)
        //            {
        //                transform.Translate(Vector3.right * 3f * Time.deltaTime, Space.World);
        //            }
        //            break;
        //        }
        //    case eCamMoveDir.CamMove_Left:{
        //        if (Owner.ActorTrans.transform.position.x < m_vMiddlePoint.x)
        //        {
        //            transform.Translate(Vector3.left * 3f * Time.deltaTime, Space.World);
        //        }
        //        break;
        //    }
        //}
    }

    public void OnStart(BaseActor _owner)
    {
        owner = _owner;
        CamMoveDir = BirthMoveDir;
    }

}   
