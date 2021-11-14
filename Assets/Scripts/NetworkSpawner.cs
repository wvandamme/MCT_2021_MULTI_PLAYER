using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkSpawner : NetworkBehaviour
{

    public NetworkObject Prefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefabServerRpc(transform.position);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void SpawnPrefabServerRpc(Vector3 position)
    {
        StartCoroutine(SpawnHelper(position));
    }

    IEnumerator SpawnHelper(Vector3 position)
    {
        NetworkObject obj = Instantiate(Prefab, position, Quaternion.identity);
        obj.Spawn();
        yield return new WaitForSeconds(2);
        obj.Despawn();
    }
}
