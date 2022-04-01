using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public static class NavMeshAgentExtension {

    /// <summary>
    /// Remember to keep a frame for navMeshAgent data update !
    /// </summary>
    /// <param name="navMeshAgent"></param>
    /// <returns></returns>
    public static bool HasReachDestination(this NavMeshAgent navMeshAgent) {
        if (navMeshAgent.pathPending) return false;
        if (!(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)) return false;
        return !navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f;
    } 
    
}