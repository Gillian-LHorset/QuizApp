DROP DATABASE IF EXISTS db_quizapp;
CREATE DATABASE db_quizapp;
USE db_quizapp;



CREATE TABLE t_question(
   question_id INT AUTO_INCREMENT,
   label VARCHAR(51),
   correcte_answert VARCHAR(71),
   false_answert1 VARCHAR(71),
   false_answert2 VARCHAR(71),
   false_answert3 VARCHAR(71),
   PRIMARY KEY(question_id)
);

CREATE TABLE t_player(
   player_id INT AUTO_INCREMENT,
   player_name VARCHAR(51),
   PRIMARY KEY(player_id)
);