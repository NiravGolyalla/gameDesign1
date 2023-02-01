using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    public GameObject missiles;


    private int speedSave;
    private float timeSave;



    public int speed;
    public int speedlimit;
    public float time;
    public float timelimit = 0.5f;
    float timeToFire;
    private int speedtracker;

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
                        if(speedtracker > 3){
                            speed += 1;
                            speedtracker = 0;
                        }
                        speedtracker += 1;
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
        float newspeed = (float) (Random.Range(speedSave, speed));
        missile.GetComponent<Missile>().moveSpeed = newspeed;
    }

    void Reset(){
        speed = speedSave;
        time= timeSave;
    }
}
