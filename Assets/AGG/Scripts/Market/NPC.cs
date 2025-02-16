using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    //public GameObject UI;
    public GameObject Dialog;
    private CharacterController _characterController;
    private bool _canBuy = true;
    private float time = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamDisable.gameObject.SetActive(true);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1 << 8);
            _characterController = other.GetComponent<CharacterController>();
            _characterController.enabled = false;
            //UI.SetActive(true);
            Dialog.SetActive(true);
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
        _characterController.enabled = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= ~(1 << 8);
        //UI.SetActive(false);
        Dialog.SetActive(false);
    }
}
