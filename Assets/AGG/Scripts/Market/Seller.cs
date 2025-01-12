using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Seller : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    private CharacterController _characterController;
    private bool _canBuy = true;
    private float time = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamDisable.gameObject.SetActive(true);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1 << 8);
            _characterController = other.GetComponent<CharacterController>();
            //_characterController.canMove = false;
            UI.SetActive(true);
            _canBuy = false;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForABit());
    }
    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(time);
        _canBuy = true;
    }

    public void ExitStore()
    {
        //_characterController.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= ~(1 << 8);
        UI.SetActive(false);
    }
}
