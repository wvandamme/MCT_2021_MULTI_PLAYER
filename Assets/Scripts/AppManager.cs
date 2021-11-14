using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AppManager : MonoBehaviour
{

    public Canvas NetworkCanvas;
    public Canvas StatusCanvas;

    private StatusManager StatusManager;
    private uint Connections;

    private void Start()
    {
        Connections = 0;
        NetworkCanvas.gameObject.SetActive(true);
        StatusCanvas.gameObject.SetActive(false);
        StatusManager = StatusCanvas.GetComponent<StatusManager>();
    }

    private void OnEnable()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnClientConnected(ulong obj)
    {
        ++Connections;
    }

    private void OnClientDisconnected(ulong obj)
    {
        --Connections;
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkCanvas.gameObject.SetActive(false);
        StatusCanvas.gameObject.SetActive(true);
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        NetworkCanvas.gameObject.SetActive(false);
        StatusCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        StatusManager.SetServer(NetworkManager.Singleton.IsServer);
        StatusManager.SetClient(NetworkManager.Singleton.IsClient);
        StatusManager.SetConnections(Connections);
    }

}


