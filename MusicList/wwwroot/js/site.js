function validate() {
    var name = document.getElementById("name");
    var artist = document.getElementById("artist");
    var genre = document.getElementByid("genre");
    var rating = document.getElementByid("rating");

    var error_name = document.getElementById("error_name");
    var error_artist = document.getElementById("error_artist");
    var error_genre = document.getElementById("error_genre");
    var error_rating = document.getElementById("error_rating");

    if (name == "") {
        error_name.innerHTML = "This field is required!";
        return false;
    }

    if (artist == "") {
        error_artist.innerHTML = "This field is required!";
        return false;
    }

    if (genre == "") {
        error_name.innerHTML = "This field is required!";
        return false;
    }

    return true;
}