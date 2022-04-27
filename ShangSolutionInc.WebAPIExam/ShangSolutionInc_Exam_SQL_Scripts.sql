USE [master]
GO
/****** Object:  Database [ClientA]    Script Date: 4/27/2022 9:51:02 AM ******/
CREATE DATABASE [ClientA]

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClientA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClientA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClientA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClientA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClientA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClientA] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClientA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClientA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClientA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClientA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClientA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClientA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClientA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClientA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClientA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClientA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClientA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClientA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClientA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClientA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClientA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClientA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClientA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClientA] SET RECOVERY FULL 
GO
ALTER DATABASE [ClientA] SET  MULTI_USER 
GO
ALTER DATABASE [ClientA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClientA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClientA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClientA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClientA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClientA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ClientA', N'ON'
GO
ALTER DATABASE [ClientA] SET QUERY_STORE = OFF
GO
USE [ClientA]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/27/2022 9:51:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (1, N'adams.baker', N'Adams', N'Baker', N'Alabama')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (2, N'davis.evans', N'Davis', N'Evans', N'Alaska')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (3, N'frank.ghosh', N'Frank', N'Ghosh', N'Arizona')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (4, N'hills.irwin', N'Hills', N'Irwin', N'Arkansas')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (5, N'jones.klein', N'Jones', N'Klein', N'California')
GO
/****** Object:  StoredProcedure [dbo].[AddUser_sp]    Script Date: 4/27/2022 9:51:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser_sp]
	@UserId int
	, @Username nvarchar(50)
	, @FirstName nvarchar(50)
	, @LastName nvarchar(50)
	, @State nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO Users([UserId], [Username], [Firstname], [Lastname], [State]) VALUES(@UserId,@Username,@FirstName,@LastName,@State)

	SELECT 1 AS BIT
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser_sp]    Script Date: 4/27/2022 9:51:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser_sp]
	  @UserId nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM Users WHERE [UserId] = @UserId

	SELECT 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers_sp]    Script Date: 4/27/2022 9:51:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUsers_sp]

AS
BEGIN

	SET NOCOUNT ON;

    SELECT [UserId],[Username],[Firstname],[Lastname],[State] FROM Users
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_sp]    Script Date: 4/27/2022 9:51:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser_sp]
	  @UserId nvarchar(50)
	, @Username nvarchar(50)
	, @FirstName nvarchar(50)
	, @LastName nvarchar(50)
	, @State nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [Users] SET [Username] = @Username, [Firstname] = @FirstName, [Lastname] = @LastName, [State] = @State WHERE [UserId] = @UserId

	SELECT 1
END
GO
USE [master]
GO
ALTER DATABASE [ClientA] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [ClientB]    Script Date: 4/27/2022 9:57:50 AM ******/
CREATE DATABASE [ClientB]

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClientB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClientB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClientB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClientB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClientB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClientB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClientB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClientB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClientB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClientB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClientB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClientB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClientB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClientB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClientB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClientB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClientB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClientB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClientB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClientB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClientB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClientB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClientB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClientB] SET RECOVERY FULL 
GO
ALTER DATABASE [ClientB] SET  MULTI_USER 
GO
ALTER DATABASE [ClientB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClientB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClientB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClientB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClientB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClientB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ClientB', N'ON'
GO
ALTER DATABASE [ClientB] SET QUERY_STORE = OFF
GO
USE [ClientB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/27/2022 9:57:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (1, N'mason.nalty', N'Mason', N'Nalty', N'Alabama')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (2, N'ochoa.patel', N'Ochoa', N'Patel', N'Alaska')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (3, N'quinn.reily', N'Quinn', N'Reily', N'Arizona')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (4, N'smith.trott', N'Smith', N'Trott', N'Arkansas')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (5, N'usman.valdo', N'Usman', N'Valdo', N'California')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Firstname], [Lastname], [State]) VALUES (7, N'asd', N'Firstname', N'Lastname', N'Clevelandasdasdasd')
GO
/****** Object:  StoredProcedure [dbo].[AddUser_sp]    Script Date: 4/27/2022 9:57:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser_sp]
	@UserId int
	, @Username nvarchar(50)
	, @FirstName nvarchar(50)
	, @LastName nvarchar(50)
	, @State nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO Users([UserId], [Username], [Firstname], [Lastname], [State]) VALUES(@UserId,@Username,@FirstName,@LastName,@State)

	SELECT 1 AS BIT
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser_sp]    Script Date: 4/27/2022 9:57:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser_sp]
	  @UserId nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    DELETE FROM Users WHERE [UserId] = @UserId

	SELECT 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers_sp]    Script Date: 4/27/2022 9:57:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUsers_sp]

AS
BEGIN

	SET NOCOUNT ON;

    SELECT [UserId],[Username],[Firstname],[Lastname],[State] FROM Users
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_sp]    Script Date: 4/27/2022 9:57:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser_sp]
	  @UserId nvarchar(50)
	, @Username nvarchar(50)
	, @FirstName nvarchar(50)
	, @LastName nvarchar(50)
	, @State nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE [Users] SET [Username] = @Username, [Firstname] = @FirstName, [Lastname] = @LastName, [State] = @State WHERE [UserId] = @UserId

	SELECT 1
END
GO
USE [master]
GO
ALTER DATABASE [ClientB] SET  READ_WRITE 
GO
