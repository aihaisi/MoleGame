using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public Sprite normalCursor;
    public Sprite clickCursor;
    public UnityEngine.UI.Image hammerImage;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            hammerImage.sprite = clickCursor;
        }
        else
        {
            hammerImage.sprite = normalCursor;
        }
        hammerImage.rectTransform.position = Input.mousePosition;
    }
}
