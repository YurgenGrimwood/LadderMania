using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.parent.GetComponent<BoardController>().hovered = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
