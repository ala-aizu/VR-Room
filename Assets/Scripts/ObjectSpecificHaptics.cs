using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class ObjectSpecificHaptics : MonoBehaviour
{
    // [Header("Haptic Settings")]
    // [Range(0f, 1f)]
    // [Tooltip("Haptic intensity from 0 (none) to 1 (max force).")]
    public float hapticIntensity = 0.5f;
    
    // [Tooltip("Duration of the haptic feedback in seconds.")]
    public float hapticDuration = 0.1f;

    // [Header("Event Triggers")]
    public bool triggerOnSelect = true;
    public bool triggerOnHover = false;

    private XRBaseInteractable interactable;

    private void Awake()
    {
        // Get the Interactable component (Grab, Simple, etc.) attached to this object
        interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        if (triggerOnSelect)
            interactable.selectEntered.AddListener(OnInteractionEntered);
            
        if (triggerOnHover)
            interactable.hoverEntered.AddListener(OnInteractionEntered);
    }

    private void OnDisable()
    {
        if (triggerOnSelect)
            interactable.selectEntered.RemoveListener(OnInteractionEntered);
            
        if (triggerOnHover)
            interactable.hoverEntered.RemoveListener(OnInteractionEntered);
    }

    // This method handles both Hover and Select events
    private void OnInteractionEntered(BaseInteractionEventArgs args)
    {
        // Check if the interactor is a controller (ignores sockets or gaze interactors)
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            // Send the specific impulse values to the controller
            controllerInteractor.SendHapticImpulse(hapticIntensity, hapticDuration);
        }
    }
}