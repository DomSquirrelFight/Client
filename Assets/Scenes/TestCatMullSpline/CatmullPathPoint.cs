﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scenes.TestCatmull
{
    public class CatmullPathPoint : MonoBehaviour
    {


        public static Vector3[] GetVectorArray(CatmullPathPoint[] pa)
        {
            Vector3[] m_vCurPoints = new Vector3[pa.Length];

            for (int i = 0; i < m_vCurPoints.Length; i++)
            {
                m_vCurPoints[i] = pa[i].transform.position;
            }

            return m_vCurPoints;

        }
        public enum eCatmullPointType
        {
            ePoint_Area1,
            ePoint_Area2,
            ePoint_ExtraPoint,
        }

        public eCatmullPointType PointType = eCatmullPointType.ePoint_Area1;


        void OnDrawGizmos()
        {

            switch (PointType)
            {
                case eCatmullPointType.ePoint_Area1:
                    {
                        Gizmos.color = Color.green;
                        break;
                    }
                case eCatmullPointType.ePoint_Area2:
                    {
                        Gizmos.color = Color.white;
                        break;
                    }
                case eCatmullPointType.ePoint_ExtraPoint:
                    {
                        Gizmos.color = Color.black;
                        break;
                    }
            }
           

            Gizmos.DrawWireSphere(transform.position, .5f);
        }

    }
}
