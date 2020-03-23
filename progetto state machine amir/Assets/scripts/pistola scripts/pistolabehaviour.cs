using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolabehaviour : MonoBehaviour
{
    public bool canshoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Aim()
    {
        this.transform.localPosition = new Vector3(0.87f, -0.8f, 2.45f);
    }

    public void NoAim()
    {
        this.transform.localPosition = new Vector3(1.2f, -0.93f, 2.45f);
    }
}
