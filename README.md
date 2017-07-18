# SimpleMvvM
Base sencilla y modular para construir aplicaciones con el patrón de desarrollo MvvM
 
En esta primera aproximación he creado una libreria sencilla que te permite navegar de un ViewModel mediante el método ShowViewModel<T>() de la clase base ViewModelBase.

Para poder realizar esta navegación es necesario registrar en la raiz del proyecto las vistas con su correspondiente ViewModel. Puedes crear un método en el constructor de la aplicación, como en el ejemplo, y hacer uso de SimpleApp.RegisterView(typeof(View), typeof(ViewModel));