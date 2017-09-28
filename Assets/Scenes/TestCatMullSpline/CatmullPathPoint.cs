using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scenes.TestCatmull
{
    public class CatmullPathPoint : MonoBehaviour
    {

        public enum eCatmullPointType
        {
            ePoint_Area1,
            ePoint_Area2,
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
                        Gizmos.color = Color.cyan;
                        break;
                    }
            }
           

            Gizmos.DrawWireSphere(transform.position, .5f);
        }

    }
}

