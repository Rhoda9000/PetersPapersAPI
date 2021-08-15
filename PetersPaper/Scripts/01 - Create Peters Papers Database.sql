USE [master]
GO

/****** Object:  Database [peters_papers]    Script Date: 2021/08/16 18:31:59 ******/
CREATE DATABASE [peters_papers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'peters_papers', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\peters_papers.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'peters_papers_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\peters_papers_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [peters_papers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [peters_papers] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [peters_papers] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [peters_papers] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [peters_papers] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [peters_papers] SET ARITHABORT OFF 
GO

ALTER DATABASE [peters_papers] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [peters_papers] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [peters_papers] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [peters_papers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [peters_papers] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [peters_papers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [peters_papers] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [peters_papers] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [peters_papers] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [peters_papers] SET  DISABLE_BROKER 
GO

ALTER DATABASE [peters_papers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [peters_papers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [peters_papers] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [peters_papers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [peters_papers] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [peters_papers] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [peters_papers] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [peters_papers] SET RECOVERY FULL 
GO

ALTER DATABASE [peters_papers] SET  MULTI_USER 
GO

ALTER DATABASE [peters_papers] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [peters_papers] SET DB_CHAINING OFF 
GO

ALTER DATABASE [peters_papers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [peters_papers] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [peters_papers] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [peters_papers] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [peters_papers] SET QUERY_STORE = OFF
GO

ALTER DATABASE [peters_papers] SET  READ_WRITE 
GO
