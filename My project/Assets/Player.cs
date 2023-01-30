using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
<<<<<<< HEAD
            // this.gameObject.getComponent()<SpriteRender>.color = Color.blue;
=======
            gameObject.getComponent()<SpriteRender>.color = Color.blue;
>>>>>>> parent of 798205d (Added Triangles + Spawners)
        }
    }
}
