using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    #region Declarations
    private bool hasBeenTriggered;
    private bool requirementsMet;
    private bool isOpen;
    [SerializeField] private bool isLastElevator;
    [SerializeField] private KeyCode confirmationKey;
    [SerializeField] private KeyCode cancelationKey;
    [SerializeField] private GameObject confirmationScreen;
    [SerializeField] private GameObject requirementScreen;
    private Animator animator;
    [SerializeField] private int requirementsAmount;
    [SerializeField] private int currentRequirements;
    [SerializeField] private GameObject rangeCollider;
    private UIManager uiManager;
    #endregion

    #region MonoBehaviour
    private void Start()
    {
        requirementsMet = false;
        isOpen = false;
        animator = GetComponent<Animator>();
        confirmationScreen.SetActive(false);
        requirementScreen.SetActive(false);
        currentRequirements = 0;
        uiManager = UIManager.instance;
    }
    private void Update()
    {
        RequirementsAchieved();
        ConfirmationButtons();
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
                animator.SetBool("DoorOpen", isOpen);
                confirmationScreen.SetActive(true);
            }
            else
            {
                isOpen = false;
                animator.SetBool("DoorOpen", isOpen);
                hasBeenTriggered = false;
                StartCoroutine(RequirementScreenTime());
            }
        }
    }
    public void ConfirmationButtons()
    {
        if (Input.GetKeyDown(confirmationKey) && isOpen == true)
        {
            print("1");
            confirmationScreen.SetActive(false);
            rangeCollider.SetActive(false);
            isOpen = false;
            animator.SetBool("DoorOpen", isOpen);
            if(isLastElevator)
            {
                uiManager.DemoScreen();
            }
            else
            {
                uiManager.NextScene();
            }
        }
        else if (Input.GetKeyDown(cancelationKey) && isOpen == true)
        {
            confirmationScreen.SetActive(false);
            isOpen = false;
            animator.SetBool("DoorOpen", isOpen);
            hasBeenTriggered = false;
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