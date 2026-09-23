function autocomplete(inp, arr) {
    /*the autocomplete function takes two arguments,
    the text field element and an array of possible autocompleted values:*/
    var currentFocus;
    /*execute a function when someone writes in the text field:*/
    inp.addEventListener("input", function(e) {
        var a, b, i, val = this.value;
        /*close any already open lists of autocompleted values*/
        closeAllLists();
        if (!val) { return false;}
        currentFocus = -1;
        /*create a DIV element that will contain the items (values):*/
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        /*append the DIV element as a child of the autocomplete container:*/
        this.parentNode.appendChild(a);
        /*for each item in the array...*/
        for (i = 0; i < arr.length; i++) {
          /*check if the item starts with the same letters as the text field value:*/
          if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
            /*create a DIV element for each matching element:*/
            b = document.createElement("DIV");
            /*make the matching letters bold:*/
            b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
            b.innerHTML += arr[i].substr(val.length);
            /*insert a input field that will hold the current array item's value:*/
            b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
            /*execute a function when someone clicks on the item value (DIV element):*/
                b.addEventListener("click", function(e) {
                /*insert the value for the autocomplete text field:*/
                inp.value = this.getElementsByTagName("input")[0].value;
                /*close the list of autocompleted values,
                (or any other open lists of autocompleted values:*/
                closeAllLists();
            });
            a.appendChild(b);
          }
        }
    });
    /*execute a function presses a key on the keyboard:*/
    inp.addEventListener("keydown", function(e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
          /*If the arrow DOWN key is pressed,
          increase the currentFocus variable:*/
          currentFocus++;
          /*and and make the current item more visible:*/
          addActive(x);
        } else if (e.keyCode == 38) { //up
          /*If the arrow UP key is pressed,
          decrease the currentFocus variable:*/
          currentFocus--;
          /*and and make the current item more visible:*/
          addActive(x);
        } else if (e.keyCode == 13) {
          /*If the ENTER key is pressed, prevent the form from being submitted,*/
          e.preventDefault();
          if (currentFocus > -1) {
            /*and simulate a click on the "active" item:*/
            if (x) x[currentFocus].click();
          }
        }
    });
    function addActive(x) {
      /*a function to classify an item as "active":*/
      if (!x) return false;
      /*start by removing the "active" class on all items:*/
      removeActive(x);
      if (currentFocus >= x.length) currentFocus = 0;
      if (currentFocus < 0) currentFocus = (x.length - 1);
      /*add class "autocomplete-active":*/
      x[currentFocus].classList.add("autocomplete-active");
    }
    function removeActive(x) {
      /*a function to remove the "active" class from all autocomplete items:*/
      for (var i = 0; i < x.length; i++) {
        x[i].classList.remove("autocomplete-active");
      }
    }
    function closeAllLists(elmnt) {
      /*close all autocomplete lists in the document,
      except the one passed as an argument:*/
      var x = document.getElementsByClassName("autocomplete-items");
      for (var i = 0; i < x.length; i++) {
        if (elmnt != x[i] && elmnt != inp) {
        x[i].parentNode.removeChild(x[i]);
      }
    }
  }
  /*execute a function when someone clicks in the document:*/
  document.addEventListener("click", function (e) {
      closeAllLists(e.target);
  });
  } 


  $(document).ready(function(){
var countries = ["Афганистан","Албания","Алжир","Андорра","Ангола","Ангилья","Антигуа и Барбуда","Аргентина","Армения","Аруба","Австралия" ,"Австрия","Азербайджан","Багамы","Бахрейн","Бангладеш","Барбадос","Беларусь","Бельгия","Белиз","Бенин","Бермуды","Бутан"," Боливия", "Босния и Герцеговина", "Ботсвана", "Бразилия", "Британские Виргинские острова", "Бруней", "Болгария", "Буркина-Фасо", "Бурунди", "Камбоджа", "Камерун", " Канада", "Кабо-Верде", "Каймановы острова", "Центрально-Африканская Республика", "Чад", "Чили", "Китай", "Колумбия", "Конго", "Острова Кука", "Коста-Рика", " Кот-д'Ивуар", "Хорватия", "Куба", "Кюрасао", "Кипр", "Чехия", "Дания", "Джибути", "Доминика", "Доминиканская Республика", "Эквадор", "Египет" ,"Сальвадор","Экваториальная Гвинея","Эритрея","Эстония","Эфиопия","Фолклендские острова","Фарерские острова","Фиджи","Финляндия","Франция","Французская Полинезия", "Французская Вест-Индия", "Габон", "Гамбия", "Грузия", "Германия", "Гана", "Гибралтар", "Греция", "Гренландия", "Гренада", "Гуам", "Гватемала", "Гернси", "Гвинея", "Гвинея Бисcау", "Гайана", "Гаити", "Гондурас", "Гонконг", "Венгрия", "Исландия", "Индия", "Индонезия", "Иран", "Ирак", "Ирландия", "Остров человека", "Израиль", "Италия", "Ямайка", "Япония", "Джерси", "Иордания", "Казахстан", "Кения", "Кирибати", "Косово", "Кувейт", "Кыргызстан","Лаос","Латвия","Ливан","Лесото","Либерия","Ливия","Лихтенштейн","Литва","Люксембург","Макао","Македония","Мадагаскар", "Малави", "Малайзия", "Мальдивы", "Мали", "Мальта", "Маршалловы острова", "Мавритания", "Маврикий", "Мексика", "Микронезия", "Молдова", "Монако", " Монголия", "Черногория", "Монсеррат", "Марокко", "Мозамбик", "Мьянма", "Намибия", "Науро", "Непал", "Нидерланды", "Нидерландские Антильские острова", "Новая Каледония", " Новая Зеландия", "Никарагуа", "Нигер", "Нигерия", "Северная Корея", "Норвегия", "Оман", "Пакистан", "Палау", "Палестина", "Панама", "Папуа-Новая Гвинея" ,"Парагвай","Перу","Филиппины","Польша","Португалия","Пуэрто-Рико","Катар","Реюньон","Румыния","Россия","Руанда","Сен-Пьер и ; Микелон", "Самоа", "Сан-Марино", "Сан-Томе и Принсипи", "Саудовская Аравия", "Сенегал", "Сербия", "Сейшельские острова", "Сьерра-Леоне", "Сингапур", "Словакия", " Словения", "Соломоновы острова", "Сомали", "Южная Африка", "Южная Корея", "Южный Судан", "Испания", "Шри-Ланка", "Сент-Китс и другие страны","Невис", "Сент-Люсия", "Сент-Винсент", "Судан", "Суринам", "Свазиленд", "Швеция", "Швейцария", "Сирия", "Тайвань", "Таджикистан", "Танзания", " Таиланд", "Тимор Л'Эсте", "Того", "Тонга", "Тринидад и amp; Тобаго", "Тунис", "Турция", "Туркменистан", "Турки и другие страны","Кайкос", "Тувалу", "Уганда", "Украина", "Объединенные Арабские Эмираты", "Великобритания", "Соединенные Штаты Америки", "Уругвай", "Узбекистан", "Вануату", "Ватикан", "Венесуэла", "Вьетнам", "Виргинские острова (США)", "Йемен", "Замбия", "Зимбабве"];
autocomplete(document.getElementById("countryInput"), countries);
    })