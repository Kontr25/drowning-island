using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody),typeof(CapsuleCollider))]
public class playerMover : MonoBehaviour
{ 
    [SerializeField] private Rigidbody _rigitbody;
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private ParticleSystem _effect;

    private float _speed;
    private bool attack;

    private void Awake()
    {
        attack = false;
        _speed = 3;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", _rigitbody.velocity.magnitude);
        if (!attack)
        {
            _rigitbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigitbody.velocity.y, _joystick.Vertical * _speed);
        }
        
        if(_rigitbody.velocity.magnitude > 0.3f && !attack)
        {
            _player.transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical) * Time.deltaTime);
        }
        Debug.Log(_rigitbody.velocity.magnitude);
    }

    public void AttackTrue()
    {
        attack = true;
        _rigitbody.velocity = _rigitbody.transform.forward * _speed*2;
        _animator.SetTrigger("Attack");
        _effect.Play();
    }

    public void AttacklFalse()
    {
        _effect.Stop();
        attack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            _rigitbody.velocity = new Vector3(0,0,0);
            _animator.ResetTrigger("Attack");
            _effect.Stop();
        }
    }
}
