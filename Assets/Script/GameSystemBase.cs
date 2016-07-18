using UnityEngine;
using System.Collections;

public class GameSystem{
    protected bool m_isEnabled = false;
    public virtual void Awake()
    {

    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {

    }

    public virtual void End()
    {

    }

    public virtual void SetEnabled(bool _isEnabled )
    {
        m_isEnabled = _isEnabled;
    }

}
