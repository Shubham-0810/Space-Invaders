using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollScript : MonoBehaviour
{
    public float ScrollSpeed = 0.1f;

    private MeshRenderer mesh_renderer;

    private float x_scroll;

    // Start is called before the first frame update
    void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
    }

    void scroll()
    {
        x_scroll = Time.time * ScrollSpeed;

        Vector2 offset = new Vector2(x_scroll,0f);
        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

            
            
    }
}
