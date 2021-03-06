USE [master]
GO

/****** Object:  Database [MeritDB]    Script Date: 2021-04-13 17:57:00 ******/
DROP DATABASE [MeritDB]
GO

/****** Object:  Database [MeritDB]    Script Date: 2021-04-13 17:57:00 ******/
CREATE DATABASE [MeritDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MeritDB', FILENAME = N'C:\Users\Micke\MeritDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MeritDB_log', FILENAME = N'C:\Users\Micke\MeritDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MeritDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MeritDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MeritDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MeritDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MeritDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MeritDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [MeritDB] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [MeritDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MeritDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MeritDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MeritDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MeritDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MeritDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MeritDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MeritDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MeritDB] SET  ENABLE_BROKER 
GO

ALTER DATABASE [MeritDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MeritDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MeritDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MeritDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MeritDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MeritDB] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [MeritDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MeritDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MeritDB] SET  MULTI_USER 
GO

ALTER DATABASE [MeritDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MeritDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MeritDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MeritDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MeritDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MeritDB] SET QUERY_STORE = OFF
GO

USE [MeritDB]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [MeritDB] SET  READ_WRITE 
GO

