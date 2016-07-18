using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour 
{
    private static BulletManager m_Manager = null;
    public  static BulletManager Manager{ get{ return m_Manager; } }

    public float frequency;
    public int amount;
    public float speed;
    public float speed_bias;

    public GameObject[] bullet_prefab_obj;

    private bool m_isEnable = false;
    private float tTime;

	// Use this for initialization
    void Awake()
    {
        m_Manager = this;
    }

	void Start () {
	
	}
	
    public void SetEnable(bool isEnable)
    {
        m_isEnable = isEnable;
    }

	// Update is called once per frame
	void Update () 
    {
        if (!m_isEnable) return;
        tTime += Time.deltaTime;
        if(tTime > frequency)
        {
            for(int i=0; i<amount; i++)
            {
                // Set random position
                float pos_x = Random.Range(-3.0f, 3.0f);
                float pos_y = Random.Range(-1.0f, 1.0f);

                // Set Random Type
                int type_idx = Random.Range(0, bullet_prefab_obj.Length);
                GameObject bullet = Instantiate(bullet_prefab_obj[type_idx], new Vector3(pos_x, 7.0f + pos_y, 0.0f), Quaternion.identity) as GameObject;

                // Set speed
                float rSpeed = speed + Random.Range(-speed_bias, speed_bias);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -rSpeed));
            }
            tTime = 0;
        }
	}
}
