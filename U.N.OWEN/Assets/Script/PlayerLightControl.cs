using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.LWRP;

#if UNITY_EDITOR
using UnityEditor.Experimental.SceneManagement;
#endif

public class PlayerLightControl : MonoBehaviour
{
    public GameObject PlayerLight;

    private float lightRed;
    private float lightGreen;
    private float lightBlue;

    // Start is called before the first frame update
    void Start()
    {
        lightRed = PlayerLight.GetComponent<Light2D>().color.r;
        lightGreen = PlayerLight.GetComponent<Light2D>().color.g;
        lightBlue = PlayerLight.GetComponent<Light2D>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MeleeEnemy") || collision.gameObject.CompareTag("RangeEnemy"))
        {
            PlayerLight.GetComponent<Light2D>().color = new Color(lightRed, lightGreen, lightBlue);
            if (lightRed > 104) lightRed -= 0.1f;
            if (lightBlue > 104) lightBlue -= 0.1f;
            if (lightGreen > 104) lightGreen -= 0.1f;
        }
        else
        {
            if (lightRed < 241) lightRed += 0.1f;
            if (lightGreen < 239) lightGreen += 0.1f;
            if (lightBlue < 239) lightBlue += 0.1f;
        }
    }
}
