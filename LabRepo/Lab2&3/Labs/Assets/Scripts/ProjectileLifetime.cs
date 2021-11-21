using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    public float lifetime = 3.0f;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
        }
}
