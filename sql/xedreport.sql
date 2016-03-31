/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : xedreport

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2016-03-04 17:13:38
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `report_report`
-- ----------------------------
DROP TABLE IF EXISTS `report_report`;
CREATE TABLE `report_report` (
  `reportname` varchar(15) NOT NULL,
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `u_id` int(10) NOT NULL,
  `year` varchar(4) DEFAULT NULL,
  `month` varchar(2) DEFAULT NULL,
  `frequentness` text,
  `updatetime` int(10) DEFAULT NULL,
  `path` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=449 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of report_report
-- ----------------------------
INSERT INTO `report_report` VALUES ('ZCFZ', '448', '18', '2016', '08', '8', '1457074949', '2016-03-04/18-2016-08-8ZCFZ.zip');
INSERT INTO `report_report` VALUES ('LR', '444', '18', '2015', '12', '0', '1456986225', '2016-03-03/18-2015-12-0LR.zip');
INSERT INTO `report_report` VALUES ('LR', '447', '18', '2016', '06', '2', '1457058278', '2016-03-04/18-2016-06-2LR.zip');

-- ----------------------------
-- Table structure for `report_user`
-- ----------------------------
DROP TABLE IF EXISTS `report_user`;
CREATE TABLE `report_user` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `type` tinyint(3) NOT NULL,
  `updatetime` int(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of report_user
-- ----------------------------
INSERT INTO `report_user` VALUES ('1', 'admin', '21218cca77804d2ba1922c33e0151105', '1', '1453143916');
INSERT INTO `report_user` VALUES ('18', 'test', 'f379eaf3c831b04de153469d1bec345e', '2', '1456813120');

-- ----------------------------
-- Table structure for `report_user_set`
-- ----------------------------
DROP TABLE IF EXISTS `report_user_set`;
CREATE TABLE `report_user_set` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `u_id` varchar(255) DEFAULT NULL,
  `organizationcode` char(4) DEFAULT NULL COMMENT '机构类代码',
  `areascode` char(7) DEFAULT NULL COMMENT '地区代码',
  `institutioncode` char(14) DEFAULT NULL COMMENT '标准化机构编码',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of report_user_set
-- ----------------------------
INSERT INTO `report_user_set` VALUES ('2', '4', 'j204', '1111111', '12345678901234');
INSERT INTO `report_user_set` VALUES ('3', '2', 'JA01', '0001112', '41230123456789');
INSERT INTO `report_user_set` VALUES ('4', '5', 'j020', '4401041', 'Z1167444000014');
INSERT INTO `report_user_set` VALUES ('5', '13', '1234', '0000000', '01234567891234');
INSERT INTO `report_user_set` VALUES ('6', '18', 'j020', '4401041', 'Z1167444000014');
