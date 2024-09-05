using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    [SerializeField] private ScriptableColor _mainColor;
    [SerializeField] private ScriptableColor _secondaryColor;

    private void Awake()
    {
        instance = this;
    }

    public ScriptableColor GetMainColor()
    {
        return _mainColor;
    }

    public ScriptableColor SwapColor(ScriptableColor currentColor)
    {
        return currentColor == _mainColor ? _secondaryColor : _mainColor;
    }
}
