using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    Vector2 movimiento;
    float angulo;
    public float velocidadRotacion;

    public GameObject Ovulo;

    public GameObject[] Objetivos_1;
    public GameObject[] Objetivos_2;
    public GameObject[] Objetivos_3;
    public GameObject[] Objetivos_4;
    public GameObject[] Objetivos_5;
    private GameObject Objetivo_Auxiliar;

    public GameObject cola;

    public GameObject drop;
    public string nombre_drop;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void setObjetivos(GameObject a1, GameObject a2, GameObject a3, GameObject a4, GameObject a5, 
                            GameObject ov, GameObject a1_2, GameObject a1_3, GameObject a2_2, GameObject a2_3,
                            GameObject a3_2, GameObject a3_3, GameObject a4_2, GameObject a4_3, GameObject a5_2,
                            GameObject a5_3, GameObject drop, string name_drop, GameObject cola)
    {
        Objetivos_1[0] = a1;
        Objetivos_1[1] = a1_2;
        Objetivos_1[2] = a1_3;

        Objetivos_2[0] = a2;
        Objetivos_2[1] = a2_2;
        Objetivos_2[2] = a2_3;

        Objetivos_3[0] = a3;
        Objetivos_3[1] = a3_2;
        Objetivos_3[2] = a3_3;

        Objetivos_4[0] = a4;
        Objetivos_4[1] = a4_2;
        Objetivos_4[2] = a4_3;

        Objetivos_5[0] = a5;
        Objetivos_5[1] = a5_2;
        Objetivos_5[2] = a5_3;

        this.drop = drop;
        nombre_drop = name_drop;

        this.cola = cola;

        switch (select_op())
        {
            case 0:
                Objetivo_Auxiliar = Objetivos_1[0];
                break;
            case 1:
                Objetivo_Auxiliar = Objetivos_1[1];
                break;
            case 2:
                Objetivo_Auxiliar = Objetivos_1[2];
                break;
        }
        Ovulo = ov;
    }
    // Update is called once per frame
    void Update()
    {
        Movimiento(Objetivo_Auxiliar);
        cambiar_angulo(Objetivo_Auxiliar);

        if (distancia_objetivo(Objetivo_Auxiliar) < 10)
        {
            Cambio_de_objetivo(Objetivo_Auxiliar);
        }

        cola.transform.position = transform.position;
        cola.transform.rotation = transform.rotation;

    }

    private float distancia_objetivo(GameObject _Objetivo)
    {
        float dist;
        dist = Vector3.Distance(transform.position, _Objetivo.transform.position);
        return dist;
    }

    private void Movimiento(GameObject Objetivo_)
    {
        //transform.position = Vector3.MoveTowards(transform.position, Objetivo_.transform.position, moveSpeed * Time.deltaTime);
        transform.position += (Objetivo_.transform.position- transform.position).normalized* moveSpeed * Time.deltaTime;
    }

    private void cambiar_angulo(GameObject Objetivo_)
    {
        float anguloR = Mathf.Atan2(transform.position.y - Objetivo_.transform.position.y, transform.position.x - Objetivo_.transform.position.x);
        float anguloG = (180 / Mathf.PI) * anguloR - 90;

        transform.rotation = Quaternion.Euler(0, 0, anguloG - 180);
    }

    private void Cambio_de_objetivo(GameObject _Actual)
    {
        if (_Actual == Objetivos_1[0] || _Actual == Objetivos_1[1] || _Actual == Objetivos_1[2])
        {
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivos_2[0];
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivos_2[1];
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivos_2[2];
                    break;
            }
        }
        else if (_Actual == Objetivos_2[0] || _Actual == Objetivos_2[1] || _Actual == Objetivos_2[2])
        {
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivos_3[0];
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivos_3[1];
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivos_3[2];
                    break;
            }
        }
        else if (_Actual == Objetivos_3[0] || _Actual == Objetivos_3[1] || _Actual == Objetivos_3[2])
        {
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivos_4[0];
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivos_4[1];
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivos_4[2];
                    break;
            }
        }
        else if (_Actual == Objetivos_4[0] || _Actual == Objetivos_4[1] || _Actual == Objetivos_4[2])
        {
            switch (select_op())
            {
                case 0:
                    Objetivo_Auxiliar = Objetivos_5[0];
                    break;
                case 1:
                    Objetivo_Auxiliar = Objetivos_5[1];
                    break;
                case 2:
                    Objetivo_Auxiliar = Objetivos_5[2];
                    break;
            }
        }
        else if (_Actual == Objetivos_5[0] || _Actual == Objetivos_5[1] || _Actual == Objetivos_5[2])
        {
            Objetivo_Auxiliar = Ovulo;
        }
    }

    private void OnCollisionEnter2D(Collision2D uterocolision)
    {
        if (uterocolision.collider.CompareTag("UterPoint"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D uterocolisiondos)
    {
        if (uterocolisiondos.CompareTag("UterPoint"))
        {
            Destroy(this.gameObject);
        }
    }

    private int select_op()
    {
        int op = Random.Range(0, 3);
        return op;
    }

    public void Droping()
    {
        GameObject Drop_clon = Instantiate(drop, transform.position, Quaternion.identity);

    }
}

