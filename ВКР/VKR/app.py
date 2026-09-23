# Module for data manipulation
import pandas as pd

# Function for unpackaging pipeline
from joblib import load

# Functions for working with web API
from flask import Flask, render_template, request, redirect

# Create application
app = Flask(__name__)


# PAGE № 1

# The main page
@app.route("/home")
@app.route("/index")
@app.route("/homepage")
@app.route("/home_page")
def home():
    return render_template("home.html")


# The feedback page
@app.route("/report")
@app.route("/message")
@app.route("/feedback")
def report():
    return render_template("report.html")


# The settings page
@app.route("/options")
@app.route("/settings")
@app.route("/customization")
@app.route("/configuration")
def options():
    return render_template("options.html")


# The author page
@app.route("/about")
@app.route("/about_us")
@app.route("/about_author")
def about():
    return render_template("about.html")


# PAGE № 2

# The form page
@app.route("/form")
@app.route("/survey")
@app.route("/user_survey", methods=["POST", "GET"])
@app.route("/questionnaire", methods=["POST", "GET"])
def form():
    if request.method == "POST":
        numbers = request.form['NAME']
        predict = model.predict(pd.DataFrame([numbers]))
        return redirect('/')
    else:
        return render_template("form.html")


# The page of data form
@app.route("/result", methods=['POST', "GET"])
def result():
    if request.method == 'POST':
        data = {
            "Ваш пол:": [request.form["gender"]], "Ваш возраст:": [int(request.form["age"])],
            "Сколько часов в день Вы спите:": [int(request.form["sleep"])],
            "Есть ли у Вас на постоянной основе физическая активность:": [request.form["physic"]],
            "Какое место в Вашей жизни занимают развлечения:": [int(request.form["walking"])],
            "Насколько Вы уведомлены о происходящем в [мире/стране]:": [int(request.form["news"])],
            "Насколько Вы общительны в [группе/потоке]:": [int(request.form["friendly"])],
            "Как бы Вы охарактеризовали Вашу самооценку:": [int(request.form["self"])],
            "Имеется ли соревновательная черта в Вашем учебном процессе:": [request.form["rank"]],
            "Насколько вы удовлетворены выбранным Вами направлением:": [int(request.form["applied"])],
            "Как Вы оцениваете качество образования в Вашем учебном заведении:": [int(request.form["quality"])],
            "Как Вы считаете, знания получаемые в Вашем высшем учебном заведении [помогут/помогли] Вам с "
            + "трудоустройством:": [request.form["knowledge"]],
            "Насколько Вы мотивированы учиться в Вашем высшем учебном заведении:": [int(request.form["motivation"])],
            "Насколько Вы тревожны по учебё:": [int(request.form["stress"])],
            "Вы работаете?": [request.form["working"]],
            "Насколько Вы считаете себя усердным в учёбе:": [int(request.form["hard"])],
            "На каком курсе Вы обучаетесь:": [int(request.form["course"])],
            "Ваш средний балл в школе:": [int(request.form["school"])],
            "Имели ли Вы успех в участиях в олимпиадах:": [request.form["olymp"]],
            "Средние баллы по ЕГЭ при поступлении:": [int(request.form["ege"])],
            "Сколько часов (в неделю) Вы уделяете учёбе:": [int(request.form["hours"])],
            "Насколько для Вас важно следующее (отсрочка от армии, наличии диплома, как документа, и т. д.):":
                [int(request.form["price"])],
            "Сколько бюджетных мест на Вашем направлении:": [int(request.form["places"])],
            "Регион Вашего учебного заведения:": [request.form["region"]],
            "Насколько Ваше направление престижное и востребованное:": [int(request.form["side"])],
            "Насколько Вам удобно следить за Вашей успеваемостью:": [int(request.form["monitoring"])],
            "Доход Вашей семьи (в рублях):": [request.form["payment"]],
            "Мнение Ваших родственников о необходимости высшего образования:": [int(request.form["parents"])],
            "Наличие высшего образования у Ваших родственников:": [request.form["relation"]]
        }
        predict = float(model.predict(pd.DataFrame(data)))

        return render_template('/result.html', predict=predict)
    else:
        return render_template("form.html")


if __name__ == "__main__":
    model = load("models/pipeline.joblib")
    app.run(debug=True)
