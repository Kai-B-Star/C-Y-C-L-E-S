using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    #region Declarations
    private bool hasBeenTriggered;
    private bool requirementsMet;
    private bool isOpen;
    [SerializeField] private KeyCode confirmationKey;
    [SerializeField] private KeyCode cancelationKey;
    [SerializeField] private GameObject confirmationScreen;
    [SerializeField] private GameObject requirementScreen;
    private Animator animator;
    [SerializeField] private PlayerStandard player;
    [SerializeField] private int requirementsAmount;
    [SerializeField] private int currentRequirements;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        requirementsMet = false;
        isOpen = false;
        animator = GetComponent<Animator>();
        animator.SetBool("DoorOpen", isOpen);
        confirmationScreen.SetActive(false);
        requirementScreen.SetActive(false);
        currentRequirements = 0;
    }
    private void Update()
    {
        RequirementsAchieved();
    }
    #endregion

    #region Elevator
    public void ElevatorRequire()
    {
        if (!hasBeenTriggered)
        {
            hasBeenTriggered = true;
            if(requirementsMet == true)
            {
                isOpen = true;
                confirmationScreen.SetActive(true);
                if(Input.GetKeyDown(confirmationKey))      //keys not working (prints 1 and 2 not running)
                {
                    print("1");
                    confirmationScreen.SetActive(false);
                    //move player down
                }
                else if(Input.GetKeyDown(cancelationKey))
                {
                    print("2");
                    confirmationScreen.SetActive(false);
                    isOpen = false;
                    hasBeenTriggered = false;
                }
            }
            else
            {
                isOpen = false;
                hasBeenTriggered = false;
                StartCoroutine(RequirementScreenTime());
            }
        }
    }
    #endregion

    #region RequirementCount
    public void AddRequirement()
    {
        currentRequirements++;
    }
    private void RequirementsAchieved()
    {
        if(currentRequirements == requirementsAmount)
        {
            requirementsMet = true;
        }    
    }
    private IEnumerator RequirementScreenTime()
    {
        requirementScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        requirementScreen.SetActive(false);
    }
    #endregion
}
//movement (cutscene maybe?)
//animation to open and close door
