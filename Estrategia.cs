using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using tp1;

namespace tpfinal
{
    public class Estrategia
    {
        public class MaxHeap
        {
            private Dato[] elementos;
            private int cantidad;

            public MaxHeap(int tamanio)
            {
                elementos = new Dato[tamanio];
                cantidad = 0;
            }

            public int Count
            {
                get { return cantidad; }
            }

            public void Insertar(Dato dato)
            {
                elementos[cantidad] = dato;

                SubirElemento(cantidad);

                cantidad++;
            }

            public Dato ExtraerMax()
            {
                if (cantidad == 0)
                {
                    return null;
                }

                Dato maximo = elementos[0];

                elementos[0] = elementos[cantidad - 1];

                cantidad--;

                BajarElemento(0);

                return maximo;
            }

            private void SubirElemento(int indice)
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

            private void BajarElemento(int indice)
            {
                while (true)
                {
                    int hijoIzquierdo = 2 * indice + 1;
                    int hijoDerecho = 2 * indice + 2;

                    int mayor = indice;

                    if (hijoIzquierdo < cantidad &&
                        elementos[hijoIzquierdo].ocurrencia > elementos[mayor].ocurrencia)
                    {
                        mayor = hijoIzquierdo;
                    }

                    if (hijoDerecho < cantidad &&
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

            public Dato[] ObtenerElementos()
            {
                return elementos;
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
            Stopwatch relojOrden = new Stopwatch();

            List<Dato> resultadosOrden = new List<Dato>();

            relojOrden.Start();

            BuscarConOtro(datos, 5, resultadosOrden);

            relojOrden.Stop();

            long tiempoOrden = relojOrden.ElapsedMilliseconds;

            Stopwatch relojHeap = new Stopwatch();

            List<Dato> resultadosHeap = new List<Dato>();

            relojHeap.Start();

            BuscarConHeap(datos, 5, resultadosHeap);

            relojHeap.Stop();

            long tiempoHeap = relojHeap.ElapsedMilliseconds;

            string resultado = "";

            resultado += "RESULTADOS CONSULTA 1";
            resultado += Environment.NewLine;
            resultado += Environment.NewLine;

            resultado += "Tiempo BuscarConOtro (MergeSort): ";
            resultado += tiempoOrden + " ms";

            resultado += Environment.NewLine;

            resultado += "Tiempo BuscarConHeap (Heap Binaria): ";
            resultado += tiempoHeap + " ms";

            resultado += Environment.NewLine;
            resultado += Environment.NewLine;

            resultado += "Busqueda completada correctamente.";

            return resultado;
        }

        public String Consulta2(List<string> datos)
        {
            Dictionary<string, int> ocurrencias = ContarOcurrencias(datos);

            MaxHeap heap = new MaxHeap(ocurrencias.Count);

            foreach (KeyValuePair<string, int> item in ocurrencias)
            {
                Dato nuevoDato = new Dato(item.Value, item.Key);

                heap.Insertar(nuevoDato);
            }

            Dato[] elementos = heap.ObtenerElementos();

            string resultado = "";

            resultado += "CAMINO A LA HOJA MAS IZQUIERDA";
            resultado += Environment.NewLine;
            resultado += Environment.NewLine;

            int indice = 0;

            while (indice < heap.Count)
            {
                resultado += elementos[indice].texto;
                resultado += " (" + elementos[indice].ocurrencia + ")";

                resultado += Environment.NewLine;

                indice = 2 * indice + 1;
            }

            return resultado;
        }

        public String Consulta3(List<string> datos)
        {
            Dictionary<string, int> ocurrencias = ContarOcurrencias(datos);

            MaxHeap heap = new MaxHeap(ocurrencias.Count);

            foreach (KeyValuePair<string, int> item in ocurrencias)
            {
                Dato nuevoDato = new Dato(item.Value, item.Key);

                heap.Insertar(nuevoDato);
            }

            Dato[] elementos = heap.ObtenerElementos();

            string resultado = "";

            resultado += "DATOS DE LA HEAP POR NIVELES";
            resultado += Environment.NewLine;
            resultado += Environment.NewLine;

            int indice = 0;
            int nivel = 0;

            while (indice < heap.Count)
            {
                resultado += "Nivel " + nivel;
                resultado += Environment.NewLine;

                int cantidadElementos = (int)Math.Pow(2, nivel);

                for (int i = 0; i < cantidadElementos && indice < heap.Count; i++)
                {
                    resultado += elementos[indice].texto;
                    resultado += " (" + elementos[indice].ocurrencia + ")";

                    resultado += Environment.NewLine;

                    indice++;
                }

                resultado += Environment.NewLine;

                nivel++;
            }

            return resultado;
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

            MaxHeap heap = new MaxHeap(ocurrencias.Count);

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