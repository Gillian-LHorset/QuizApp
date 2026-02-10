DROP DATABASE IF EXISTS db_quizapp;
CREATE DATABASE db_quizapp;

USE db_quizapp;

CREATE TABLE t_question (
    question_id INT NOT NULL AUTO_INCREMENT,
    theme VARCHAR(59) NOT NULL,
    enonce VARCHAR(109) NOT NULL,
    reponse_correcte VARCHAR(159) NOT NULL,
    reponse_fausse_1 VARCHAR(159) NOT NULL,
    reponse_fausse_2 VARCHAR(159) NOT NULL,
    reponse_fausse_3 VARCHAR(159) NOT NULL,
    PRIMARY KEY(question_id)
);

CREATE TABLE t_player(
   player_id INT NOT NULL AUTO_INCREMENT,
   player_name VARCHAR(51) NOT NULL,
   meilleur_score INT NOT NULL DEFAULT 0,
   PRIMARY KEY(player_id)
);

INSERT INTO t_question  (theme,                 enonce,                     reponse_correcte,               reponse_fausse_1,                       reponse_fausse_2,                       reponse_fausse_3)
            VALUES      ('theme : questions',   'quelle est la question',   'la réponse à la question',     'la fausse réponse à la question 1 ?',  'la fausse réponse à la question 2 ?',  'la fausse réponse à la question 3 ?' );

INSERT INTO t_player    (player_name)
            VALUES      ('Gillian');
