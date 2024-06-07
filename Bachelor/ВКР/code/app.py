# Module for data manipulation:
import pandas as pd

# Function for unpackaging pipeline:
from joblib import load

# The class to get time
from datetime import datetime

# Functions for working with web API:
from flask import Flask, request, render_template

# Create application:
app = Flask(__name__)

# PAGE № 1 #


# The main page:
@app.route("/")  # Delete after
@app.route("/home")
@app.route("/index")
@app.route("/homepage")
@app.route("/home_page")
def home():
    global language

    if language == "chinese":
        return render_template("home_ch.html")
    elif language == "english":
        return render_template("home_en.html")
    elif language == "russian":
        return render_template("home_ru.html")


# The feedback page:
@app.route("/report")
@app.route("/message")
@app.route("/feedback")
def report():
    global language

    if language == "chinese":
        return render_template("report_ch.html")
    elif language == "english":
        return render_template("report_en.html")
    elif language == "russian":
        return render_template("report_ru.html")


# The feedback page:
@app.route("/status", methods=["POST"])
@app.route("/report_status", methods=["POST"])
def report_status():
    global language

    with open("other/reports.txt", "w") as file:
        file.seek(0, 2)
        file.write(':'.join(str(datetime.now()).split(':')[:-1]) + " - " + request.form["message"])

    if language == "chinese":
        return render_template("report_status_ch.html")
    elif language == "english":
        return render_template("report_status_en.html")
    elif language == "russian":
        return render_template("report_status_ru.html")


# The settings page (get - to open page, post - to change settings):
@app.route("/options", methods=["POST", "GET"])
@app.route("/settings", methods=["POST", "GET"])
@app.route("/customization", methods=["POST", "GET"])
@app.route("/configuration", methods=["POST", "GET"])
def options():
    global language, theme

    if request.method == "POST":
        if request.form["theme"] == "light":
            theme = "light"
        elif request.form["theme"] == "dark":
            theme = "dark"

        if request.form["language"] == "chinese":
            language = "chinese"

            return render_template("options_ch.html")
        elif request.form["language"] == "english":
            language = "english"

            return render_template("options_en.html")
        elif request.form["language"] == "russian":
            language = "russian"

            return render_template("options_ru.html")

    elif request.method == "GET":
        if language == "chinese":
            return render_template("options_ch.html")
        elif language == "english":
            return render_template("options_en.html")
        elif language == "russian":
            return render_template("options_ru.html")


# The author page:
@app.route("/about")
@app.route("/about_us")
@app.route("/about_author")
def about():
    global language

    if language == "chinese":
        return render_template("about_ch.html")
    elif language == "english":
        return render_template("about_en.html")
    elif language == "russian":
        return render_template("about_ru.html")


# PAGE № 2 #

# The form page:
@app.route("/form")
@app.route("/survey")
@app.route("/questions")
@app.route("/user_survey")
@app.route("/questionnaire")
def form():
    global language

    if language == "chinese":
        return render_template("form_ch.html")
    elif language == "english":
        return render_template("form_en.html")
    elif language == "russian":
        return render_template("form_ru.html")


# The result page:
@app.route("/final", methods=["POST"])
@app.route("/result", methods=["POST"])
@app.route("/prediction", methods=["POST"])
@app.route("/final_page", methods=["POST"])
@app.route("/result_page", methods=["POST"])
@app.route("/prediction_page", methods=["POST"])
def final():
    global language

    # The user data from form:
    user_data = {

        # The user characteristic data:
        "Ваш пол:": [request.form["gender"]],
        "Ваш возраст:": [int(request.form["age"])],

        # The user personal data:
        "Сколько часов в день Вы спите:": [int(request.form["sleep"])],
        "Насколько Вы тревожны по учебё:": [int(request.form["anxiety"])],
        "Как бы Вы охарактеризовали Вашу самооценку:": [int(request.form["self"])],
        "Насколько Вы считаете себя усердным в учёбе:": [int(request.form["diligence"])],
        "Насколько Вы общительны в [группе/потоке]:": [int(request.form["sociability"])],
        "Есть ли у Вас на постоянной основе физическая активность:": [request.form["activity"]],
        "Какое место в Вашей жизни занимают развлечения:": [int(request.form["entertainments"])],
        "Насколько Вы уведомлены о происходящем в [мире/стране]:": [int(request.form["awareness"])],
        "Насколько вы удовлетворены выбранным Вами направлением:": [int(request.form["satisfaction"])],
        "Имеется ли соревновательная черта в Вашем учебном процессе:": [request.form["competitiveness"]],
        "Как Вы оцениваете качество образования в Вашем учебном заведении:": [int(request.form["quality"])],
        "Насколько Вы мотивированы учиться в Вашем высшем учебном заведении:":
            [int(request.form["motivation"])],
        "Как Вы считаете, знания получаемые в Вашем высшем учебном заведении [помогут/помогли] Вам с трудоустройством:": [request.form["usefulness"]],

        # The user professional skills:
        "Вы работаете?": [request.form["job"]],
        "Ваш средний балл в школе:": [int(request.form["score"])],
        "На каком курсе Вы обучаетесь:": [int(request.form["course"])],
        "Средние баллы по ЕГЭ при поступлении:": [int(request.form["points"])],
        "Имели ли Вы успех в участиях в олимпиадах:": [request.form["success"]],
        "Сколько часов (в неделю) Вы уделяете учёбе:": [int(request.form["education"])],
        "Насколько для Вас важно следующее (отсрочка от армии, наличии диплома, как документа, и т. д.):":
            [int(request.form["importance"])],

        # The external data:
        "Доход Вашей семьи (в рублях):": [request.form["income"]],
        "Регион Вашего учебного заведения:": [request.form["region"]],
        "Сколько бюджетных мест на Вашем направлении:": [int(request.form["places"])],
        "Наличие высшего образования у Ваших родственников:": [request.form["availability"]],
        "Насколько Ваше направление престижное и востребованное:": [int(request.form["prestige"])],
        "Насколько Вам удобно следить за Вашей успеваемостью:": [int(request.form["convenience"])],
        "Мнение Ваших родственников о необходимости высшего образования:": [int(request.form["necessity"])]
    }

    # Make prediction by the pipeline:
    prediction = model.predict(pd.DataFrame(user_data))

    prediction = int(prediction)

    # Show the results on the new page:
    if language == "chinese":
        return render_template("final_ch.html", prediction=prediction)
    elif language == "english":
        return render_template("final_en.html", prediction=prediction)
    elif language == "russian":
        return render_template("final_ru.html", prediction=prediction)


if __name__ == "__main__":
    # The theme of the website:
    theme = "light"

    # Default language of the site:
    language = "russian"

    # Pipeline loading:
    model = load("models/pipeline.joblib")

    # Launching the application:
    app.run(debug=False)
