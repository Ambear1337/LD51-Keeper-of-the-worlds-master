using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Interactable
{
    public GameObject activateCutscene;
    public GameManager gameManager;

    Animator animator;

    public int world;
    public bool cutscenePortal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void Interact()
    {
        if (cutscenePortal)
        {
            activateCutscene.SetActive(true);
            gameManager.EndGame();
        }
        else
        {
            WorldHandler.Instance.ChangeWorld(world);
        }
    }

    public override string GetDescription()
    {
        if (cutscenePortal)
        {
            return "Return home.";
        }
        else
        {
            switch (world)
            {
                case (0):
                    return "Go to forest.";
                case (1):
                    return "Go to lava.";
                case (2):
                    return "Go to underwater.";
                case (3):
                    return "Go to slime.";
                case (4):
                    return "Go to ice.";
                default:
                    return "";
            };
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (WorldHandler.Instance.GetCurrentWorldIndex() != world)
        {
            if (other.tag == "Player")
            {
                animator.SetBool("IsActive", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("IsActive", false);
        }
    }
}
