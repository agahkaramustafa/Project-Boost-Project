using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLights : MonoBehaviour
{
    Light m_light;

    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponentInChildren<Light>();
        m_light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLight()
    {
        m_light.enabled = !m_light.enabled;
    }
}
