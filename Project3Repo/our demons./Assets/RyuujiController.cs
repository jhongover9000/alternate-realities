using UnityEngine;
using UnityEngine.AI;

public class RyuujiController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    int isWalkingHash;
    int velocityXHash;
    int velocityZHash;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        isWalkingHash = Animator.StringToHash("isWalking");
        velocityXHash = Animator.StringToHash("velocityX");
        velocityZHash = Animator.StringToHash("velocityZ");
    }

    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}