drop table if exists `departments`;
drop table if exists `users`;
drop table if exists `user_logs`;
drop table if exists `sign_logs`;
drop table if exists `events`;
drop table if exists `messages`;
drop table if exists `uploads`;
drop table if exists `schedules`;

CREATE TABLE `departments` (
    id int not null auto_increment,
    `title` varchar(80) not null,
	`description` mediumtext default null,
    primary key (id),
    unique index (`title`)
)  default charset=utf8;

CREATE TABLE `users` (
    id int not null auto_increment,
    `username` varchar(80) not null,
    `password` binary(20) not null,
    name varchar(50) not null,
	phone_number varchar(50) default null,
	avatar mediumblob default null,
	department_id int default null,
    `role` tinyint not null,
    primary key (id),
	foreign key (department_id)
		references departments (id)
		on delete cascade,
    unique index (`username`)
)  default charset=utf8;

CREATE TABLE `user_logs`(
    id int not null auto_increment,
	user_id int not null,
	`time` datetime not null,
	`content` mediumtext not null,
	foreign key (user_id)
		references users (id)
		on delete cascade,
    primary key (id)
)  default charset=utf8;

CREATE TABLE `sign_logs`(
    id int not null auto_increment,
	user_id int not null,
	`time` datetime not null,
	`type` tinyint not null,
	foreign key (user_id)
		references users (id)
		on delete cascade,
    primary key (id)
)  default charset=utf8;

CREATE TABLE `events`(
    id int not null auto_increment,
	`user_id` int not null,
	manager_id int not null,
	root_id int not null,
	`time` datetime not null,
	`type` tinyint not null,
	`title` varchar(120) not null,
	`content` mediumtext default null,
	foreign key (user_id)
		references users (id)
		on delete cascade,
	foreign key (manager_id)
		references users (id)
		on delete cascade,
	foreign key (root_id)
		references users (id)
		on delete cascade,
    primary key (id)
)  default charset=utf8;

CREATE TABLE `messages`(
    id int not null auto_increment,
	from_user_id int not null,
	to_user_id int not null,
	`time` datetime not null,
	`title` varchar(120) not null,
	`content` mediumtext default null,
	foreign key (from_user_id)
		references users (id)
		on delete cascade,
	foreign key (to_user_id)
		references users (id)
		on delete cascade,
    primary key (id)
)  default charset=utf8;

CREATE TABLE `uploads`(
    id int not null auto_increment,
	user_id int not null,
	`time` datetime not null,
	`type` tinyint not null,
	`filename` varchar(120) not null,
	`file` longblob default null,
	`size` int not null,
	`time` datetime not null,
	foreign key (user_id)
		references users (id)
		on delete cascade,
    primary key (id)
)  default charset=utf8;

CREATE TABLE `schedules`(
    id int not null auto_increment,
	submittion_user_id int not null,
	to_user_id int default null,
	`time` datetime not null,
	`title` varchar(120) not null,
	`content` mediumtext default null,
	department_id int default null,
	foreign key (submittion_user_id)
		references users (id)
		on delete cascade,
	foreign key (to_user_id)
		references users (id)
		on delete cascade,
	foreign key (department_id)
		references departments (id)
		on delete cascade,
    primary key (id)
)  default charset=utf8;

INSERT INTO users (`username`,`name`,`password`,role) values ('admin','admin',unhex(sha1('admin')),2);