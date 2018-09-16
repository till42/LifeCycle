using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseGum : MonoBehaviour {

    private Button button;
    private Text buttonText;
    // Use this for initialization
    void Start() {
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<Text>();

        refreshUI();
    }

    private void refreshUI() {
        button.interactable = CanAfford;
        buttonText.text = string.Format("Gum (${0})", PlayerStats.GumPrice);
    }

    private bool CanAfford {
        get {
            if (PlayerStats.GumLevel > 0)
                return false;

            return CurrencyController.Instance.Score > PlayerStats.GumPrice;
        }
    }

    public void OnClick() {
        if (!CanAfford)
            return;
        PlayerStats.PurchaseGum();

        refreshUI();
    }
}
