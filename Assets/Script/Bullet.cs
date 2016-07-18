using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public  bool            is_safe             = false;
    private Rigidbody2D     m_Rigidbody2D       = null;
    private SpriteRenderer  m_SpriteRenderer    = null;

    void Awake()
    {
        m_SpriteRenderer    = this.GetComponent<SpriteRenderer>();
        m_Rigidbody2D       = this.GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start ()
    {
        this.Init();
    }

    private void Init()
    {
        is_safe = false;
        m_SpriteRenderer.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
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

    public void SetLinerDrag(float _Value)
    {
        m_Rigidbody2D.drag = _Value;
    }
}
