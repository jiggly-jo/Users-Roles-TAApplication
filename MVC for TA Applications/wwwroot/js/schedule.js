// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let bg_color = 0xabcdef;
let rect_color = 0x6F8FAF;
let highlighted_color = 0xffebcd;
let width = 900;
let height = 800;

var mouse_down = false;
var boxHighlighted = new Array(240).fill(false);
var boxesChanged = [];
var app = null;
var slots = [];


    app = new PIXI.Application(width, height, { backgroundColor: 0x000000 })
    app.renderer.resize(width, height);

    $("#canvas_div").append(app.view);
    //monday 
var counter = 0;

    for (let i = 1; i <= 48; i++) {
        counter++;
        slots[i - 1] = build_square(i, 50, counter);
  
    }
    //tuesday
    counter = 0;
    for (let i = 49; i <= 96; i++) {
        counter++;
        slots[i - 1] = build_square(i, 200, counter);
        
    }
    //wednesday
    counter = 0;
    for (let i = 97; i <= 144; i++) {
        counter++;
        slots[i - 1] = build_square(i, 350, counter);
    }
    //thursday
    counter = 0;
    for (let i = 145; i <= 192; i++) {
        counter++;
        slots[i - 1] = build_square(i, 500, counter);
    }
    //friday
    counter = 0;
    for (let i = 193; i <= 240; i++) {
        counter++;
        slots[i - 1] = build_square(i, 650, counter);

    }
counter = 0;

var line = new PIXI.Graphics();
line.beginFill(0xFFFFFF)
line.drawRect(0, 0, 1000, 2);
line.x = 50;
line.y = 65;
app.stage.addChild(line);

for (let i = 1; i <= 48; i++) {
    counter++;
    if (i % 4 == 0) {

        line = new PIXI.Graphics();
        line.beginFill(0xFFFFFF)
        line.drawRect(0, 0, 1000, 2);
        line.x = 50;
        line.y = (50 + 15 * counter) + 15;
        app.stage.addChild(line);

    }
}
var timeText = new PIXI.Text('8 am', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 45);
timeText = new PIXI.Text('9 am', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 100);

timeText = new PIXI.Text('10 am', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 160);

timeText = new PIXI.Text('11 am', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 220);

timeText = new PIXI.Text('12 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 280);

timeText = new PIXI.Text('1 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 340);

timeText = new PIXI.Text('2 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 400);

timeText = new PIXI.Text('3 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 460);

timeText = new PIXI.Text('4 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 520);

timeText = new PIXI.Text('5 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 580);

timeText = new PIXI.Text('6 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 640);

timeText = new PIXI.Text('7 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 700);

timeText = new PIXI.Text('8 pm', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(timeText, 800, 760);

var text = new PIXI.Text('Monday', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(text, 50, 25);
text = new PIXI.Text('Tuesday', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(text, 200, 25);
text = new PIXI.Text('Wednesday', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(text, 350, 25);
text = new PIXI.Text('Thursday', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(text, 500, 25);
text = new PIXI.Text('Friday', { fontFamily: 'Arial', fontSize: 20, fill: "white", align: 'center' });
add_text(text, 650, 25);

function add_text(text,x, y)
{
    text.x = x;
    text.y = y;
    app.stage.addChild(text);
}
function build_square(id,x,counter) {
    var square = new PIXI.Graphics();
    square.beginFill(rect_color);

    square.drawRect(0, 0, 100, 15);
    square.x = x;
    square.y = 50 + 15 * counter;
    square.interactive = true;
    square.id = id;

    app.stage.addChild(square);

    square.on('mousedown', pointer_down);
    square.on('mouseover', pointer_over);
    square.on('mouseup', pointer_up);

    return square;
}

function pointer_down() {
    change_data_indicator(false);
    console.log(`I am square ${this.id}`);
    this.clear();
    if (boxHighlighted[this.id - 1] == false) {
        color = highlighted_color;
        boxHighlighted[this.id - 1] = true;
    }
    else {
        boxHighlighted[this.id - 1] = false;
        color = rect_color;
    }
    this.beginFill(color);
    this.drawRect(0, 0, 100, 15);
    mouse_down = true;
}

function pointer_up() {
    console.log("pointer up");
    mouse_down = false;
}

function call_Set_Schedule() {
    Set_Schedule(boxHighlighted);
}

function pointer_over() {
    console.log(`I am square ${this.id}`);
    if (mouse_down == true) {
        if (boxHighlighted[this.id - 1] == false) {
            color = highlighted_color;
            boxHighlighted[this.id - 1] = true;
        }
        else {
            boxHighlighted[this.id - 1] = false;
            color = rect_color;
        }
        this.beginFill(color);
        this.drawRect(0, 0, 100, 15);
    }
}

function fillIn(s) {
    var loc = 0;
    var s1 = s.split(' ');
    var s2 = s1[1].split(':');

    if (s1[0] == "Tuesday")
        loc = 48;
    else if (s1[0] == "Wednesday")
        loc = 48 * 2;
    else if (s1[0] == "Thursday")
        loc = 48 * 3;
    else if (s1[0] == "Friday")
        loc = 48 * 4;

    loc += (parseInt(s2[0]) - 8) * 4;

    loc += Math.floor((parseInt(s2[1]) / 15));

    boxHighlighted[loc] = true;
    slots[loc].beginFill(highlighted_color);
    slots[loc].drawRect(0, 0, 100, 15);
}

//change save data indicator
function change_data_indicator(saved_bool) {
    if (!saved_bool) {
        document.getElementById("save_data_indicator").innerHTML = "New Data Unsaved";
    } else {
        document.getElementById("save_data_indicator").innerHTML = "";
    }

}
//set schedule function
function Set_Schedule(boxHighlighted) {
    var URL = "/Availability/SetSchedule";
    var DATA = { slots: boxHighlighted };

    $.post(URL, DATA)
        .done(function (result) {
            Swal.fire(
                'Edit Sucessful!',
                '',
                'success'
            )
            change_data_indicator(true);
        })
        .fail(function (result) {
            Swal.fire(
                'Edit Failed!',
                '',
                'error'
            )
        })
        .always(function () {
            $("aspinner").hide();
        });
}