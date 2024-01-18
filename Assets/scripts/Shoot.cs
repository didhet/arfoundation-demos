using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject turret;


    // Update is called once per frame
    void Update()
    {
        //S'il y a au moins un "touch" détecté
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if(Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Touch on " + hit.transform.name);

                    turret.GetComponent<TurretAI>().currentTarget = hit.transform.gameObject;
                    turret.GetComponent<TurretAI>().Shoot(hit.transform.gameObject);
                }
                else
                {
                    Debug.Log("Nothing hit");
                }
            }
        }
    }
}
