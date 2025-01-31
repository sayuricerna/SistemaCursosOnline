USE [master]
GO
/****** Object:  Database [SistemaCursosOnline]    Script Date: 1/31/2025 11:31:18 AM ******/
CREATE DATABASE [SistemaCursosOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaCursosOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SistemaCursosOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaCursosOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SistemaCursosOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SistemaCursosOnline] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaCursosOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaCursosOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaCursosOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaCursosOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SistemaCursosOnline] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaCursosOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaCursosOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaCursosOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaCursosOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaCursosOnline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SistemaCursosOnline] SET QUERY_STORE = ON
GO
ALTER DATABASE [SistemaCursosOnline] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SistemaCursosOnline]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombreCurso] [nvarchar](20) NOT NULL,
	[descripcion] [nvarchar](100) NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NULL,
	[idProfesor] [int] NOT NULL,
	[nombreProfesor] [nvarchar](50) NULL,
 CONSTRAINT [PK__Curso__5D3F7502E05C4F68] PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[telefono] [nvarchar](10) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[direccion] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Profesor__159ED6178273283F] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Profesor__415B7BE5D7B8E9CA] UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Profesor__AB6E6164FDE14C9E] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vistaCursoConProfesor]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vistaCursoConProfesor] AS
SELECT 
    c.IdCurso, 
    c.NombreCurso, 
    c.Descripcion, 
    c.FechaInicio, 
    c.FechaFin, 
    c.IdProfesor, 
    p.Nombre AS NombreProfesor
FROM Curso c
INNER JOIN Profesor p ON c.IdProfesor = p.IdProfesor;
GO
/****** Object:  Table [dbo].[Inscripcion]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripcion](
	[idInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
	[fechaInscripcion] [datetime] NOT NULL,
 CONSTRAINT [PK__Inscripc__CB0117BA9DEDAE9C] PRIMARY KEY CLUSTERED 
(
	[idInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](30) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[telefono] [nvarchar](10) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[direccion] [nvarchar](50) NULL,
 CONSTRAINT [PK__Estudian__E0B2763C11F3460E] PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Estudian__415B7BE51512500C] UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Estudian__AB6E616412958DA8] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vistaInscripciones]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vistaInscripciones] AS
SELECT 
    i.IdInscripcion,
    i.IdEstudiante,  
    c.IdCurso,     
    e.Nombre AS NombreEstudiante,
    e.Cedula AS CedulaEstudiante,
    c.NombreCurso,
    i.FechaInscripcion
FROM 
    Inscripcion i
INNER JOIN 
    Estudiante e ON i.IdEstudiante = e.IdEstudiante
INNER JOIN 
    Curso c ON i.IdCurso = c.IdCurso;
GO
/****** Object:  View [dbo].[ReporteCursosPorEstudiante]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Vista para reportes de cursos inscritos por estudiante
CREATE VIEW [dbo].[ReporteCursosPorEstudiante] AS
SELECT 
    e.id_estudiante,
    e.nombre AS nombre_estudiante,
    e.email,
    c.id_curso,
    c.nombre_curso,
    i.fecha_inscripcion
FROM Inscripcion i
JOIN Estudiante e ON i.id_estudiante = e.id_estudiante
JOIN Curso c ON i.id_curso = c.id_curso;
GO
/****** Object:  View [dbo].[VistaCursos]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaCursos] AS
SELECT c.IdCurso, c.NombreCurso, c.Descripcion, c.FechaInicio, c.FechaFin, p.Nombre AS NombreProfesor
FROM Curso c
INNER JOIN Profesor p ON c.IdProfesor = p.IdProfesor;
GO
ALTER TABLE [dbo].[Inscripcion] ADD  CONSTRAINT [DF__Inscripci__fecha__4222D4EF]  DEFAULT (getdate()) FOR [fechaInscripcion]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Profesor] FOREIGN KEY([idProfesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Profesor]
GO
/****** Object:  StoredProcedure [dbo].[BuscarCursosPorEstudiante]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para buscar cursos inscritos por estudiante
CREATE PROCEDURE [dbo].[BuscarCursosPorEstudiante]
    @id_estudiante INT
AS
BEGIN
    SELECT 
        c.id_curso,
        c.nombre_curso,
        c.descripcion,
        c.fecha_inicio,
        c.fecha_fin,
        p.nombre AS profesor
    FROM Inscripcion i
    JOIN Curso c ON i.id_curso = c.id_curso
    JOIN Profesor p ON c.id_profesor = p.id_profesor
    WHERE i.id_estudiante = @id_estudiante;
END;
GO
/****** Object:  StoredProcedure [dbo].[FilterByStudentCedula]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FilterByStudentCedula]
    @CedulaEstudiante VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        e.Nombre AS NombreEstudiante,
        e.Cedula AS CedulaEstudiante,
        c.IdCurso,
        c.NombreCurso,
        c.Descripcion,
        c.FechaInicio,
        c.FechaFin,
        p.Nombre AS NombreProfesor,
        i.FechaInscripcion
    FROM Inscripcion i
    INNER JOIN Estudiante e ON i.IdEstudiante = e.IdEstudiante
    INNER JOIN Curso c ON i.IdCurso = c.IdCurso
    INNER JOIN Profesor p ON c.IdProfesor = p.IdProfesor
    WHERE e.Cedula = @CedulaEstudiante;
END;
GO
/****** Object:  StoredProcedure [dbo].[FilterByStudentName]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FilterByStudentName]
    @NombreEstudiante VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        e.Nombre AS NombreEstudiante,
        e.Cedula AS CedulaEstudiante,
        c.IdCurso,
        c.NombreCurso,
        c.Descripcion,
        c.FechaInicio,
        c.FechaFin,
        p.Nombre AS NombreProfesor,
        i.FechaInscripcion
    FROM Inscripcion i
    INNER JOIN Estudiante e ON i.IdEstudiante = e.IdEstudiante
    INNER JOIN Curso c ON i.IdCurso = c.IdCurso
    INNER JOIN Profesor p ON c.IdProfesor = p.IdProfesor
    WHERE e.Nombre LIKE '%' + @NombreEstudiante + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerNombreProfesorPorCurso]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerNombreProfesorPorCurso]
    @IdCurso INT
AS
BEGIN
    SELECT p.NombreProfesor
    FROM Cursos c
    JOIN Profesores p ON c.IdProfesor = p.IdProfesor
    WHERE c.IdCurso = @IdCurso;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CursosPorEstudiante]    Script Date: 1/31/2025 11:31:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CursosPorEstudiante] (@idEstudiante INT)
AS
BEGIN
    SELECT 
        e.idEstudiante,
        e.nombre AS nombreEstudiante,
        c.idCurso,
        c.nombreCurso,
        c.descripcion,
        c.fechaInicio,
        c.fechaFin,
        p.idProfesor,
        p.nombre AS nombreProfesor,
        p.email AS emailProfesor,
        i.fechaInscripcion
    FROM Inscripcion i
    JOIN Estudiante e ON i.idEstudiante = e.idEstudiante
    JOIN Curso c ON i.idCurso = c.idCurso
    JOIN Profesor p ON c.idProfesor = p.idProfesor
    WHERE e.idEstudiante = @idEstudiante;
END;
GO
USE [master]
GO
ALTER DATABASE [SistemaCursosOnline] SET  READ_WRITE 
GO
