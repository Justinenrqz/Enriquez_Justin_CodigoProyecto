# Enriquez_Justin_CodigoProyecto


🚀 Arquitectura del Sistema y Módulos Principales
El proyecto se divide en diferentes componentes desacoplados siguiendo el principio de responsabilidad única de SOLID para facilitar la optimización de rendimiento y la depuración en Unity:

1. Sistema de Animación e Interfaz (UI)
Controladores de Animación por Eventos: Sincronización precisa de los estados del personaje (Idle, Run, Attack, Hurt, Die) mediante scripts que escuchan eventos específicos de las animaciones, evitando el uso excesivo de variables booleanas en el Animator y optimizando las transiciones en Pixel Art.

UI Dinámica (Health Bars): Barras de salud flotantes y principales que reaccionan en tiempo real mediante interpolación lineal (Mathf.Lerp) para suavizar el impacto visual cuando un elemento recibe daño.

2. Motor de Combate e Inteligencia Artificial
AI Enemy Spawners: Generadores automáticos de enemigos controlados por oleadas o rangos de proximidad. Gestionan el ciclo de vida de las entidades en escena para optimizar el uso de memoria RAM.

Mecánicas de Progresión y "Grinding": Estructura de datos diseñada para almacenar la experiencia, el escalado de atributos del jugador y las recompensas obtenidas al derrotar entidades enemigas.

3. Entorno Visual y Movimiento
Efecto Parallax 2D: Capas de fondo estructuradas de forma independiente que se desplazan a diferentes velocidades en relación con el movimiento de la cámara principal (Camera.main), simulando profundidad tridimensional en un entorno puramente bidimensional.

🛠️ Tecnologías y Hardware de Desarrollo
Motor Gráfico: Unity 2D Engine.

Lenguaje de Programación: C# (.NET Standard / Mono).

Entorno de Pruebas Target: Optimizado para despliegues fluidos en PC con configuraciones de hardware dedicadas (arquitecturas de gama media como Intel i5 / GPU AMD RX Series) e interfaces de usuario adaptables a dispositivos móviles modernos.

