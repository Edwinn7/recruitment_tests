function updateOutput() {
    let input = document.getElementById("input").value;
    let output = document.getElementById("output");
    let length = document.getElementById("length");
    let consonants = document.getElementById("consonants");

    // segunb se va escribiendo se actualiza
    output.innerText = input;

    // cambio de color segun el input text si esta vacio o tiene contenido 
    if (input.length == 0) {
        output.style.color = "red";
        output.innerText = "You need to type something";
    } else {
        output.style.color = "green";
        output.innerText = "You have typed something";
    }

    // mensaje de cantidad de letras/caracteres
    length.innerText = "The message is " + input.length + " characters long.";

    // funcion para contar consonantes
    let consonantCount = 0;
    for (let i = 0; i < input.length; i++) {
        let c = input.charAt(i);
        if (/^[a-zA-Z]$/.test(c)) {
            if (!(/[aeiouAEIOU]/.test(c))) {
                consonantCount++;
            }
        }
    }
    let consonantPercentage = (consonantCount / input.length * 100).toFixed(2);
    consonants.innerText = consonantCount + " out of " + input.length + " are consonants (" + consonantPercentage + "% of the total).";
}
