using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Toggle IsClient;
    public Toggle IsServer;
    public Text Connections;

    public void SetServer(bool server_)
    {
        IsServer.isOn = server_;
        Connections.gameObject.SetActive(server_);
    }

    public void SetClient(bool client_)
    {
        IsClient.isOn = client_;
    }

    public void SetConnections(uint connections_)
    {
        Connections.text = connections_.ToString();
    }

}
