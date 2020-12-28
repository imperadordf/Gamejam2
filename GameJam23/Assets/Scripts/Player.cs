using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    bool gravidade;
    public Rigidbody rigi;
   public CinemachineFreeLook cinema;
    // Start is called before the first frame update
    void Start()
    {
        MudarGravidade();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MudarGravidade();
        }
    }

    private void MudarGravidade()
    {
        gravidade = !gravidade;
        if (gravidade)
        {
            Physics.gravity = new Vector3(0, -20, 0);
            transform.localRotation = new Quaternion(0, 0, 0,0);
            cinema.m_Lens.Dutch = 0;
        }
        else
        {
            Physics.gravity = new Vector3(0, 20, 0);
            transform.localRotation = new Quaternion(0, 0, 180, 0);
            cinema.m_Lens.Dutch = 180;
        }
    }
}
