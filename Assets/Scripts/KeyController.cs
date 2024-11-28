using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject llave;
    void Update()
    {
        if(Knight.TotalMoney >= 30){
            llave.SetActive(true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
