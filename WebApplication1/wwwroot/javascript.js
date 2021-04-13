let light = document.querySelector('.light span');
let dark = document.querySelector('.dark span');
let ControlHeader = document.querySelector('.control');



let inc = document.querySelector('.font-inc');
let reset = document.querySelector('.font-reset');
let dec = document.querySelector('.font-dec');


window.onload = function () {


    if (localStorage.fontSize == 'normal') {
        ControlHeader.classList.add("normal")
        ControlHeader.classList.remove("largefont", "smallfont")
    }
    if (localStorage.fontSize == 'larger') {
        ControlHeader.classList.add("largefont")
        ControlHeader.classList.remove("normalfont", "smallfont")
    }
    if (localStorage.fontSize == 'smaller') {
        ControlHeader.classList.add("smallfont")
        ControlHeader.classList.remove("largefont", "normalfont")
    }


    if (localStorage.mode == 'darker') {
        ControlHeader.classList.add("darker")
        ControlHeader.classList.remove('lighter');
    }
    if (localStorage.mode == 'lighter') {
        ControlHeader.classList.add("lighter")
        ControlHeader.classList.remove("darker")
    }

}