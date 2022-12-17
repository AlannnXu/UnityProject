using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer BGMMixer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGMVolume(float volume)    // 控制主音量的函数
    {
        BGMMixer.SetFloat("BGM", volume);
        // MasterVolume为我们暴露出来的Master的参数
    }

}
