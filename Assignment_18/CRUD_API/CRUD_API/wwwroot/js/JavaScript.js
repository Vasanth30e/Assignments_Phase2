document.addEventListener("DOMContentLoaded", () => {
    const movieList = document.getElementById("movieList");
    const createMovieForm = document.getElementById("createMovieForm");
    const updateMovieForm = document.getElementById("updateMovieForm");
    const deleteMovieForm = document.getElementById("deleteMovieForm");

    // Function to fetch and display tasks
    function displayMovies() {
        fetch("http://localhost:5187/api/movies")
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(movies => {
                movieList.innerHTML = ""; // Clear previous list
                movies.forEach(movie => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `ID: ${movie.id}, Title: ${movie.title}, Genre: ${movie.genre}, Director: ${movie.director}`;
                    movieList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch Error:", error);
                movieList.innerHTML = "Error fetching tasks";
            });
    }

    // Event listener for Create Task form submission 
    createMovieForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const title = document.getElementById("title").value;
        const genre = document.getElementById("genre").value;
        const director = document.getElementById("director").value;

        fetch("http://localhost:5187/api/movies", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ title, genre, director })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                // Clear form fields after successful creation
                document.getElementById("title").value = "";
                document.getElementById("genre").value = "";
                document.getElementById("director").value = "";

                // Refresh the task list
                displayMovies();
            })
            .catch(error => {
                console.error("Fetch error: ", error);
            });
    });

    //Event Listener for Update Task Form submission
    updateMovieForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const movieId = document.getElementById("movieId").value;
        const newTitle = document.getElementById("newTitle").value;
        const newGenre = document.getElementById("newGenre").value;
        const newDirector = document.getElementById("newDirector").value;

        fetch(`http://localhost:5187/api/movies/${movieId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ id: movieId, title: newTitle, genre: newGenre, director: newDirector })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                //Clear form Fields after successfull update
                document.getElementById("movieId").value = "";
                document.getElementById("newTitle").value = "";
                document.getElementById("newGenre").value = "";
                document.getElementById("newDirector").value = "";

                displayMovies();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    //Event Listener for Delete Task Form submission
    deleteMovieForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const deleteMovieId = document.getElementById("deleteMovieId").value;

        fetch(`http://localhost:5187/api/movies/${deleteMovieId}`, {
            method: "DELETE"
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                document.getElementById("deleteMovieId").value = ""
                displayMovies();
            })
            .catch(error => {
                console.error("Fetch Error", error);
            });
    });

    // Initial display of tasks when the page loads
    displayMovies();
});