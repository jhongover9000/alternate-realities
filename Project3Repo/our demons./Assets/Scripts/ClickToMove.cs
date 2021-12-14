// ClickToMove.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    int isWalkingHash;
    int velocityXHash;
    int velocityZHash;
    int isAttackingHash;
    public AudioSource sound;

    public GameObject nextOni;
    Coroutine coroutine;

    bool isAttacking = false;
    bool hasAttacked = false;
    bool isDead = false;

    RaycastHit hitInfo = new RaycastHit();

    public bool allowClickToMove = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isAttackingHash = Animator.StringToHash("isAttacking");
        velocityXHash = Animator.StringToHash("velocityX");
        velocityZHash = Animator.StringToHash("velocityZ");
    }

    void Update()
    {
        if (!isDead)
        {
            bool isMoving = agent.velocity.magnitude > 0.01f && agent.remainingDistance > agent.radius;
            Vector3 velocity = agent.velocity;

            animator.SetBool(isWalkingHash, isMoving);

            velocity = transform.InverseTransformVector(velocity);

            animator.SetFloat(velocityXHash, velocity.x);
            animator.SetFloat(velocityZHash, velocity.z);

            Vector3 PlayerLoc = PlayerManager.Instance.xrRig.transform.position;
            agent.SetDestination(PlayerLoc);
        }
        else
        {
            agent.SetDestination(transform.position);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            if(nextOni != null)
            {
                coroutine = StartCoroutine(SpawnOni());
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isAttackingHash, true);
            isAttacking = true;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            animator.SetBool("isDead", true);
            sound.Stop();
            isDead = true;
        }
    }

    public void DisableClickToMove()
    {
        allowClickToMove = false;
        
    }

    public void EnableClickToMove()
    {
        allowClickToMove = true;
    }

    // spawn new oni (and delete old one)
    IEnumerator SpawnOni()
    {
        yield return new WaitForSeconds(3);
        nextOni.SetActive(true);
        //yield return new WaitForSeconds(1);
        //gameObject.SetActive(false);
    }
}