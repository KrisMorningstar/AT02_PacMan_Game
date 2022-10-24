using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    //public GameObject pacman;
    public GameObject mirrorL;
    public GameObject mirrorR;
    public Vector3 posL;
    public Vector3 posR;
    public bool mirrorUsedL = false;
    public bool mirrorUsedR = false;
    private CharacterController charController;

    private void Awake()
    {
        //pacman = GetComponent<GameObject>();
        mirrorL = GameObject.FindGameObjectWithTag("Mirror Left");
        mirrorR = GameObject.FindGameObjectWithTag("Mirror Right");
        charController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        posL = new Vector3(mirrorL.transform.position.x, 0, mirrorL.transform.position.z);
        posR = new Vector3(mirrorR.transform.position.x, 0, mirrorR.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide");
        if(other.gameObject == mirrorL)
        {
            Debug.Log("Left");
            if (!mirrorUsedL && !mirrorUsedR)
            {
                Debug.Log("Port");
                charController.enabled = false;
                mirrorUsedL = true;
                transform.position = posR;
                charController.enabled = true;
            }
            
        }
        if(other.gameObject == mirrorR)
        {
            Debug.Log("Left");
            if (!mirrorUsedL && !mirrorUsedR)
            {
                Debug.Log("Port");
                charController.enabled = false;
                mirrorUsedR = true;
                transform.position = posL;
                charController.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == mirrorL)
        {
            if (mirrorUsedR)
            {
                mirrorUsedR = false;
                mirrorUsedL = false;
            }
        }
        if (other.gameObject == mirrorR)
        {
            if (mirrorUsedL)
            {
                mirrorUsedR = false;
                mirrorUsedL = false;
            }
        }
    }
}
