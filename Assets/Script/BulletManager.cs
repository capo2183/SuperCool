using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[System.Serializable]
public class BulletManager :GameSystem 
{
    public float frequency;
    public int amount;
    public float speed;
    public float speed_bias;

    public GameObject[] bullet_prefab_obj;

//    private bool m_isEnable = false;
    private float tTime;

	// Use this for initialization
    public override void  Awake()
    {
//        m_Manager = this;
    }

    public override void  Start () {
	
	}

	// Update is called once per frame
    public override void Update () 
    {
        if (!m_isEnabled) return;
        tTime += Time.deltaTime * MainGameHost.MonoRef.GetTimeScale;
        if(tTime > frequency)
        {
            for(int i=0; i<amount; i++)
            {
                // Set random position
                float pos_x = Random.Range(-3.0f, 3.0f);
                float pos_y = Random.Range(-1.0f, 1.0f);

                // Set Random Type
                int type_idx = Random.Range(0, bullet_prefab_obj.Length);
                GameObject bullet = PathologicalGames.PoolManager.Pools["Bullet"].Spawn(bullet_prefab_obj[type_idx].transform).gameObject;
                bullet.transform.position = new Vector3(pos_x, 7.0f + pos_y, 0.0f);
                bullet.GetComponent<Bullet>().SetLinerDrag( MainGameHost.MonoRef.GetTimeScale );
            }
            tTime = 0;
        }
	}

    public void SetLinerDrag(float _fLonerFrag)
    {
        GameObject[] _Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for(int i = 0 ; i < _Bullets.Length ; i ++)
        {
            Bullet _b =  _Bullets[i].GetComponent<Bullet>();
            _b.SetLinerDrag(_fLonerFrag);
        }
    }
}
