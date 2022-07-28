using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Renderer renderer;
    public Material mat0;
    public Material mat1;
   
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            renderer.material = mat1;
        }
    }
    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            renderer.material = mat0;
        }
    }
}
