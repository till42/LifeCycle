using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    private static PlayerStats instance;

    public int bell = 0;
    public int bellPrice = 100;
    /// <summary>
    /// has the player upgraded the bell item.
    /// 0: no, 1: 0
    /// </summary>
    public static int BellLevel { get { return instance.bell; } }

    public int gum = 0;
    public int gumPrice = 1000;
    /// <summary>
    /// Has the player upgraded the gum
    /// 0: no, 1:0
    /// </summary>
    public static int GumLevel { get { return instance.gum; } }

    void Awake() {
        //if not yet set, keep this instance
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            //otherwise destroy self
            Destroy(this);
        }
    }

    /// <summary>
    /// Purchase the bell item
    /// </summary>
    /// <returns>price (>0) if succesfull, 0 if not succcesfull</returns>
    public static int PurchaseBell() {
        //not succesfull, if already purchased
        if (BellLevel > 0)
            return 0;

        instance.bell++;
        return instance.bellPrice;
    }

    /// <summary>
    /// Purchase the gum item
    /// </summary>
    /// <returns>price (>0) if succesfull, 0 if not succcesfull</returns>
    public static int PurchaseGum() {
        //not succesfull, if already purchased
        if (GumLevel > 0)
            return 0;

        instance.gum++;
        return instance.gumPrice;
    }
}
