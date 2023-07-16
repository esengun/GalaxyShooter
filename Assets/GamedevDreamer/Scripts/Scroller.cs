using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScrollSpace
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] RawImage img;
        [SerializeField] float x,y;

        void Update()
        {
            img.uvRect = new Rect(img.uvRect.position + new Vector2(x,y) * Time.deltaTime, img.uvRect.size);
        }
    }

}


