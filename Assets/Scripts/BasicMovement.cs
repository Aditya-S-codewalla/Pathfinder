using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    //[SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 5f;

    private List<Node> path = new List<Node>();

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                switch (UIManager.Instance.pathSelected)
                {
                    case UIManager.PathStates.BFS:
                        path = Pathfinder.Instance.FindPathWithBFS(transform.position, hit.point);
                        break;
                    case UIManager.PathStates.DFS:
                        path = Pathfinder.Instance.FindPathWithDFS(transform.position, hit.point);
                        break;
                    case UIManager.PathStates.Astar:
                        path = Pathfinder.Instance.FindPathWithAStarHeap(transform.position, hit.point);
                        break;
                    default:
                        path = Pathfinder.Instance.FindPathWithAStarHeap(transform.position, hit.point);
                        break;
                }
                //path = Pathfinder.Instance.FindPathWithAStarHeap(transform.position, hit.point);
            }
            else
            {
                //if player clicked outside navmesh
                path.Clear();
            }
            
            if (path != null)
            {
                StopAllCoroutines();
                StartCoroutine(TraversePath(path));
            }
        }
    }

    private IEnumerator TraversePath(List<Node> path)
    {
        foreach(Node node in path)
        {
            while (Vector3.Distance(transform.position, node.worldPosition) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, node.worldPosition, moveSpeed * Time.deltaTime);

                //Vector3 direction = (node.worldPosition - transform.position);
                //Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
