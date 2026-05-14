## INFORME DEL TRABAJO PRÁCTICO FINAL

Materia: Algoritmos y Estructura de datos
Alumnos: Canovari Carlos - Tkaczuk Uriel
Fecha: 11 de mayo de 2026

### INTRODUCCIÓN

El trabajo práctico tiene como objetivo desarrollar un sistema capaz de analizar
conjuntos de datos almacenados en archivos CSV y determinar cuáles son los
elementos que presentan una mayor cantidad de ocurrencias dentro del dataset.
El proyecto fue desarrollado sobre una aplicación de escritorio en Windows Forms
utilizando .NET 6 y lenguaje C#. La aplicación base fue proporcionada por la cátedra,
mientras que la parte principal a desarrollar consiste en la implementación de
algoritmos y estructuras de datos para realizar búsquedas y consultas sobre los datos
cargados.
Durante esta primera etapa del trabajo se implementó una estrategia de búsqueda
alternativa al uso de Heap, utilizando estructuras básicas vistas en clase como listas,
diccionarios y algoritmos de ordenamiento.
El principal objetivo de esta entrega fue comprender el funcionamiento general del
proyecto, entender cómo se procesan los datos y desarrollar una solución funcional y
sencilla.

### HIPÓTESIS

Se espera que utilizando una estructura Dictionary<string, int> sea posible contar
correctamente la cantidad de apariciones de cada elemento del dataset.
Además, utilizando posteriormente un algoritmo de ordenamiento, será posible
organizar los resultados desde el elemento con mayor cantidad de ocurrencias hasta
el menor, permitiendo mostrar únicamente los primeros resultados solicitados por el
usuario.
También se considera que dividir el problema en pequeñas etapas facilita la
comprensión y el desarrollo del sistema.

### PROCEDIMIENTO

1. Análisis inicial del proyecto
Primero se ejecutó el programa para comprender el flujo general de la
aplicación y observar cómo se cargaban los datos desde el archivo CSV.
Se analizaron principalmente:
● la lectura del dataset
● el funcionamiento de la interfaz
● el uso de la clase Backend
● la relación entre Backend y Estrategia.

2. Análisis de la clase Estrategia
Luego se revisó la clase Estrategia, identificando los métodos que debían ser
implementados: 
● BuscarConOtro()

● BuscarConHeap()

● Consulta1()

● Consulta2()

● Consulta3()

En esta primera etapa se decidió implementar únicamente el método
BuscarConOtro(), ya que representa una solución más simple y adecuada para
comprender el funcionamiento general del trabajo práctico.

4. Implementación del contador de ocurrencias
Se creó un método auxiliar llamado ContarOcurrencias(), cuyo objetivo es
recorrer la lista de strings y contar cuántas veces aparece cada elemento
utilizando un Dictionary<string, int>.
● La lógica implementada consiste en:

  ● verificar si un elemento ya existe en el diccionario
  
  ● aumentar su contador si ya existe
  
  ● o agregarlo si aparece por primera vez.

6. Conversión de datos a objetos Dato
Una vez obtenidas las ocurrencias, los resultados fueron transformados en
objetos de tipo Dato para poder trabajar con ellos dentro del sistema.
Cada objeto almacena:
● el texto

● y la cantidad de ocurrencias encontradas.
Esto permitió preparar los datos para ser ordenados y posteriormente
mostrados en la interfaz gráfica.

8. Implementación del algoritmo de ordenamiento
Como primera etapa del desarrollo se implementó un algoritmo SelectionSort
debido a su simplicidad y facilidad para comprender el funcionamiento
general del sistema.
La lógica utilizada consistía en:
● buscar el elemento con mayor cantidad de ocurrencias,
● moverlo al inicio de la lista,
● y repetir el proceso para el resto de los elementos.

Esta implementación permitió validar:
● el conteo de ocurrencias
● la conversión a objetos Dato
● y la visualización correcta de resultados en pantalla












