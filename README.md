# QuizApp
QuizApp is an application, create with WPF, where you can play to some quiz. 

## How to use ?
For use this application you need a database MYSQL.
The server have this characteristics : host in localhost in the port 6033. The user have the login and the password is "root". The database need to be named "db_quizapp" with two tables : "t_player" and "t_question".\

You can change the connexion in the file "App.config" ("QuizApp.dll.config" if your project is build).

#### t_player :

The table t_player need to be construct like this :\
player_id - int, auto-increment, id\
player_name - varchar(51)\
meilleur_score - int, default value 0

#### t_question

The table t_question need to be construct like this :\
question_id - int, auto-increment, id\
theme - varchar(59)\
enonce - varchar(109)\
reponse_correcte - varchar(159)\
reponse_fausse_1 - varchar(159)\
reponse_fausse_2 - varchar(159)\
reponse_fausse_3 - varchar(159)\
reponse_fausse_4 - varchar(159)

The database can be import from the file **"DB/db-creator.sql"**.