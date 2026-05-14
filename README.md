# INFORME DEL TRABAJO PRÁCTICO FINAL

## Algoritmos y Estructura de Datos

**Integrantes:**  
- Canovari Carlos  
- Tkaczuk Uriel  

**Fecha:** 11 de mayo de 2026  
**Entrega:** Primera Entrega

---

# INTRODUCCIÓN

El trabajo práctico tiene como objetivo desarrollar un sistema capaz de analizar conjuntos de datos almacenados en archivos CSV y determinar cuáles son los elementos que presentan una mayor cantidad de ocurrencias dentro del dataset.

El proyecto fue desarrollado sobre una aplicación de escritorio en Windows Forms utilizando .NET 6 y lenguaje C#. La aplicación base fue proporcionada por la cátedra, mientras que la parte principal a desarrollar consiste en la implementación de algoritmos y estructuras de datos para realizar búsquedas y consultas sobre los datos cargados.

Durante esta primera etapa del trabajo se implementaron dos estrategias de búsqueda:
- una basada en algoritmos de ordenamiento,
- y otra basada en Heap binaria.

El principal objetivo de esta entrega fue comprender el funcionamiento general del proyecto, entender cómo se procesan los datos y desarrollar soluciones funcionales y sencillas.

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

![Figura 1](imagenes/figura1.png)

**Figura 1 – Proyecto abierto en Visual Studio y estructura general del sistema.**

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

## 3. Implementación del contador de ocurrencias

Se creó un método auxiliar llamado `ContarOcurrencias()`, cuyo objetivo es recorrer la lista de strings y contar cuántas veces aparece cada elemento utilizando un `Dictionary<string,int>`.

La lógica implementada consiste en:
- verificar si un elemento ya existe en el diccionario,
- aumentar su contador si ya existe,
- o agregarlo si aparece por primera vez.

![Figura 2](imagenes/figura2.png)

**Figura 2 – Implementación del método ContarOcurrencias().**

---

## 4. Conversión de datos a objetos Dato

Una vez obtenidas las ocurrencias, los resultados fueron transformados en objetos de tipo `Dato` para poder trabajar con ellos dentro del sistema.

Cada objeto almacena:
- el texto,
- y la cantidad de ocurrencias encontradas.

Esto permitió preparar los datos para ser ordenados y posteriormente mostrados en la interfaz gráfica.

---

## 5. Implementación del algoritmo de ordenamiento

Como primera etapa del desarrollo se implementó un algoritmo `SelectionSort` debido a su simplicidad y facilidad para comprender el funcionamiento general del sistema.

La lógica utilizada consistía en:
- buscar el elemento con mayor cantidad de ocurrencias,
- moverlo al inicio de la lista,
- y repetir el proceso para el resto de los elementos.

Esta implementación permitió validar:
- el conteo de ocurrencias,
- la conversión a objetos `Dato`,
- y la visualización correcta de resultados en pantalla.

![Figura 3](imagenes/figura3.png)

**Figura 3 – Implementación inicial utilizando SelectionSort().**

---

Una vez verificado el correcto funcionamiento general del sistema, se decidió mejorar la estrategia de ordenamiento reemplazando `SelectionSort` por `MergeSort`.

La decisión fue tomada debido a que `MergeSort` posee un mejor rendimiento para trabajar con grandes volúmenes de datos, resultando más adecuado para el tamaño de los datasets utilizados en el trabajo práctico.

La lógica de `MergeSort` consiste en:
- dividir la lista en partes más pequeñas,
- ordenar recursivamente cada parte,
- y posteriormente unirlas de forma ordenada.

Además, `MergeSort` permitió reducir significativamente la cantidad de comparaciones necesarias para ordenar los datos cuando se trabaja con datasets grandes.

![Figura 4](imagenes/figura4.png)

**Figura 4 – Implementación final utilizando MergeSort().**

---

## 6. Implementación de Heap Binaria

Luego de implementar la estrategia basada en `MergeSort`, se desarrolló una Heap binaria máxima para cumplir con los requisitos principales del trabajo práctico.

La Heap fue implementada utilizando una lista para representar el árbol binario de forma implícita mediante índices.

La estructura desarrollada permitió:
- insertar elementos manteniendo la propiedad de Heap,
- reorganizar automáticamente los datos,
- y extraer rápidamente el elemento con mayor cantidad de ocurrencias.

Para ello se implementaron los métodos:
- `Insertar()`,
- `HeapifyUp()`,
- `HeapifyDown()`,
- y `ExtraerMax()`.

La estrategia `BuscarConHeap()` utiliza esta estructura para almacenar los datos según su prioridad y posteriormente recuperar los elementos con mayor cantidad de ocurrencias.

![Figura 5](imagenes/figura5.png)

**Figura 5 – Implementación de la Heap binaria máxima.**

---

## 7. Carga de resultados

Finalmente, luego de ordenar la lista o utilizar la Heap, se tomaron únicamente los primeros resultados solicitados por el usuario mediante el parámetro `cantidad`.

Estos elementos fueron agregados a la lista `collected` para ser mostrados posteriormente en la interfaz gráfica del sistema.

![Figura 6](imagenes/figura6.png)

**Figura 6 – Resultados obtenidos en la interfaz gráfica del programa.**

---

# RESULTADOS

Durante el desarrollo del trabajo primero se utilizó `SelectionSort` como una implementación inicial para validar el funcionamiento general del sistema.

Posteriormente, se reemplazó por `MergeSort` debido a que ofrece una mejor complejidad y un rendimiento más adecuado para conjuntos de datos grandes.

Además de la estrategia basada en ordenamiento, se logró implementar correctamente una Heap binaria máxima para resolver el problema utilizando una estructura de prioridad.

Esto permitió comparar dos enfoques diferentes:
- uno basado en ordenamiento completo,
- y otro basado en prioridades utilizando Heap.

La implementación de la Heap permitió profundizar la comprensión de estructuras de datos jerárquicas y del manejo de árboles binarios implícitos mediante listas.

---

# CONCLUSIÓN

En esta primera entrega se logró desarrollar una solución funcional para el problema planteado utilizando estructuras y algoritmos básicos vistos en la materia.

El trabajo permitió reforzar conceptos importantes como:
- recorridos de listas,
- conteo de ocurrencias,
- uso de diccionarios,
- algoritmos de ordenamiento,
- manejo de objetos,
- Heap binaria,
- y separación entre lógica e interfaz gráfica.

Para las próximas etapas del proyecto se espera:
- implementar las consultas restantes solicitadas por la cátedra,
- medir tiempos de ejecución,
- y mejorar la organización interna del código.

Además, el trabajo permitió comprender la diferencia entre implementar una solución simplemente funcional y posteriormente evolucionarla hacia alternativas más eficientes y adecuadas para el problema planteado.

En conclusión, esta primera entrega permitió no solamente desarrollar una solución funcional, sino también comprender de manera más profunda cómo aplicar estructuras de datos y algoritmos reales dentro de un proyecto completo.

---

# REFERENCIAS

- Material teórico de Algoritmos y Estructuras de Datos – UNAJ.
- Clases prácticas de la materia.
- Documentación oficial de C# y .NET.
- Código base proporcionado por la cátedra.







