using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;

    public TMPro.TextMeshProUGUI interactionText;

    Camera cam;
    void Start()
    {
        cam = GetComponent<PlayerController>().GetFollowCam();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Player.Instance.gameObject.transform.position, Player.Instance.gameObject.transform.forward);
        RaycastHit hit;

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            PickupItem pickupItem = hit.collider.GetComponent<PickupItem>();

            if (interactable != null)
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.green);
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                if (pickupItem != null)
                {
                    interactionText.color = pickupItem.GetTextColor();
                }
                successfulHit = true;
            }
        }

        if (!successfulHit)
        {
            interactionText.text = "";
            interactionText.color = Color.white;
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Minigame:
                //minigame
                break;
            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}
