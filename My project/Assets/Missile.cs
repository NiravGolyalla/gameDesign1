using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 1;
    public string colorStatus;
    // Start is called before the first frame update
    void Start()
    {
        int col = Random.Range(0,2);
        if(col == 0){
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            colorStatus = "blue";
        } else{
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            colorStatus = "red";
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        if(!target.GetComponent<CenterButton>().active){
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position,
        target.transform.position, moveSpeed * Time.deltaTime);

        if ((transform.position - target.transform.position).magnitude < .01f)
        {
            Destroy(gameObject);
        }
        
        float rotx = target.transform.position.x - transform.position.x;
        float roty = target.transform.position.y - transform.position.y;
        float angle = Mathf.Atan2(roty, rotx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90f));
    }
}
