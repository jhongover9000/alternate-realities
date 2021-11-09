// ClickToMove.cs
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    int isWalkingHash;
    int velocityXHash;
    int velocityZHash;

    RaycastHit hitInfo = new RaycastHit();

    public bool allowClickToMove = true;

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

        if (!allowClickToMove)
        {
            //animator.SetBool("isWalking", false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                agent.SetDestination(hitInfo.point);
                

            }
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
}