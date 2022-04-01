using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Camera mainCamera;

    public float speed;
    public float depth;

    public bool _skipFrame;

    public GameObject inventory;
    public GameObject itemUsed;
    
    private Vector3 _mousePosition;
    private Vector3 _positionRay;
    private NavMeshAgent _navMeshAgent;
    private NavMeshPath _navMeshPath;

    private float _size;
    // Start is called before the first frame update
    void Start()
    {
        _mousePosition = new Vector3(0,0,0);
        
        //Needed to avoid NavMeshAgent rotating the player
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")
            && !GameObject.Find("Content").GetComponent<InventoryCaseParent>().IsCaseDragged())
        {
            _mousePosition = Input.mousePosition;
            
            RaycastHit2D hit;
            Ray ray = mainCamera.ScreenPointToRay(_mousePosition);
            hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null)
                _positionRay = hit.point;
            else
                Debug.Log("ray hit null");
            
            NavMeshHit navHit;
            
            NavMesh.SamplePosition(_positionRay, out navHit, 20, -1);
            _navMeshAgent.SetDestination(navHit.position);
        }

        
        _size = 1 - (transform.position.y * depth) * 0.1f;
        Vector3 scale = new Vector3(_size, _size, 0);
        transform.localScale = scale;
                    
        
    }

    public bool NavMeshAgentStopped()
    {
        return _navMeshAgent.remainingDistance == 0;
    }
    
}
