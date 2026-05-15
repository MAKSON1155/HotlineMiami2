using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public List<RaycastHit2D> Raycast(Vector2 direction, List<RaycastHit2D> hits,float distance)
    {
        if (direction != Vector2.zero) 
        {
            hits.Add(Physics2D.Raycast(transform.position, direction, distance));          
            return hits;
        }

        return hits;
    }
}
