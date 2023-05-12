using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtInstruction = default;



    void Start()
    {
        _txtInstruction.text = InstructionDepart();
    }

    public string InstructionDepart()
    {
        return "*** Bonjours" + "\r\n";
    }
}
