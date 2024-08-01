CREATE DATABASE  IF NOT EXISTS `bd_crm` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bd_crm`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: bd_crm
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `t_candidato`
--

DROP TABLE IF EXISTS `t_candidato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_candidato` (
  `id_candidato` int unsigned NOT NULL AUTO_INCREMENT,
  `nom_candidato` varchar(50) NOT NULL,
  `des_email` varchar(50) DEFAULT NULL,
  `num_telefone` varchar(15) NOT NULL,
  `num_cpf` varchar(14) NOT NULL,
  PRIMARY KEY (`id_candidato`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_candidato`
--

LOCK TABLES `t_candidato` WRITE;
/*!40000 ALTER TABLE `t_candidato` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_candidato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_curso`
--

DROP TABLE IF EXISTS `t_curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_curso` (
  `id_curso` int unsigned NOT NULL AUTO_INCREMENT,
  `nom_curso` varchar(50) NOT NULL,
  `des_curso` varchar(255) NOT NULL,
  `num_vagas` int unsigned NOT NULL,
  PRIMARY KEY (`id_curso`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_curso`
--

LOCK TABLES `t_curso` WRITE;
/*!40000 ALTER TABLE `t_curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_inscricao`
--

DROP TABLE IF EXISTS `t_inscricao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_inscricao` (
  `id_inscricao` int unsigned NOT NULL AUTO_INCREMENT,
  `num_inscricao` varchar(16) NOT NULL,
  `dt_inscricao` datetime NOT NULL,
  `tag_status` tinyint unsigned NOT NULL DEFAULT '1',
  `id_candidato` int unsigned NOT NULL,
  `id_processo` int unsigned NOT NULL,
  `id_curso` int unsigned NOT NULL,
  PRIMARY KEY (`id_inscricao`),
  KEY `t_inscricao_fk0_idx` (`id_candidato`),
  KEY `t_inscricao_fk1_idx` (`id_processo`),
  KEY `t_inscricao_fk2_idx` (`id_curso`),
  CONSTRAINT `t_inscricao_fk0` FOREIGN KEY (`id_candidato`) REFERENCES `t_candidato` (`id_candidato`) ON DELETE RESTRICT,
  CONSTRAINT `t_inscricao_fk1` FOREIGN KEY (`id_processo`) REFERENCES `t_processo` (`id_processo`) ON DELETE RESTRICT,
  CONSTRAINT `t_inscricao_fk2` FOREIGN KEY (`id_curso`) REFERENCES `t_curso` (`id_curso`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_inscricao`
--

LOCK TABLES `t_inscricao` WRITE;
/*!40000 ALTER TABLE `t_inscricao` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_inscricao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_processo`
--

DROP TABLE IF EXISTS `t_processo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_processo` (
  `id_processo` int unsigned NOT NULL AUTO_INCREMENT,
  `nom_processo` varchar(50) NOT NULL,
  `dt_inicio` date NOT NULL,
  `dt_termino` date NOT NULL,
  PRIMARY KEY (`id_processo`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_processo`
--

LOCK TABLES `t_processo` WRITE;
/*!40000 ALTER TABLE `t_processo` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_processo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'bd_crm'
--

--
-- Dumping routines for database 'bd_crm'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-07-31 19:57:17
