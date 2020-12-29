using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    bool gravidade;
    public Rigidbody rigi;
   public CinemachineFreeLook cinema;
    private Objeto objectScript;
    public Transform ObjectPlayer;
    public float speed;
    bool pegouObject;
    // Start is called before the first frame update
    void Start()
    {
        MudarGravidade();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MudarGravidade();
        }
        else if (Input.GetKeyDown(KeyCode.C)&& objectScript && pegouObject)
        {
            objectScript.SoltarObject();
            pegouObject = false;
        }
       
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = new Vector3(x, 0, y);
        rigi.velocity = position.normalized * speed;
        print(position);
    }

    private void MudarGravidade()
    {
        gravidade = !gravidade;
        if (gravidade)
        {
            Physics.gravity = new Vector3(0, -20, 0);
            transform.localRotation = new Quaternion(0, 0, 0,0);
           // cinema.m_Lens.Dutch = 0;
        }
        else
        {
            Physics.gravity = new Vector3(0, 20, 0);
            transform.localRotation = new Quaternion(0, 0, 180, 0);
           // cinema.m_Lens.Dutch = 180;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectScript = other.GetComponent<Objeto>();
                objectScript.PegouObjeto(ObjectPlayer);
                pegouObject = true;
            }
        }
    }
}
