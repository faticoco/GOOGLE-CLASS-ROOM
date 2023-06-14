use fp;

create database fp;
Create table Teacher(
t_id INT IDENTITY(1,1) PRIMARY KEY,
name varchar(60)not null,
email varchar(60)not null,
password varchar(60)not null
)
create table Student(
S_id INT IDENTITY(1,1) PRIMARY KEY,
name varchar(60) not null,
email varchar(60)not null unique,
password varchar(60)not null,
)
create table class(
Class_id INT IDENTITY(1,1) PRIMARY KEY,
name varchar(60) not null,
Class_code varchar(60) not null unique,
)

create table teaches_class(
class_id int not null,
teacher_id int not null,
Foreign key (class_id) references class on delete cascade on update cascade,
Foreign key(teacher_id) references Teacher on delete cascade on update cascade,
Primary key(class_id,teacher_id)
)
create table enrolled_in(
class_id int not null,
student_id int not null,
Foreign key (class_id) references class on delete cascade on update cascade,
Foreign key(student_id) references Student on delete cascade on update cascade,
Primary key(class_id,student_id)
)	
Create table Announcement(
id INT IDENTITY(1,1) PRIMARY KEY,
announcement_text varchar(60),
a_date Date not null,
a_time Time not null,
class_id int not null,
announcer_id int not null,
announcer_type varchar(10) not null,
Foreign key (class_id) references class on delete cascade on update cascade,
)
Create table Assignment(
id INT IDENTITY(1,1) PRIMARY KEY,
assignment_number int,
assignment_text varchar(60),
attachment varchar(2000),
class_id int not null,
teacher_id int not null,
Foreign key(teacher_id) references Teacher,
Foreign key (class_id) references class on delete cascade on update cascade,
Deadline Datetime,
marks int 
)
Create table Material(
id INT IDENTITY(1,1) PRIMARY KEY,
attachment varchar(2000),
description varchar(2000),
class_id int not null,
teacher_id int not null,
Foreign key(teacher_id) references Teacher ,
Foreign key (class_id) references class on delete cascade on update cascade,
a_date Date not null,
a_time Time not null,
)

Create table Submission(
Student_id int not null,
A_id int not null,
sub_time Datetime,
marks int,
attachment varchar(max),
Primary key(student_id,A_id),
Foreign key(student_id) references Student ,
Foreign key(A_id) references Assignment on delete cascade on update cascade,
)

Create table AsComment(
id INT IDENTITY(1,1) PRIMARY KEY,
A_id int not null,
announcer_id int not null,
announcer_type varchar(10) not null,
com_time DATETIME,
text varchar(100),
Foreign key(A_id) references Assignment on delete cascade on update cascade
)

Create table AComment(
id INT IDENTITY(1,1) PRIMARY KEY,
A_id int not null,
announcer_id int not null,
announcer_type varchar(10) not null,
com_time DATETIME,
text varchar(100),
Foreign key(A_id) references Announcement on delete cascade on update cascade
)
Create table MComment(
id INT IDENTITY(1,1) PRIMARY KEY,
A_id int not null,
announcer_id int not null,
announcer_type varchar(10) not null,
com_time DATETIME,
text varchar(100),
Foreign key(A_id) references Material on delete cascade on update cascade
)
