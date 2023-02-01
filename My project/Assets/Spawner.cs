using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    public GameObject missiles;

    public float speed;
    public float time;
    public float limit;
    float timeToFire;

    public float minRange;
    public float maxRange;
    // Update is called once per frame
    void Update()
    {
        if(target != null){
            if(target.GetComponent<CenterButton>().active) {
                if(timeToFire <= 0f){
                    timeToFire = time;
                    //speed += 0.2f;
                    if(time > limit){
                        time -= .05f;
                }
                Spawn();
            }
            timeToFire -= Time.deltaTime; 
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
        missile.GetComponent<Missile>().moveSpeed = speed;
    }
}
