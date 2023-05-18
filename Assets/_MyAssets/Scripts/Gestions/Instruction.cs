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
        return "Le but du jeu est de survivre aux vagues incessentes d'ennemies. " +
            "Au fur et à mesure que vous avancez dans le temps. Différents types " +
            "d'ennemies feront leur apparition. Rendant de ce fait le jeu beaucoup " +
            "plus difficile." + "\r\n" + "\r\n" +
            "Déplacement-A et D " + "\r\n" + 
            "Espace.  attack corp à corp" + "\r\n" +
            "E. attack distance" + "\r\n";
    }
}
