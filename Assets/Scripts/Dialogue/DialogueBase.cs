using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueBase")]
public class DialogueBase : ScriptableObject
{
    #region DialogueBase
    [SerializeField] private string[] messages;
    public string[] Messages { get => messages; }
    #endregion
}
