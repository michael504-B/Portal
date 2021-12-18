using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public float range = 30;
    public Portal[] portals;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        portals = FindObjectsOfType<Portal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {

           
            Vector3 position = Camera.main.transform.position;
            RaycastHit RCH = new RaycastHit();
            if (Physics.Linecast(position, position + Camera.main.transform.forward * range, out RCH, 1))
            {
                int index = Input.GetButtonDown("Fire1") ? 0 : 1;
                portals[index].MovePortal(RCH);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                PortalSlash();
            }
            else
            {
                PortalSlashTwo();
            }



        }

        /*
        if (Input.GetButtonDown("Fire2"))
        {

            PortalSlashTwo();
            Vector3 position = Camera.main.transform.position;
            RaycastHit RCH = new RaycastHit();
            if (Physics.Linecast(position, position + Camera.main.transform.forward * range, out RCH, 1))
            {
                int index = Input.GetButtonDown("Fire2") ? 0 : 1;
                portals[index].MovePortal(RCH);
            }

        }*/
    }

    public void PortalSlash()
    {
        anim.SetTrigger("PS");
    }

    public void PortalSlashTwo()
    {
        anim.SetTrigger("PSTwo");
    }
}
