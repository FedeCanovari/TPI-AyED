using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {

        private Dictionary<string, int> ContarOcurrencias(List<string> datos)
        {
            Dictionary<string, int> ocurrencias = new Dictionary<string, int>();

            foreach (string texto in datos)
            {
                if (ocurrencias.ContainsKey(texto))
                {
                    ocurrencias[texto] = ocurrencias[texto] + 1;
                }
                else
                {
                    ocurrencias.Add(texto, 1);
                }
            }

            return ocurrencias;
        }

        public String Consulta1(List<string> datos)
        {
            string resutl = "Implementar";
            return resutl;
        }


        public String Consulta2(List<string> datos)
        {
            string result = "Implementar";

            return result;
        }



        public String Consulta3(List<string> datos)
        {
            string result = "Implementar";

            return result;
        }


        public void BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected)
        {
            Dictionary<string, int> ocurrencias = ContarOcurrencias(datos);

            List<Dato> listaDatos = new List<Dato>();

            foreach (KeyValuePair<string, int> item in ocurrencias)
            {
                Dato nuevoDato = new Dato(item.Value, item.Key);

                listaDatos.Add(nuevoDato);
            }

            SelectionSort(listaDatos);

            for (int i = 0; i < cantidad && i < listaDatos.Count; i++)
            {
                collected.Add(listaDatos[i]);
            }

            MessageBox.Show("Lista ordenada");
        }

        private void SelectionSort(List<Dato> lista)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                int posicionMayor = i;

                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[j].ocurrencia > lista[posicionMayor].ocurrencia)
                    {
                        posicionMayor = j;
                    }
                }

                Dato auxiliar = lista[i];
                lista[i] = lista[posicionMayor];
                lista[posicionMayor] = auxiliar;
            }
        }


        public void BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
            //Implementar
        }


    }

}