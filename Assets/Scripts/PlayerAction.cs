using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action
{
    FreeRoam,
    Climb
}

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private PlayerInteract playerInteract;
    [SerializeField]
    private GameObject climbDown;

    private Action playerAction;

    private Vector3 oldPosition;

    public void ClimbUp()
    {
        playerAction = Action.Climb;
        oldPosition = transform.position;
        climbDown.SetActive(true);
        transform.position = playerInteract.GetBaseStack().GetPeakItem().position;
    }

    public void ClimbDown()
    {
        playerAction = Action.FreeRoam;
        transform.position = oldPosition;
        climbDown.SetActive(false);
    }

    public Action GetPlayerAction()
    {
        return playerAction;
    }
}
