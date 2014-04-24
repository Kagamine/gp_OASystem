/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50536
Source Host           : localhost:3306
Source Database       : oasystem

Target Server Type    : MYSQL
Target Server Version : 50536
File Encoding         : 65001

Date: 2014-04-24 18:35:12
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for departments
-- ----------------------------
DROP TABLE IF EXISTS `departments`;
CREATE TABLE `departments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(80) NOT NULL,
  `description` mediumtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of departments
-- ----------------------------
INSERT INTO `departments` VALUES ('1', '财务部', '负责财务的管理');
INSERT INTO `departments` VALUES ('2', '信息部', '负责公司网络的管理');

-- ----------------------------
-- Table structure for events
-- ----------------------------
DROP TABLE IF EXISTS `events`;
CREATE TABLE `events` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `root_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `title` text NOT NULL,
  `content` text,
  `status` int(11) NOT NULL DEFAULT '0',
  `feedback` text,
  PRIMARY KEY (`id`),
  KEY `root_id` (`root_id`),
  CONSTRAINT `events_ibfk_1` FOREIGN KEY (`root_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of events
-- ----------------------------
INSERT INTO `events` VALUES ('1', '1', '2014-04-24 17:45:45', '今天加班', '今天加班', '0', '好');

-- ----------------------------
-- Table structure for files
-- ----------------------------
DROP TABLE IF EXISTS `files`;
CREATE TABLE `files` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `file_name` varchar(255) NOT NULL,
  `time` datetime NOT NULL,
  `user_id` int(10) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `files_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of files
-- ----------------------------
INSERT INTO `files` VALUES ('2', 'vgroup.xml', '2014-04-22 18:23:32', '1');
INSERT INTO `files` VALUES ('3', 'log.dll', '2014-04-22 23:42:25', '2');

-- ----------------------------
-- Table structure for messages
-- ----------------------------
DROP TABLE IF EXISTS `messages`;
CREATE TABLE `messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `from_user_id` int(11) NOT NULL,
  `to_user_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `title` varchar(120) NOT NULL,
  `content` mediumtext,
  PRIMARY KEY (`id`),
  KEY `from_user_id` (`from_user_id`),
  KEY `to_user_id` (`to_user_id`),
  CONSTRAINT `messages_ibfk_1` FOREIGN KEY (`from_user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE,
  CONSTRAINT `messages_ibfk_2` FOREIGN KEY (`to_user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of messages
-- ----------------------------

-- ----------------------------
-- Table structure for schedules
-- ----------------------------
DROP TABLE IF EXISTS `schedules`;
CREATE TABLE `schedules` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `submittion_user_id` int(11) NOT NULL,
  `to_user_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `title` varchar(255) NOT NULL,
  `content` mediumtext,
  `department_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `submittion_user_id` (`submittion_user_id`),
  KEY `to_user_id` (`to_user_id`),
  KEY `department_id` (`department_id`),
  CONSTRAINT `schedules_ibfk_1` FOREIGN KEY (`submittion_user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `schedules_ibfk_2` FOREIGN KEY (`to_user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `schedules_ibfk_3` FOREIGN KEY (`department_id`) REFERENCES `departments` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of schedules
-- ----------------------------
INSERT INTO `schedules` VALUES ('4', '1', '2', '2014-04-18 22:40:58', '五一加班', '由于的工作的需要，五一需要加班；', '2');
INSERT INTO `schedules` VALUES ('5', '1', '2', '2014-04-18 22:49:30', '周末不放假', '由于有事，周末不放假', '2');

-- ----------------------------
-- Table structure for sign_logs
-- ----------------------------
DROP TABLE IF EXISTS `sign_logs`;
CREATE TABLE `sign_logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `type` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `sign_logs_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sign_logs
-- ----------------------------
INSERT INTO `sign_logs` VALUES ('1', '2', '2014-04-18 23:13:19', '0');
INSERT INTO `sign_logs` VALUES ('2', '1', '2014-04-19 00:03:48', '0');
INSERT INTO `sign_logs` VALUES ('5', '1', '2014-04-22 14:47:18', '1');
INSERT INTO `sign_logs` VALUES ('6', '1', '2014-04-22 16:35:44', '0');

-- ----------------------------
-- Table structure for uploads
-- ----------------------------
DROP TABLE IF EXISTS `uploads`;
CREATE TABLE `uploads` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `type` tinyint(4) NOT NULL,
  `filename` varchar(120) NOT NULL,
  `file` longblob,
  `size` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `uploads_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of uploads
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(80) NOT NULL,
  `password` binary(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `phone_number` varchar(50) DEFAULT NULL,
  `avatar` mediumblob,
  `department_id` int(11) DEFAULT NULL,
  `role` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `department_id` (`department_id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `departments` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('1', 'admin', 0xD033E22AE348AEB5660FC2140AEC35850C4DA997, 'admin', null, null, '1', '2');
INSERT INTO `users` VALUES ('2', 'nele', 0x7C4A8D09CA3762AF61E59520943DC26494F8941B, 'nele', null, null, '2', '0');
INSERT INTO `users` VALUES ('3', 'lele', 0x7C4A8D09CA3762AF61E59520943DC26494F8941B, 'lele', null, null, '2', '0');

-- ----------------------------
-- Table structure for user_logs
-- ----------------------------
DROP TABLE IF EXISTS `user_logs`;
CREATE TABLE `user_logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `content` mediumtext NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `user_logs_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user_logs
-- ----------------------------
