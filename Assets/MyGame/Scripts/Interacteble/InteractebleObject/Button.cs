using UnityEngine;

public class Button : Interacteble
{
    [SerializeField] private Animator _animator;
    private bool _isactive = true;

    private int _shaderOff;
    private int _shaderOn;

    private void Start()
    {
        _shaderOff = Animator.StringToHash("Off");
        _shaderOn = Animator.StringToHash("On");
    }

    protected override void Interact()
    {
        _isactive = !_isactive;

        if (_isactive)
        {
            _animator.SetTrigger(_shaderOn);
        }
        else
        {
            _animator.SetTrigger(_shaderOff);
        }
    }
}
