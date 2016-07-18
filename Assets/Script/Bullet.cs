using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public  bool            is_safe             = false;
    private SpriteRenderer  m_SpriteRenderer    = null;
    private Rigidbody2D     m_rigidbody         = null;

    private float delta_t;
    private float delta_s;
    private float velocity;
    public float max_velocity;
    public float gravity = 0.0098f;

    public float destory_interval;
    private float elapsed_time;

    void Awake()
    {
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        m_rigidbody = this.GetComponent<Rigidbody2D>();
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
        elapsed_time = 0.0f;
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
            m_rigidbody.gravityScale = 1.0f;
        }
        else if (col.gameObject.tag == "Bullet")
        {
            if (col.gameObject.GetComponent<Bullet>().is_safe)
            {
                is_safe = true;
                this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                m_rigidbody.gravityScale = 1.0f;
            }
        }
    }

    public void Update()
    {
        if (is_safe)
        {
            elapsed_time += delta_t * Time.deltaTime / 0.15f;
            if(elapsed_time > destory_interval)
            {
                DestoryObj();
            }
        }
        else
        {        
            delta_s = velocity * delta_t + (gravity * Mathf.Pow(delta_t, 2)) / 2.0f;
            transform.position -= new Vector3(0.0f, delta_s, 0.0f);
            velocity += gravity * delta_t;
            if (velocity > max_velocity)
            {
                velocity = max_velocity;
            }
        }
    }
    
    public void SetDeltaTime(float _Value)
    {
        delta_t = _Value * 0.15f;
    }
}
