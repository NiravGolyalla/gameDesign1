using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    public GameObject missiles;


    private float speedSave;
    private float timeSave;



    public float speed;
    public float speedlimit;
    public float time;
    public float timelimit = 0.5f;
    float timeToFire;

    public float minRange;
    public float maxRange;
    // Update is called once per frame
    
    void Start(){
        speedSave = speed;
        timeSave = time;
    }
    
    void Update()
    {
        if(target != null){
            if(target.GetComponent<CenterButton>().active) {
                if(timeToFire <= 0f){
                    timeToFire = time;
                    if(speed < speedlimit){
                        speed += .2f;
                    }
                    if(time > timelimit){
                        time -= .2f;
                    }
                Spawn();
                }
            timeToFire -= Time.deltaTime; 
            } else{
                Reset();
            }
        }
    }

    void Spawn(){
        int xcha = Random.Range(0,2);
        float xpos;
        
        if(xcha == 0){
            xpos = Random.Range(minRange, maxRange); 
        } else{
            xpos = Random.Range(-maxRange, -minRange); 
        }
        
        int ycha = Random.Range(0,2);
        float ypos;
        
        if(ycha == 0){
            ypos = Random.Range(minRange, maxRange); 
        } else{
            ypos = Random.Range(-maxRange, -minRange); 
        }
        
        var position = new Vector3(xpos,ypos, 0);
        GameObject missile = Instantiate(missiles, position, Quaternion.identity);
        missile.GetComponent<Missile>().target = target;
        missile.GetComponent<Missile>().moveSpeed = Random.Range(speed, speed*1.5f);;
    }

    void Reset(){
        speed = speedSave;
        time= timeSave;
    }
}
