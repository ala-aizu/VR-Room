using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSocketInteractor))]
public class SocketLimitCounter : MonoBehaviour
{
    private XRSocketInteractor m_Socket;
    
    public int currentSnaps = 0;
    
    public int maxSnaps = 3;

    private void Awake()
    {
        m_Socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        m_Socket.selectEntered.AddListener(OnObjectSnapped);
    }

    private void OnDisable()
    {
        m_Socket.selectEntered.RemoveListener(OnObjectSnapped);
    }

    private void OnObjectSnapped(SelectEnterEventArgs args)
    {
        currentSnaps++;
        Debug.Log($"Object snapped! Attempt {currentSnaps} of {maxSnaps}.");

        if (currentSnaps >= maxSnaps)
        {
            Debug.Log("Socket limit reached. Deactivating socket.");
            m_Socket.socketActive = false; 
        }
    }
}