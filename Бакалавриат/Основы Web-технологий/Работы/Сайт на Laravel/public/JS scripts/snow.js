var snowmax = 500;
var snowcolor = new Array("#40E0D0", "#E0FFFF", "#4682B4", "#6495ED", "#F0FFFF", "#B0C4DE", "#EFF5FF")
var snowtype = new Array("Arial Black", "Arial Narrow", "Times", "Comic Sans MS");
var snowletter = "*";
var snowmaxsize = 25;
var snowminsize = 8;
var snowingzone = 1;


var snow = new Array();
var marginbottom;
var marginright;
var timer;
var i_snow = 0;
var x_mv = new Array();
var crds = new Array();
var lftrght = new Array();

function randommaker(range) {
    rand = Math.floor(range * Math.random());
    return rand;
}

function randommakerFloat(range) {
    rand = range * Math.random();
    return rand;
}

function initsnow() {
    marginbottom = window.innerHeight;
    marginright = window.innerWidth-15;
    var snowsizerange = snowmaxsize - snowminsize;
    for (i = 0; i <= snowmax; i++) {
        crds[i] = 0;
        lftrght[i] = Math.random() * 15;
        x_mv[i] = 0.03 + Math.random() / 10;
        snow[i] = document.getElementById("s" + i);
        snow[i].style.fontFamily = snowtype[randommaker(snowtype / length)];
        snow[i].size = randommaker(snowsizerange) + snowminsize;
        snow[i].style.fontSize = snow[i].size + "px";
        snow[i].style.color = snowcolor[randommaker(snowcolor.length)];
        snow[i].sink = randommakerFloat(1.1) * snow[i].size / 5;
        if (snowingzone == 1) { snow[i].posx = randommaker(marginright - snow[i].size) }
        if (snowingzone == 2) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) }
        if (snowingzone == 3) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 4 }
        if (snowingzone == 4) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 2 }
        snow[i].posy = randommaker(2 * marginbottom - marginbottom - 2 * snow[i].size);
        snow[i].style.left = snow[i].posx + "px";
        snow[i].style.top = snow[i].posy + "px";
    }
    movesnow();
}
function movesnow() {
    for (i = 0; i <= snowmax; i++) {
        crds[i] += x_mv[i];
        snow[i].posy += snow[i].sink;
        snow[i].style.left = snow[i].posx + lftrght[i] * Math.sin(crds[i]) + "px";
        snow[i].style.top = snow[i].posy + "px";
        if (snow[i].posy >= marginbottom - 2 * snow[i].size || parseInt(snow[i].style.left) > (marginright - 3 * lftrght[i])) {
            if (snowingzone == 1) { snow[i].posx = randommaker(marginright - snow[i].size) }
            if (snowingzone == 2) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) }
            if (snowingzone == 3) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 4 }
            if (snowingzone == 4) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 2 }
            snow[i].posy = 0;
        }
    }
    var timer = setTimeout("movesnow()", 25);
}
for (i = 0; i <= snowmax; i++) {
    document.write("<span id='s" + i + "' style='position:absolute;z-index:-3;top:-" + snowmaxsize + "px;'>" + snowletter + "</span>");
}
    window.onload = initsnow;