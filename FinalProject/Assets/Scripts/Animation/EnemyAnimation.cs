using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public EnemyMove enemyScript;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.isInBlue)
        {
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }
    }
}
