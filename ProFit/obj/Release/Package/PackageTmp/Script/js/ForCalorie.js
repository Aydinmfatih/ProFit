function calc() {
    let A = document.getElementById("age").value;
    let W = document.getElementById("weight").value;
    let H = document.getElementById("height").value;
    let S
    let R


    // input check
    if (document.getElementById("age").value.length == 0) {

        document.getElementById("ATT").style = "color: green;"
        document.getElementById("WTT").style = "display: none;"
        document.getElementById("HTT").style = "display: none;"

        return

    }

    if (document.getElementById("weight").value.length == 0) {

        document.getElementById("ATT").style = "display: none;"
        document.getElementById("HTT").style = "display: none;"
        document.getElementById("WTT").style = "color: red;"

        return

    }

    if (document.getElementById("height").value.length == 0) {

        document.getElementById("ATT").style = "display: none;"
        document.getElementById("WTT").style = "display: none;"
        document.getElementById("HTT").style = "color: green;"

        return

    }


    // Basal
    if (document.getElementById("male").checked) {
        S = Math.round((9.99 * W) + (6.25 * H) - (4.92 * A) + 5)
    } else if (document.getElementById("female").checked) {
        S = Math.round((9.99 * W) + (6.25 * H) - (4.92 * A) - 161)
    }

    // Activity 0 (BMR)
    if (document.getElementById("0").selected) {
        R = S
    }

    // Activity 1
    if (document.getElementById("1").selected) {
        R = S * 1.2
    }

    // Activity 2
    if (document.getElementById("2").selected) {
        R = S * 1.35
    }

    // Activity 3
    if (document.getElementById("3").selected) {
        R = S * 1.55
    }

    // Activity 4
    if (document.getElementById("4").selected) {
        R = S * 1.75
    }

    // Activity 5
    if (document.getElementById("5").selected) {
        R = S * 1.95
    }

    document.getElementById("ATT").style = "display: none;"
    document.getElementById("HTT").style = "display: none;"
    document.getElementById("WTT").style = "display: none;"

    document.getElementById("age").placeholder = " "
    document.getElementById("weight").placeholder = "Kg"
    document.getElementById("height").placeholder = "Cm"

    document.getElementById("a").innerHTML = Math.round(R)

    document.getElementById("b").innerHTML = Math.round(R * 0.80)

    document.getElementById("c").innerHTML = Math.round(R * 1.20)

    document.getElementById("Final").style = "max-width: 55rem; margin: auto; border: 2px solid black; width: 50%; margin-top: 45px; box-shadow: 4px 3px 9px; background-color:aliceblue; border-radius: 20px; color:gray; margin-bottom: 30px"
}

