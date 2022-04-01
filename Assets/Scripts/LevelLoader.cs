using System;
using UnityEngine;
using UnityEngine.AI;

public class LevelLoader : MonoBehaviour
{
    public static Action OnLevelChange;
    private void Awake()
    {
        OnLevelChange += Bake;
    }

    private void Bake()
    {
        NavMeshSurface2d navMeshSurface2d = GetComponent<NavMeshSurface2d>();
        navMeshSurface2d.UpdateNavMesh(navMeshSurface2d.navMeshData);
    }
}