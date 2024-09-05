using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class ColorState : MonoBehaviour
{
    [SerializeField] private ScriptableColor _overrideStartColor;
    [Space]
    [SerializeField] private ScriptableColor _currentColor;
    public ScriptableColor CurrentColor { get => _currentColor; }
    private SpriteRenderer[] _spriteRendrerArray;

    private void Start()
    {
        _currentColor = _overrideStartColor ? _overrideStartColor : ColorManager.instance.GetMainColor();

        _spriteRendrerArray = GetComponentsInChildren<SpriteRenderer>();
        SetSpriteRenderersColor();
    }

    public bool IsSameColor(ScriptableColor colorToCkeck)
    {
        return _currentColor == colorToCkeck;
    }

    //! Call by PlayerInput
    private void OnSwapColor(InputValue value)
    {
        if (value.Get<float>() > .5f)
        {
            print("SwapColor");
            _currentColor = ColorManager.instance.SwapColor(_currentColor);
            SetSpriteRenderersColor();
        }
    }

    private void SetSpriteRenderersColor()
    {
        if (!_currentColor) return;
        for (int i = 0; i < _spriteRendrerArray.Length; i++)
        {
            _spriteRendrerArray[i].color = _currentColor.color;
        }
    }
}
