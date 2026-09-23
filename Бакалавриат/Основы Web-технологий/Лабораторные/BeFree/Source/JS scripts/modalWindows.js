const popuplinks = document.querySelectorAll('.popup-link');
const body = document.querySelector('body')
const lockPadding = document.querySelectorAll(".lock-padding")

console.log(popuplinks)

let unlock = true;

const timeout = 800;

if (popuplinks.length > 0){
    for (let index = 0; index < popuplinks.length; index++){
        const popuplink = popuplinks[index];
        popuplink.addEventListener("click",function(e){
            const popupName = popuplink.getAttribute('href').replace("#",'');
            const currentPopup = document.getElementById(popupName);
            popupOpen (currentPopup);
            e.preventDefault();
        })
    }
}


const popupCloseIcon = document.querySelectorAll('.close-popup')
    
if (popupCloseIcon.length > 0){
    for (let index = 0; index < popupCloseIcon.length; index++){
        const el = popupCloseIcon[index];
        el.addEventListener("click",function(e){
            popupClose(el.closest('.popup'));
            e.preventDefault();
        })
    }
}

function popupOpen(currentPopup){
    if (currentPopup && unlock){
        const popupActive = document.querySelector('.popup.open');
        if (popupActive){
            popupClose(popupActive, false);
        }
        else {
            bodylock();
        }
        
        currentPopup.classList.add('open');
        currentPopup.addEventListener("click", function(e){
            if (!e.target.closest('.popup_content')){
                popupClose(e.target.closest('.popup'))
            }
        })
    }
}

function popupClose(popupActive, doUnlock = true){
    if (unlock){
        popupActive.classList.remove('open');
            if (doUnlock){
                
            }
    }
}

function bodylock(){
    const lockPaddingValue = window.innerWidth - document.querySelector('body').offsetWidth + 'px';

    if (lockPadding.length > 0){
        for (let index = 0; index < lockPadding.length; index++){
            const el = lockPadding[index];
            el.style.paddingRight = lockPaddingValue;
        }
    }
    body.style.paddingRight = lockPaddingValue;
    body.classList.add('lock');

    unlock = false;

    setTimeout(function() {
        unlock = true;
    },timeout)
}

function bodyunlock(){
    setTimeout(() => {
       for (let index = 0; index <lockPadding.length; index++){
        const el = lockPadding[index];
        el.style.paddingRight = '0px';
       } 
       body.style.paddingRight = '0px';
       body.classList.remove('lock');
    }, timeout);

    unlock = false;
    setTimeout(() => {
        unlock = true;
    }, timeout)
}

document.addEventListener('keydown', function(e){
    if (e.key === 'Escape'){
        const popupActive = document.querySelector('popup.open')
        popupClose(popupActive)
    }
})

(function() {

    // проверяем поддержку
    if (!Element.prototype.closest) {
  
      // реализуем
      Element.prototype.closest = function(css) {
        var node = this;
  
        while (node) {
          if (node.matches(css)) return node;
          else node = node.parentElement;
        }
        return null;
      };
    }
  
  })();


(function() {

    // проверяем поддержку
    if (!Element.prototype.matches) {
  
      // определяем свойство
      Element.prototype.matches = Element.prototype.matchesSelector ||
        Element.prototype.webkitMatchesSelector ||
        Element.prototype.mozMatchesSelector ||
        Element.prototype.msMatchesSelector;
  
    }
  
  })();