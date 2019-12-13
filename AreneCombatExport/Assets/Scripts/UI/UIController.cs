using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void AfficherCoucou()
    {
        text.text = "coucou";
    }
}
