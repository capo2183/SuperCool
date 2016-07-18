using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private static PlayerControl m_Ctrl;
    public  static PlayerControl Ctrl { get{ return m_Ctrl; } }
    public float m_FixSpeed = 5f;
//    public Transform m_PlayerTf;

    private void Awake()
    {
        m_Ctrl = this;
//        m_PlayerTf = this.transform;
    }

    public void Move( Vector3 _V3 )
    {
        _V3.x = _V3.x * m_FixSpeed;
        transform.Translate( _V3 );

        int _iScaleX = (_V3.x > 0) ? -1 : 1;
        transform.localScale = new Vector3(_iScaleX, 1, 1);
    }        

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            bool is_safe = coll.gameObject.GetComponent<Bullet>().is_safe;
            if(!is_safe)
                GetDamage();
        }
    }



    private void GetDamage()
    {
        Application.LoadLevel(0);
    }
}
