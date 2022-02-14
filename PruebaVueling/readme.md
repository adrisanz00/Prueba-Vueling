BASE DE DATOS
- En el fichero appsettings.json tenemos especifica la conexion a la base de datos, y para realizar la migracion desde la consola de paquetes ejecutamos los comandos
"add-migration" y después "update-database" asi ya tendremos nuestra base de datos con las tablas y relaciones definidas.

DISTRIBUCIÓN SOLUCION	
- Esta organizado por proyectos: controladores, modelos,  data context, el manejo de errores y su log, herramientas útiles, los test unitarios y los servicios.

EJECUCIÓN
- Al ejecutar el proyecto se nos abrirá el swagger para poder realizar desde ahí todas las peticiones necesarias y ver si están funcionando