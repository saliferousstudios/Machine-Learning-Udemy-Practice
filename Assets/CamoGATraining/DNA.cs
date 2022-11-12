using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DNA : MonoBehaviour
{
    // gene for color
    public float r;
    public float g;
    public float b;
    bool dead = false;
    public float timeToDie = 0;
    SpriteRenderer spriteRenderer;
    Collider2D collider2D;
    

    
    // called when something is clicked.
    void OnMouseDown()
    {
        dead = true;
        timeToDie = PopulationManager.elapsed;
        Debug.Log("Dead at " + timeToDie);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer.color = new Color(r, g, b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
