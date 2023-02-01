using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus {
    READY, START, OVER
}

public class CenterButton : MonoBehaviour
{
    
    public string colorStatus = "red";  //At least two status: red, blue

    public GameObject uigameOver;
    public GameObject uiStart;
    public GameObject uiScore;
    private SpriteRenderer sp;
    public bool active = false;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown("space")||Input.GetMouseButtonDown(0))
        {
            uiStart.SetActive(false);
            uiScore.SetActive(true);
            uigameOver.SetActive(false);
            if(!active){
                score = 0;
            }
            
            active = true;

            // print("Space Down");
            if(colorStatus=="red"){
                colorStatus ="blue";
                sp = GetComponent<SpriteRenderer>();
                // sp.color = new Color32(0, 0, 255, 1);
                sp.color = Color.blue;
                
            }else{
                colorStatus = "red";
                sp = GetComponent<SpriteRenderer>();
                // sp.color = new Color32(255, 0, 0, 1);
                sp.color= Color.red;
            }
            print("color:" + colorStatus);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        if(col.gameObject.GetComponent<Missile>().colorStatus == colorStatus){
            if(active){
                score += 1;
            }
        } else{
            active = false;
            uigameOver.SetActive(true);
            uiScore.SetActive(false);
        }
    }
}
