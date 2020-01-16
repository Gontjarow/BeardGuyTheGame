using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementV2 : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 2.0f;
    public float rayDist = 2.0f;
    public int beardCount = 0;
    float timer = 5.0f;
    bool startTimer = false;

    RaycastHit rayHit;
    Vector3 targetPos;

    BushMechanism puskaScript;
    SpawnBeardPiece spawnerScript;
    HUD HUDScript;

    Animator animController;
    public Animation doorAnim;

    public MeshRenderer axeRenderer;


    void Move(Vector3 direction)
    {
        // Rotate player model towards the right direction.
        float angle = Vector3.SignedAngle(transform.GetChild(0).forward, direction, Vector3.up);
        transform.GetChild(0).Rotate(Vector3.up, angle);

        Debug.DrawRay(targetPos, direction * rayDist, Color.blue, 120);

        // If the raycast DIDN'T hit anything
        if( !Physics.Raycast(targetPos, direction, out rayHit, rayDist) )
        {
            // Move if there's enough beard left
            if( beardCount > 0 )
            {
                spawnerScript.Trigger(direction, transform.position);
                
                targetPos += direction * distance;
                animController.SetBool("Walk", true);

                HUDScript.UpdateBeard(--beardCount);
            }
            else Debug.Log("No moves left");
        }
        else // Raycast hit something.
        {
            if( rayHit.collider.name == "Shack" )
            {
                animController.SetBool("End", true);
                doorAnim.Play();
                startTimer = true;
                Debug.Log("u won");
            }
            else if( rayHit.collider.name.Substring(0, 13) == "Ground Growth" )
            {
                puskaScript = rayHit.collider.GetComponentInParent<BushMechanism>();
                if( puskaScript.OnkoMarja() )
                {
                    animController.SetTrigger("Eat");
                    HUDScript.UpdateBeard(beardCount += 5);
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;

        puskaScript = GetComponent<BushMechanism>();
        spawnerScript = GetComponent<SpawnBeardPiece>();
        HUDScript = GetComponent<HUD>();

        animController = GetComponentInChildren<Animator>();
        animController.SetBool("Idle Still", true);
    }

    void Update()
    {
        if( transform.position == targetPos )
        {
            animController.SetBool("Walk", false);

            if( Input.GetKeyDown(KeyCode.W) )
            {
                Move(Vector3.forward);
            }
            if( Input.GetKeyDown(KeyCode.A) )
            {
                Move(Vector3.left);
            }
            if( Input.GetKeyDown(KeyCode.S) )
            {
                Move(Vector3.back);
            }
            if( Input.GetKeyDown(KeyCode.D) )
            {
                Move(Vector3.right);
            }
        }

        if(startTimer)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0.0f)
        {
            axeRenderer.enabled = true;
        }
        

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
    }
}


