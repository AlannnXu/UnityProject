using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyNumText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.keyNum.ToString();
    }
}
