using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COLORCHANGER : MonoBehaviour
{
    public Renderer[] objRenderer;
    public Texture[] textures;
    private int objCurrentTextureIndex = 0;
    public Button leftbtn;
    public Button rightbtn;

    private void Start()
    {
        if (objRenderer != null && textures.Length > 0)
        {
            objRenderer[1].material.mainTexture = textures[objCurrentTextureIndex];
        }
        leftbtn.onClick.AddListener(ChangeTextureLeft);
        rightbtn.onClick.AddListener(ChangeTextureRight);
    }
    void ChangeTextureLeft()
    {
        objCurrentTextureIndex++;
        if (objCurrentTextureIndex >= textures.Length)
        {
            objCurrentTextureIndex = -1;
        }
        UpdateTexture();
    }
    void ChangeTextureRight()
    {
        objCurrentTextureIndex++;
        if (objCurrentTextureIndex >= textures.Length)
        {
            objCurrentTextureIndex = 0;
        }
        UpdateTexture();
    }
    void UpdateTexture()
    {
        if(objRenderer != null && textures.Length > 0)
        {
            objRenderer[1].material.mainTexture = textures[objCurrentTextureIndex];
        }
    }

    }
