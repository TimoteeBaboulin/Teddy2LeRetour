using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    public float speed;
    public float Depth;

    public bool _skipFrame;
    
    public GameObject itemUsed;
    public static Action OnInventoryUpdate;
    
    private Vector3 _mousePosition;
    private Vector3 _positionRay;
    private NavMeshAgent _navMeshAgent;
    private NavMeshPath _navMeshPath;

    public List<Item> Inventory = new List<Item>();
    
    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            _mousePosition = Input.mousePosition;
            RaycastHit2D hit;
            Ray ray = mainCamera.ScreenPointToRay(_mousePosition);
            hit = Physics2D.GetRayIntersection(ray);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null) {
                StartCoroutine(InteractWith(interactable));
            }
            else {
                MoveTo(hit.point);
            }
        }
        Rescale();
    }

    private IEnumerator InteractWith(IInteractable interactable) {
        do {
            MoveTo(interactable.Position);
            yield return null;
        } while (!_navMeshAgent.HasReachDestination());
        interactable.Interact(this);
    }

    private void Rescale() {
        float size = 1 - (transform.position.y * Depth) * 0.1f;
        transform.localScale = new Vector3(size, 1, size);
    }

    private void MoveTo(Vector3 destination) {
        _navMeshAgent.speed = speed;
        _navMeshAgent.SetDestination(destination);
    }

    public void GiveItem(Item item) {
        Inventory.Add(item);
        OnInventoryUpdate.Invoke();
    }

    public bool TakeItem(Item item) {
        if (!Inventory.Contains(item)) return false;
        Inventory.Remove(item);
        OnInventoryUpdate.Invoke();
        return true;
    }
    
    public bool NavMeshAgentStopped() {
        return _navMeshAgent.remainingDistance == 0;
    }
    
}