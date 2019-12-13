using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImageHeart : MonoBehaviour
{

    [SerializeField]
    private Texture heartEmpty;

    [SerializeField]
    private Texture heartFull;

    private RawImage currentImage;

    private void Start()
    {
        currentImage = GetComponent<RawImage>();
    }

    public void TakeDamage()
    {
        currentImage.texture = heartEmpty;
        Debug.Log("changing image tacking damage");
    }

    public void Heal()
    {
        currentImage.texture = heartFull;
    }
}
