using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
public class CameraRotate : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float scrolSensitivity = 0.3f; 
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    private float X, Y;
    private bool Active=false;
    private Compaund compaund;
    void Start()
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
        compaund = new Compaund("http://192.168.0.111/");
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) Active = !Active;
        if (Active)
        {
            //offset.z *= Mathf.Pow(2, -Input.mouseScrollDelta.y * scrolSensitivity);
            offset.z = -compaund.Request("").ReadInt16()/10;
            offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, limit);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
            transform.position = transform.localRotation * offset + target.position;
        }
    }
    public class Compaund
    {
        private string URI;
        private BinaryReader reder; public BinaryReader DATA { get { return reder; } }
        public Compaund(string uRI)
        {
            URI = uRI;
        }
        public BinaryReader Request(string data)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(URI + data) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (reder != null) reder.Close();
                reder = new BinaryReader(response.GetResponseStream());
                reder.ReadBytes(23);
                return DATA;
            }
            catch
            {
                reder = null;
                return null;
            }
        }
    }
}
