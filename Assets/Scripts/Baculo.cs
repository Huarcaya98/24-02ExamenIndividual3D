using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baculo : Arma
{
    protected override void AliniearArma()
    {
        // Alinear la escopeta con la c�mara
        transform.position = camara.position + camara.TransformDirection(offset);

        // Rotar la escopeta con la c�mara, pero suavemente
        transform.rotation = Quaternion.Lerp(transform.rotation, camara.rotation, Time.deltaTime * 10f);
    }


}
