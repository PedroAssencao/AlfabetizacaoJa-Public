
const resultadoDiv = document.querySelector('#resultadoDiv');
const resultadoTextarea = document.querySelector('#resultado');
const btnGravar = document.querySelector("#BtnmicOn");
const BtnParar = document.querySelector("#BtnmicOff");
const BtnBaixar = document.querySelector("#BtnDownload");
const BtnLimpar = document.querySelector("#BtnDelete");

class speechApi {
    constructor() {
        const speechToText = window.SpeechRecognition || window.webkitSpeechRecognition;

        this.speechApi = new speechToText();
        this.speechApi.continuous = true;
        this.speechApi.lang = "pt-BR";

        this.speechApi.onresult = e => {
            var resultIndex = e.resultIndex;
            var transcript = e.results[resultIndex][0].transcript;
            resultadoTextarea.innerHTML += `<h4>${transcript}</h4>`;
        };
    }

    start() {
        this.speechApi.start();
    }
    stop() {
        this.speechApi.stop();
    }
}

var speech = new speechApi(); 

function grava() {
    btnGravar.disabled = true;
    BtnParar.disabled = false;
    speech.start();
    btnGravar.style.display = 'none'
    BtnParar.style.display = 'block'
}

function paragravar() {
    btnGravar.disabled = false;
    BtnParar.disabled = true;
    speech.stop();
    document.getElementById('ResultadoGeral').style.display = 'block'
    BtnParar.style.display = 'none'
    btnGravar.style.display = 'none'
    document.getElementById('recomecar').style.display = 'block'
    corrigirTexto()
}
