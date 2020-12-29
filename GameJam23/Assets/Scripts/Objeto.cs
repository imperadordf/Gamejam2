using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public Rigidbody rigi;
    public BoxCollider ColliderTrigger;
    public void PegouObjeto(Transform ObjectPlayer)
    {
        rigi.isKinematic = true;
        rigi.useGravity = false;
        transform.parent = ObjectPlayer;
        transform.localPosition = new Vector3(0,0,0);
        transform.rotation = new Quaternion(0, 0, 0,0);
        ColliderTrigger.enabled = false;
    }

    public void SoltarObject()
    {
        rigi.isKinematic = false;
        rigi.useGravity = true;
        transform.parent = null;
        ColliderTrigger.enabled = true;
    }
}
