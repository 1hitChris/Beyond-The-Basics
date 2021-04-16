using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public string[] shapes = { "circle", "square", "triangle", "octagon" };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i] = shapes[i].ToUpper();
            Debug.Log(shapes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
