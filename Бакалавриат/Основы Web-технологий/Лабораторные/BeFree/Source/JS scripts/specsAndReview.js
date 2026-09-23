let descButton = document.getElementsByClassName("descriptionbutton");
let specsButton = document.getElementsByClassName("specsButton");
let reviewButton = document.getElementsByClassName("rewiewbutton");
let descText = document.getElementsByClassName("descriptiontext");
let specsText = document.getElementsByClassName("specsText");
let reviewText = document.getElementsByClassName("rewiewText");
let openedpage = 0;
console.log(specsButton);
console.log(reviewButton);


const showDesc = () => {

    if (openedpage === 1){
        descText[0].classList.remove("hide");
        specsText[0].classList.remove("show");
        reviewText[0].classList.remove("show");
        descButton[0].classList.remove("unactive")
        specsButton[0].classList.remove("active")
        reviewButton[0].classList.remove("active")
        openedpage = 0;
    }
    else if (openedpage === 2){
        descText[0].classList.remove("hide");
        specsText[0].classList.remove("show");
        reviewText[0].classList.remove("show");
        descButton[0].classList.remove("unactive")
        specsButton[0].classList.remove("active")
        reviewButton[0].classList.remove("active")
        openedpage = 0;
    }
}


const showSpecs = () => {
    if (openedpage === 0){
        descText[0].classList.add("hide");
        specsText[0].classList.add("show");
        reviewText[0].classList.remove("show");
        descButton[0].classList.add("unactive")
        specsButton[0].classList.add("active")
        reviewButton[0].classList.remove("active")
        openedpage = 1;
    }
    else if (openedpage === 2){
        descText[0].classList.add("hide");
        specsText[0].classList.add("show");
        reviewText[0].classList.remove("show");
        descButton[0].classList.add("unactive")
        specsButton[0].classList.add("active")
        reviewButton[0].classList.remove("active")
        openedpage = 1;
    }
}

const showRewiew = () => {
    if (openedpage === 0){
        descText[0].classList.add("hide");
        specsText[0].classList.remove("show");
        reviewText[0].classList.add("show");
        descButton[0].classList.add("unactive")
        specsButton[0].classList.remove("active")
        reviewButton[0].classList.add("active")
        openedpage = 2;
    }
    else if (openedpage === 1){
        descText[0].classList.add("hide");
        specsText[0].classList.remove("show");
        reviewText[0].classList.add("show");
        descButton[0].classList.add("unactive")
        specsButton[0].classList.remove("active")
        reviewButton[0].classList.add("active")
        openedpage = 2;
    }
}

specsButton[0].addEventListener('click', showSpecs);
reviewButton[0].addEventListener('click', showRewiew);
descButton[0].addEventListener('click',showDesc);