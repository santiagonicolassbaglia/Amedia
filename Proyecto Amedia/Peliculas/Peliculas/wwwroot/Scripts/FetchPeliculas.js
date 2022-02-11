



    function FetchTraerTodasLasPeliculas() {

        fetch("https://localhost:44348/Api/Pelicula").then(data => data.json()).then(data =>
        { console.log(data) }).catch(err => console.log(err))

    }
    FetchTraerTodasLasPeliculas()
    function FetchTraerPelicula() {

        fetch("https://localhost:44348/Api/Pelicula").then(data => data.json()).then(data => { console.log(data) }).catch(err => console.log(err))

    }
