CREATE SCHEMA `dotnet_webapi` ;

CREATE TABLE `dotnet_webapi`.`location_master` (
  `location_id` INT NOT NULL AUTO_INCREMENT,
  `location_cd` VARCHAR(5) NOT NULL,
  `location_name` VARCHAR(45) NOT NULL,
  `is_delete` BIT(1) NOT NULL DEFAULT b'0',
  `is_active` BIT(1) NOT NULL DEFAULT b'1',
  `created_by` INT NOT NULL DEFAULT 0,
  `created_on` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_by` INT NULL,
  `modified_on` DATETIME NULL,
  PRIMARY KEY (`location_id`));

CREATE TABLE `dotnet_webapi`.`shift_master` (
  `shift_id` INT NOT NULL AUTO_INCREMENT,
  `shift_cd` VARCHAR(5) NOT NULL,
  `shift_name` VARCHAR(45) NOT NULL,
  `is_delete` BIT(1) NOT NULL DEFAULT b'0',
  `is_active` BIT(1) NOT NULL DEFAULT b'1',
  `created_by` INT NOT NULL DEFAULT 0,
  `created_on` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_by` INT NULL,
  `modified_on` DATETIME NULL,
  PRIMARY KEY (`shift_id`));

CREATE TABLE `dotnet_webapi`.`wage_master` (
  `wage_id` INT NOT NULL AUTO_INCREMENT,
  `wage_cd` VARCHAR(5) NOT NULL,
  `wage_name` VARCHAR(45) NOT NULL,
  `is_delete` BIT(1) NOT NULL DEFAULT b'0',
  `is_active` BIT(1) NOT NULL DEFAULT b'1',
  `created_by` INT NOT NULL DEFAULT 0,
  `created_on` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_by` INT NULL,
  `modified_on` DATETIME NULL,
  PRIMARY KEY (`wage_id`));

CREATE TABLE `dotnet_webapi`.`designation_master` (
  `designation_id` INT NOT NULL AUTO_INCREMENT,
  `designation_cd` VARCHAR(5) NOT NULL,
  `designation_name` VARCHAR(45) NOT NULL,
  `is_delete` BIT(1) NOT NULL DEFAULT b'0',
  `is_active` BIT(1) NOT NULL DEFAULT b'1',
  `created_by` INT NOT NULL DEFAULT 0,
  `created_on` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_by` INT NULL,
  `modified_on` DATETIME NULL,
  PRIMARY KEY (`designation_id`));

CREATE TABLE `dotnet_webapi`.`user_master` (
  `user_id` INT NOT NULL AUTO_INCREMENT,
  `user_name` VARCHAR(45) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `employee_id` VARCHAR(45) DEFAULT NULL,
  `employee_name` VARCHAR(45) DEFAULT NULL,
  `user_role` VARCHAR(1) DEFAULT 'E',
  `email` VARCHAR(100) DEFAULT NULL,
  `mobile` VARCHAR(10) DEFAULT NULL,
  `address` VARCHAR(500) DEFAULT NULL,
  `user_status` bit(1) NOT NULL DEFAULT b'1',
  `suspended` bit(1) NOT NULL DEFAULT b'0',
  `last_login_dttm` DATETIME DEFAULT NULL,
  `password_change_dttm` DATETIME DEFAULT NULL,
  `failed_attempts` INT DEFAULT NULL,
  `failed_attempt_dttm` DATETIME DEFAULT NULL,
  `is_delete` BIT(1) NOT NULL DEFAULT b'0',
  `is_active` BIT(1) NOT NULL DEFAULT b'1',
  `created_by` INT NOT NULL DEFAULT 0,
  `created_on` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_by` INT NULL,
  `modified_on` DATETIME NULL,
  PRIMARY KEY (`user_id`));
