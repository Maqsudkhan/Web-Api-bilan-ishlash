-- create table courses(
--     course_id serial primary key,
--     course_name varchar(60),
--     teacher_id int,
--     price decimal,
--     descriptions text,
--     students_count int 
-- );

-- create table teachers(
--     teacher_id serial primary key,
--     full_name varchar(80),
--     age int,
--     salary decimal,
--     phone_number varchar(30),
--     groups_count int, 
--     experience int
-- );

-- create table students(
--     student_id serial primary key,
--     full_name varchar(80),
--     age int,
--     course_id int,
--     phone_number varchar(30),
--     parents_phone_number varchar(30),
--     shot_number decimal
-- )

-- alter table courses add constraint courses_teacher_id_foreign foreign key(teacher_id) references teachers(teacher_id);  
-- alter table students add constraint student_coure_id_foreign foreign key(course_id) references courses(course_id);  