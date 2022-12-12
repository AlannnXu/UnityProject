using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    //public int direction;
    public float width;
    private LineRenderer lineRenderer;

    public float countDown;
    public float lastingTime;

    private float timer;
    private float timer_laser;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = width;
        lineRenderer.useWorldSpace = true;

        timer = countDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(lineRenderer.enabled == true)
            {
                if(timer_laser > 0)
                {

                    timer_laser -= Time.deltaTime;
                }
                else
                {
                    lineRenderer.enabled = false;
                }

            }
        }
        else
        {
            timer = countDown;
            lineRenderer.enabled = true;
            timer_laser = lastingTime;
        }
        Shoot();
    }

    void Shoot()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, 1000, (1 << 8) | (1 << 11) | (1 << 12));

        if (hit)
        {
            if(hit.collider.tag == "Player")
            {
                hit.collider.GetComponent<Player>().PlayerDeath();
            }
            else if(hit.collider.tag == "Enemy")
            {
                //hit.collider.GetComponent<Enemy>().Death();
            }
        }
        Debug.DrawLine(transform.position, hit.point, Color.red);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);



    }
}
