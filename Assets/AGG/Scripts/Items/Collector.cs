using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using static GameManager;

public class Collector : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll))
        {
            icoll.OnCollected();
            if(icoll is Orb)
            {
                _animator.SetTrigger("Collected");
                _animator.SetLayerWeight(1, 1);
                Camera.main.GetComponent<CinemachineBrain>().enabled = true;
                GetComponent<PlayerController>().canMove = false;
            }           
        }
    }
}
