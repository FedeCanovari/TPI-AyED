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
        public class MaxHeap
        {
            private List<Dato> elementos = new List<Dato>();

            public int Count
            {
                get { return elementos.Count; }
            }

            public void Insertar(Dato dato)
            {
                elementos.Add(dato);

                HeapifyUp(elementos.Count - 1);
            }

            public Dato ExtraerMax()
            {
                if (elementos.Count == 0)
                {
                    return null;
                }

                Dato maximo = elementos[0];

                elementos[0] = elementos[elementos.Count - 1];

                elementos.RemoveAt(elementos.Count - 1);

                HeapifyDown(0);

                return maximo;
            }

            private void HeapifyUp(int indice)
            {
                while (indice > 0)
                {
                    int padre = (indice - 1) / 2;

                    if (elementos[indice].ocurrencia > elementos[padre].ocurrencia)
                    {
                        Dato auxiliar = elementos[indice];
                        elementos[indice] = elementos[padre];
                        elementos[padre] = auxiliar;

                        indice = padre;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void HeapifyDown(int indice)
            {
                while (true)
                {
                    int hijoIzquierdo = 2 * indice + 1;
                    int hijoDerecho = 2 * indice + 2;

                    int mayor = indice;

                    if (hijoIzquierdo < elementos.Count &&
                        elementos[hijoIzquierdo].ocurrencia > elementos[mayor].ocurrencia)
                    {
                        mayor = hijoIzquierdo;
                    }

                    if (hijoDerecho < elementos.Count &&
                        elementos[hijoDerecho].ocurrencia > elementos[mayor].ocurrencia)
                    {
                        mayor = hijoDerecho;
                    }

                    if (mayor != indice)
                    {
                        Dato auxiliar = elementos[indice];
                        elementos[indice] = elementos[mayor];
                        elementos[mayor] = auxiliar;

                        indice = mayor;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
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

            MergeSort(listaDatos, 0, listaDatos.Count - 1);

            for (int i = 0; i < cantidad && i < listaDatos.Count; i++)
            {
                collected.Add(listaDatos[i]);
            }


        }


        // Implementación inicial utilizada antes de migrar a MergeSort

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


        private void MergeSort(List<Dato> lista, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;

                MergeSort(lista, izquierda, medio);

                MergeSort(lista, medio + 1, derecha);

                Merge(lista, izquierda, medio, derecha);
            }
        }

        private void Merge(List<Dato> lista, int izquierda, int medio, int derecha)
        {
            List<Dato> temporal = new List<Dato>();

            int i = izquierda;
            int j = medio + 1;

            while (i <= medio && j <= derecha)
            {
                if (lista[i].ocurrencia >= lista[j].ocurrencia)
                {
                    temporal.Add(lista[i]);
                    i++;
                }
                else
                {
                    temporal.Add(lista[j]);
                    j++;
                }
            }

            while (i <= medio)
            {
                temporal.Add(lista[i]);
                i++;
            }

            while (j <= derecha)
            {
                temporal.Add(lista[j]);
                j++;
            }

            for (int k = 0; k < temporal.Count; k++)
            {
                lista[izquierda + k] = temporal[k];
            }
        }



        public void BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
        {
            Dictionary<string, int> ocurrencias = ContarOcurrencias(datos);

            MaxHeap heap = new MaxHeap();

            foreach (KeyValuePair<string, int> item in ocurrencias)
            {
                Dato nuevoDato = new Dato(item.Value, item.Key);

                heap.Insertar(nuevoDato);
            }

            for (int i = 0; i < cantidad && heap.Count > 0; i++)
            {
                Dato mayor = heap.ExtraerMax();

                collected.Add(mayor);
            }
        }




    }

}