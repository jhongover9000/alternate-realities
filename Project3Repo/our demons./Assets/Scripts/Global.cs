using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance { get; private set; }

    // check if cut ingredients have been added
    public bool ingredientsAdded;

    // check if both shakers have been used
    public bool razzleDazzled;

    // check if pot has been stirred
    public bool isStirred;

    // check if pot is cooking/has been cooked (turning dial activates trigger)
    public bool isCooking;
    public bool isCooked;

    // check if pot has been placed on molding table
    public bool isPlaced;

    // check if bomb has been assembled
    public bool isAssembled;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }

}
