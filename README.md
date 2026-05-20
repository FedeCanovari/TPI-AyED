# INFORME DEL TRABAJO PRÁCTICO FINAL

# Algoritmos y Estructura de Datos

## Integrantes

- Canovari Carlos
- Tkaczuk Uriel

## Fecha

20 de mayo de 2026

## Entrega

Entrega Final

---

# INTRODUCCIÓN

El trabajo práctico tiene como objetivo desarrollar un sistema capaz de analizar conjuntos de datos almacenados en archivos CSV y determinar cuáles son los elementos que presentan una mayor cantidad de ocurrencias dentro del dataset.

El proyecto fue desarrollado sobre una aplicación de escritorio en Windows Forms utilizando .NET 6 y lenguaje C#. La aplicación base fue proporcionada por la cátedra, mientras que la parte principal a desarrollar consistió en la implementación de algoritmos y estructuras de datos para realizar búsquedas y consultas sobre los datos cargados.

Durante el desarrollo del trabajo se implementaron dos estrategias de búsqueda:

- una basada en algoritmos de ordenamiento,
- y otra basada en Heap binaria.

Además, se desarrollaron distintas consultas para analizar el comportamiento interno de la estructura Heap y comparar el rendimiento entre ambas estrategias implementadas.

El principal objetivo del proyecto fue comprender el funcionamiento general de estructuras de datos reales y aplicarlas dentro de un sistema funcional completo.

---

# HIPÓTESIS

Se espera que utilizando una estructura `Dictionary<string,int>` sea posible contar correctamente la cantidad de apariciones de cada elemento del dataset.

Además:

- utilizando algoritmos de ordenamiento será posible organizar los resultados según cantidad de ocurrencias,
- y mediante una Heap binaria será posible recuperar rápidamente los elementos de mayor prioridad.

También se considera que dividir el problema en pequeñas etapas facilita la comprensión y el desarrollo del sistema.

---

# PROCEDIMIENTO

## 1. Análisis inicial del proyecto

Primero se ejecutó el programa para comprender el flujo general de la aplicación y observar cómo se cargaban los datos desde el archivo CSV.

Se analizaron principalmente:

- la lectura del dataset,
- el funcionamiento de la interfaz,
- el uso de la clase `Backend`,
- y la relación entre `Backend` y `Estrategia`.

---

## 2. Análisis de la clase Estrategia

Luego se revisó la clase `Estrategia`, identificando los métodos que debían ser implementados:

- `BuscarConOtro()`
- `BuscarConHeap()`
- `Consulta1()`
- `Consulta2()`
- `Consulta3()`

En una primera etapa se decidió implementar inicialmente una solución basada en ordenamiento, ya que representa una alternativa más simple y adecuada para comprender el funcionamiento general del trabajo práctico.

---

# IMPLEMENTACIÓN

## 3. Implementación del contador de ocurrencias

Se creó un método auxiliar llamado `ContarOcurrencias()`, cuyo objetivo es recorrer la lista de strings y contar cuántas veces aparece cada elemento utilizando un `Dictionary<string,int>`.

La lógica implementada consiste en:

- verificar si un elemento ya existe en el diccionario,
- aumentar su contador si ya existe,
- o agregarlo si aparece por primera vez.

### Código implementado

```csharp
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
```

---

## 4. Conversión de datos a objetos Dato

Una vez obtenidas las ocurrencias, los resultados fueron transformados en objetos de tipo `Dato` para poder trabajar con ellos dentro del sistema.

Cada objeto almacena:

- el texto,
- y la cantidad de ocurrencias encontradas.

Esto permitió preparar los datos para ser ordenados y posteriormente mostrados en la interfaz gráfica.

### Código implementado

```csharp
foreach (KeyValuePair<string, int> item in ocurrencias)
{
    Dato nuevoDato = new Dato(item.Value, item.Key);

    listaDatos.Add(nuevoDato);
}
```

---

## 5. Implementación del algoritmo de ordenamiento (MergeSort)

Para implementar la estrategia alternativa al uso de Heap se utilizó el algoritmo `MergeSort`.

La decisión fue tomada debido a que `MergeSort` posee un mejor rendimiento para trabajar con grandes volúmenes de datos, resultando adecuado para el tamaño de los datasets utilizados en el trabajo práctico.

La lógica de `MergeSort` consiste en:

- dividir la lista en partes más pequeñas,
- ordenar recursivamente cada parte,
- y posteriormente unirlas de forma ordenada.

### Código implementado (MergeSort)

```csharp
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
```

### Código implementado (Merge)

```csharp
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
```

### Código implementado (BuscarConOtro)

```csharp
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
```

---

## 6. Implementación de Heap Binaria

Luego de implementar la estrategia basada en `MergeSort`, se desarrolló una Heap binaria máxima para cumplir con los requisitos principales del trabajo práctico.

La Heap fue implementada utilizando una lista para representar el árbol binario de forma implícita mediante índices.

La estructura desarrollada permitió:

- insertar elementos manteniendo la propiedad de Heap,
- reorganizar automáticamente los datos,
- y extraer rápidamente el elemento con mayor cantidad de ocurrencias.

### Código implementado (Insertar)

```csharp
public void Insertar(Dato dato)
{
    elementos.Add(dato);

    SubirElemento(elementos.Count - 1);
}
```

### Código implementado (SubirElemento)

```csharp
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
```

### Código implementado (BajarElemento)

```csharp
private void BajarElemento(int indice)
{
    int ultimoIndice = elementos.Count - 1;

    while (true)
    {
        int hijoIzquierdo = indice * 2 + 1;
        int hijoDerecho = indice * 2 + 2;

        int mayor = indice;

        if (hijoIzquierdo <= ultimoIndice &&
            elementos[hijoIzquierdo].ocurrencia > elementos[mayor].ocurrencia)
        {
            mayor = hijoIzquierdo;
        }

        if (hijoDerecho <= ultimoIndice &&
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
```

### Código implementado (ExtraerMax)

```csharp
public Dato ExtraerMax()
{
    Dato maximo = elementos[0];

    elementos[0] = elementos[elementos.Count - 1];

    elementos.RemoveAt(elementos.Count - 1);

    BajarElemento(0);

    return maximo;
}
```

### Código implementado (BuscarConHeap)

```csharp
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
```

---

# CONSULTAS IMPLEMENTADAS

## 7. Consulta1() — Comparación de tiempos

La primera consulta fue desarrollada para comparar los tiempos de ejecución entre las estrategias basadas en ordenamiento y Heap binaria.

Para ello se utilizó la clase `Stopwatch` de C#.

### Código implementado

```csharp
public String Consulta1(List<string> datos)
{
    Stopwatch relojHeap = new Stopwatch();
    Stopwatch relojOrden = new Stopwatch();

    List<Dato> listaHeap = new List<Dato>();
    List<Dato> listaOrden = new List<Dato>();

    relojHeap.Start();
    BuscarConHeap(datos, 5, listaHeap);
    relojHeap.Stop();

    relojOrden.Start();
    BuscarConOtro(datos, 5, listaOrden);
    relojOrden.Stop();

    string resultado = "";

    resultado += "Tiempo Heap: ";
    resultado += relojHeap.ElapsedMilliseconds;
    resultado += " ms";

    resultado += Environment.NewLine;

    resultado += "Tiempo Ordenamiento: ";
    resultado += relojOrden.ElapsedMilliseconds;
    resultado += " ms";

    return resultado;
}
```

---

## 8. Consulta2() — Camino hacia la hoja más izquierda

La segunda consulta permite recorrer el camino hacia la hoja más izquierda de la Heap binaria.

El recorrido se realiza utilizando índices dentro de la lista.

Para avanzar hacia el hijo izquierdo se utiliza:

```text
hijo izquierdo = 2 * índice + 1
```

### Código implementado

```csharp
public String Consulta2(List<string> datos)
{
    Dictionary<string, int> ocurrencias = ContarOcurrencias(datos);

    MaxHeap heap = new MaxHeap();

    foreach (KeyValuePair<string, int> item in ocurrencias)
    {
        heap.Insertar(new Dato(item.Value, item.Key));
    }

    string resultado = "";

    int indice = 0;

    while (indice < heap.elementos.Count)
    {
        resultado += heap.elementos[indice].texto;
        resultado += " -> ";

        indice = indice * 2 + 1;
    }

    resultado += "FIN";

    return resultado;
}
```

---

## 9. Consulta3() — Mostrar Heap por niveles

La tercera consulta muestra los elementos de la Heap organizados por niveles, permitiendo representar visualmente la estructura jerárquica del árbol binario.

### Código implementado

```csharp
public String Consulta3(List<string> datos)
{
    Dictionary<string, int> ocurrencias = ContarOcurrencias(datos);

    MaxHeap heap = new MaxHeap();

    foreach (KeyValuePair<string, int> item in ocurrencias)
    {
        heap.Insertar(new Dato(item.Value, item.Key));
    }

    string resultado = "";

    int nivel = 0;
    int cantidadNivel = 1;
    int contador = 0;

    resultado += "Nivel " + nivel + ":" + Environment.NewLine;

    foreach (Dato dato in heap.elementos)
    {
        resultado += dato.texto;
        resultado += " (" + dato.ocurrencia + ")";
        resultado += Environment.NewLine;

        contador++;

        if (contador == cantidadNivel)
        {
            nivel++;

            resultado += Environment.NewLine;
            resultado += "Nivel " + nivel + ":" + Environment.NewLine;

            cantidadNivel = cantidadNivel * 2;

            contador = 0;
        }
    }

    return resultado;
}
```

---

## 10. Corrección y análisis del dataset

Durante las pruebas iniciales se observó que los resultados obtenidos no eran representativos debido a que se estaban utilizando columnas del dataset con poca variabilidad.

Inicialmente se trabajó utilizando columnas relacionadas con medidas estadísticas.

Luego de analizar la estructura real del CSV, se decidió utilizar la columna correspondiente al nombre del contaminante (`fields[0]`), obteniendo resultados más coherentes.

### Código corregido

```csharp
titulo = Utils.RemoveSpecialCharacters(fields[0]);
```

---

# RESULTADOS

Durante el desarrollo del trabajo se logró implementar correctamente dos estrategias distintas para resolver el problema planteado:

- una basada en ordenamiento mediante `MergeSort`,
- y otra basada en una Heap binaria máxima.

Además, las consultas implementadas permitieron analizar internamente la estructura de la Heap y comparar el comportamiento de ambas estrategias de búsqueda.

La implementación de la Heap permitió profundizar la comprensión de estructuras de datos jerárquicas y del manejo de árboles binarios implícitos mediante listas.

---

# DIAGRAMAS DE FLUJO

## ContarOcurrencias()

![ContarOcurrencias](diagramas/Diagrama_de_flujo-ContarOcurrencias.png)

---

## BuscarConOtro()

![BuscarConOtro](diagramas/buscar_con_otro.png)

---

## MergeSort()

![MergeSort](diagramas/mergesort.png)

---

## BuscarConHeap()

![BuscarConHeap](diagramas/buscar_con_heap.png)

---

## Consulta1()

![Consulta1](diagramas/consulta1.png)

---

# CONCLUSIÓN

En la entrega final se logró desarrollar una solución funcional para el problema planteado utilizando estructuras y algoritmos vistos en la materia.

El trabajo permitió reforzar conceptos importantes como:

- recorridos de listas,
- conteo de ocurrencias,
- uso de diccionarios,
- algoritmos de ordenamiento,
- manejo de objetos,
- Heap binaria,
- árboles binarios implícitos,
- y separación entre lógica e interfaz gráfica.

Además, se logró comprender cómo representar estructuras jerárquicas utilizando listas y cómo aplicar algoritmos reales dentro de un proyecto funcional completo.

En conclusión, el trabajo permitió no solamente desarrollar una solución funcional, sino también comprender de manera más profunda cómo aplicar estructuras de datos y algoritmos reales dentro de un proyecto completo.

---

# REFERENCIAS

- Material teórico de Algoritmos y Estructuras de Datos – UNAJ.
- Clases prácticas de la materia.
- Documentación oficial de C# y .NET.
- Código base proporcionado por la cátedra.
