using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueTree")]
public class DialogueTree : ScriptableObject
{
    [SerializeField] private string[] messages;                               //keeps dialogue options stored

    public string[] Messages { get => messages; }
}
