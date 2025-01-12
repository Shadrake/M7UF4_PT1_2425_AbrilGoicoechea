using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("playerPosX"))
        {
            Load();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SaveZone"))
        {
            Save();
        }
    }

    public void Load()
    {
        GetComponent<CharacterController>().enabled = false;

        Vector3 loadedPosition = new Vector3(
            PlayerPrefs.GetFloat("playerPosX"),
            PlayerPrefs.GetFloat("playerPosY"),
            PlayerPrefs.GetFloat("playerPosZ")
        );
        Quaternion loadedRotation = Quaternion.Euler(new Vector3(
            PlayerPrefs.GetFloat("playerRotX"),
            PlayerPrefs.GetFloat("playerRotY"),
            PlayerPrefs.GetFloat("playerRotZ")
        ));

        transform.position = loadedPosition;
        transform.rotation = loadedRotation;

        StartCoroutine(WaitNextFrame());
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("playerPosX", transform.position.x);
        PlayerPrefs.SetFloat("playerPosY", transform.position.y);
        PlayerPrefs.SetFloat("playerPosZ", transform.position.z);

        PlayerPrefs.SetFloat("playerRotX", transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("playerRotY", transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("playerRotZ", transform.rotation.eulerAngles.z);

        Debug.Log("Posición del jugador guardada");
    }

    private IEnumerator WaitNextFrame()
    {
        yield return new WaitForEndOfFrame();
        GetComponent<CharacterController>().enabled = true;
    }
}
