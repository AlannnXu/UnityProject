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

    public GameObject OpenPanel(string panelName)
    {
        foreach (Transform item in panels)
        {
            if(item.name == panelName)
            {
                GameObject go = item.gameObject;
                go.SetActive(true);
                return go;
            }
        }
        return null;
    }

    public void  ClosePanel(string panelName)
    {
        foreach (Transform item in panels)
        {
            if (item.name == panelName)
            {
                GameObject go = item.gameObject;
                go.SetActive(false);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
