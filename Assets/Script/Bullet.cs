using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public  bool            is_safe             = false;
    private SpriteRenderer  m_SpriteRenderer    = null;

    public float delta_t;
    public float delta_s;
    public float velocity;
    public float max_velocity;
    public float gravity = 0.0098f;

    void Awake()
    {
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        velocity = 0.0f;
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
            Invoke("DestoryObj", 0.5f);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            if (col.gameObject.GetComponent<Bullet>().is_safe)
            {
                is_safe = true;
                this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            }
        }
    }

    public void Update()
    {
        delta_s = velocity * delta_t + (gravity * Mathf.Pow(delta_t, 2)) / 2.0f;
        transform.position -= new Vector3(0.0f, delta_s, 0.0f);
        velocity += gravity * delta_t;
        if(velocity > max_velocity)
        {
            velocity = max_velocity;
        }
    }
    
    public void SetLinerDrag(float _Value)
    {
        delta_t = _Value * 0.15f;
    }
}
