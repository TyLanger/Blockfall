using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        Health h = GetComponent<Health>();
        if (h)
        {
            h.OnDeath += Die;
        }

    }

    public void Fall()
    {
        if (!HasFallen())
        {
            hasFallen = true;
            // flash a colour for a bit
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public bool HasFallen()
    {
        return hasFallen;
    }

    void Die()
    {
        // maybe it should fall if it hasn't?
        Destroy(gameObject);
    }
}
