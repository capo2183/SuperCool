using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public bool is_safe;
      
	// Use this for initialization
	void Start ()
    {
        is_safe = false;
        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void DestoryObj()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            is_safe = true;
            this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            this.GetComponent<Rigidbody2D>().mass = 0.1f;
            Invoke("DestoryObj", 0.5f);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            if (col.gameObject.GetComponent<Bullet>().is_safe)
            {
                is_safe = true;
                this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                this.GetComponent<Rigidbody2D>().mass = 0.1f;
            }
        }
    }
}
