using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollide : MonoBehaviour
{
    public Animator enemyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void DestroySelf()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
