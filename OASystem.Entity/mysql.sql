CREATE TABLE `users` (
    id int not null auto_increment,
    `username` varchar(80) not null,
    `password` binary(80) not null,
    name varchar(50) not null,
	phone_number varchar(50) default null,
	identification_number varchar(50) default null,
	avatar mediumtext not null,
	department_id default null,
    `role` tinyint not null,
    primary key (id),
    unique index (`username`)
)  default charset=utf8;

