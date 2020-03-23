using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamerabehaviour : MonoBehaviour
{
    float mousesensitivity = 100f;
    public Transform playertransform;
    float Xrotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        playertransform.Rotate(Vector3.up * mouseX);
    }

    public void crouch()
    {
        this.transform.localPosition = new Vector3(0f, 0.1f, 0f);
    }

    public void getUP()
    {
        this.transform.localPosition = new Vector3(0f, 0.3f, 0f);
    }
}
