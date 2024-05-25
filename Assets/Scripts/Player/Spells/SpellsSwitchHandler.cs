using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsSwitchHandler : MonoBehaviour
{
    SpellCastHandler spellCastHandler;

    void Awake()
    {
        spellCastHandler = GetComponent<SpellCastHandler>();
    }

    void Update()
    {
        HandleScrollWheelInput();
    }

    void HandleScrollWheelInput()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll == 0 || spellCastHandler.KnownELementalTypes.Count <= 1) { return; }

        if (scroll > 0)
        {
            spellCastHandler.SwitchToNextElementType();
        }
        else
        {
            spellCastHandler.SwitchToPreviousElementType();
        }
    }
}
