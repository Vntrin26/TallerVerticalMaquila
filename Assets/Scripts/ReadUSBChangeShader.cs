using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ReadUSBChangeShader : MonoBehaviour {

    private Renderer holoRenderer;

    SerialPort sp; //whatever COM arduino uses

    //[SerializeField]
    //private Shader shaders;

    Shader red;
    Shader yellow;

    private void Awake()
    {
        try
        {
            sp = new SerialPort("COM3", 9600);
        }
        catch (System.Exception)
        {

        }
    }

    void Start()
    {
        holoRenderer = GetComponent<Renderer>();
        red = Shader.Find("Custom/red");
        yellow = Shader.Find("Custom/yellow");

        try
        {
            sp.Open();
            sp.ReadTimeout = 1;
        }
        catch (System.Exception e)
        {
            Debug.Log("No se inicio la conexión: "+e.ToString());

        }

    }

    int line;

    // Update is called once per frame
    void Update()
    {
        
        if (sp.IsOpen)
        {
            try
            {
                // DO WHATEVER THE *YOU WANT
                line = sp.ReadByte();//sp.ReadChar();
                if (((int)'1').Equals(line))
                {
                    //rojo
                    holoRenderer.material.shader = red;
                    holoRenderer.material.SetColor("_Color", Color.red);

                }
                if (((int)'0').Equals(line))
                {
                    //amarillo
                    holoRenderer.material.shader = yellow;
                    holoRenderer.material.SetColor("_Color", Color.yellow);

                }
                //Shader.
            }
            catch (System.Exception)
            {

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Do something
                Debug.Log("lee alterno");
            }
        }
    }




}

