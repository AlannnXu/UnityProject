using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    private static PanelManager pm;
    
    // Start is called before the first frame update

    private void Awake()
    {
        if(pm == null)
        {
            pm = this;
        }
    }

    public static PanelManager GetPanelManager()
    {
        return pm;
    }

    public List<Transform> panels = new List<Transform>();


    void Start()
    {
        foreach(Transform item in panels)
        {
            item.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
