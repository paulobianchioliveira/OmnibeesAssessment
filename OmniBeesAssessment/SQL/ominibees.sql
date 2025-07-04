USE [master]
GO
/****** Object:  Database [Omnibees]    Script Date: 02/07/2025 14:27:23 ******/
CREATE DATABASE [Omnibees]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Omnibees', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Omnibees.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Omnibees_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Omnibees_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Omnibees] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Omnibees].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Omnibees] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Omnibees] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Omnibees] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Omnibees] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Omnibees] SET ARITHABORT OFF 
GO
ALTER DATABASE [Omnibees] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Omnibees] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Omnibees] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Omnibees] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Omnibees] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Omnibees] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Omnibees] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Omnibees] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Omnibees] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Omnibees] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Omnibees] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Omnibees] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Omnibees] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Omnibees] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Omnibees] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Omnibees] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Omnibees] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Omnibees] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Omnibees] SET  MULTI_USER 
GO
ALTER DATABASE [Omnibees] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Omnibees] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Omnibees] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Omnibees] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Omnibees] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Omnibees] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Omnibees] SET QUERY_STORE = ON
GO
ALTER DATABASE [Omnibees] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Omnibees]
GO
/****** Object:  Table [dbo].[Cotacao]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataAtualizacao] [datetime] NOT NULL,
	[IdParceiro] [int] NOT NULL,
	[NomeSegurado] [varchar](50) NOT NULL,
	[DDD] [smallint] NULL,
	[Telefone] [int] NULL,
	[Endereco] [varchar](50) NOT NULL,
	[CEP] [varchar](50) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[Nascimento] [date] NOT NULL,
	[Premio] [decimal](10, 2) NOT NULL,
	[ImportanciaSegurada] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Cotacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CotacaoBeneficiario]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotacaoBeneficiario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCotacao] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Percentual] [decimal](5, 2) NOT NULL,
	[IdParentesco] [smallint] NOT NULL,
 CONSTRAINT [PK_CotacaoBeneficiario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[FK_Key] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[BaseValue] [decimal](10, 2) NULL,
	[Limit] [decimal](10, 2) NULL,
	[Minimum] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[FK_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CotacaoCobertura]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotacaoCobertura](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCotacao] [int] NOT NULL,
	[IdCobertura] [int] NOT NULL,
	[ValorDesconto] [decimal](10, 2) NULL,
	[ValorAgravo] [decimal](10, 2) NULL,
	[ValorTotal] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_CotacaoCobertura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_COTACAO]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[V_COTACAO](IdParceiro,IdCotacao,NomeSegurado,Endereco,CEP,DDD,Telefone,Nascimento,Premio,ImportanciaSegurada,IdProduto,Produto,BaseValue,Documento)
as
select c.IdParceiro,c.Id IdCotacao,c.NomeSegurado,c.Endereco,c.CEP,c.DDD,c.Telefone,c.Nascimento,(BaseValue+(select isnull(sum(ValorTotal),0) from CotacaoCobertura where IdCotacao=id)) Premio ,c.ImportanciaSegurada,c.IdProduto,p.Description Produto,p.BaseValue,c.Documento
from Cotacao c left join CotacaoBeneficiario b on (c.Id=b.IdCotacao)
left join Produto p on (p.FK_Key=c.IdProduto);
GO
/****** Object:  Table [dbo].[TipoParentesco]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoParentesco](
	[FK_Key] [smallint] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoParentesco] PRIMARY KEY CLUSTERED 
(
	[FK_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_CotacaoBeneficiario]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[V_CotacaoBeneficiario](IdCotacao,Nome,Percentual,Parentesco)
as
select IdCotacao,Nome,Percentual,p.Description Parentesco from CotacaoBeneficiario b join TipoParentesco p on (b.IdParentesco=p.FK_Key);
GO
/****** Object:  Table [dbo].[Cobertura]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobertura](
	[FK_Key] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Value] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Cobertura] PRIMARY KEY CLUSTERED 
(
	[FK_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_CotacaoCobertura]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   view [dbo].[V_CotacaoCobertura](IdCotacao,ValorAgravo,ValorDesconto,ValorTotal,Description,Type,Value)
as
select c.Id IdCotacao,isnull(cb.ValorAgravo,0) ValorAgravo,isnull(cb.ValorDesconto,0) ValorDesconto,isnull(cb.ValorTotal,0) ValorTotal,isnull(cob.Description,'') Description,isnull(cob.Type,'') type,cob.Value 
from Cotacao c left join CotacaoCobertura cb on (c.id=cb.IdCotacao) left join Cobertura cob on (cb.IdCobertura=cob.FK_Key)
GO
/****** Object:  Table [dbo].[FaixaIdade]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaixaIdade](
	[Key] [smallint] NOT NULL,
	[Description] [varchar](50) NULL,
	[Desconto] [decimal](10, 2) NULL,
	[Agravo] [decimal](10, 2) NULL,
	[BaseValue] [smallint] NOT NULL,
	[Limit] [smallint] NOT NULL,
 CONSTRAINT [PK_FaixaIdade] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parceiro]    Script Date: 02/07/2025 14:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parceiro](
	[FK_Key] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[User] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Secret] [varchar](50) NULL,
 CONSTRAINT [PK_Parceiro] PRIMARY KEY CLUSTERED 
(
	[FK_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_CotacaoCobertura]    Script Date: 02/07/2025 14:27:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CotacaoCobertura] ON [dbo].[CotacaoCobertura]
(
	[IdCobertura] ASC,
	[IdCotacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Parceiro]    Script Date: 02/07/2025 14:27:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Parceiro] ON [dbo].[Parceiro]
(
	[User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cotacao]  WITH CHECK ADD  CONSTRAINT [FK_Cotacao_Parceiro] FOREIGN KEY([IdParceiro])
REFERENCES [dbo].[Parceiro] ([FK_Key])
GO
ALTER TABLE [dbo].[Cotacao] CHECK CONSTRAINT [FK_Cotacao_Parceiro]
GO
ALTER TABLE [dbo].[Cotacao]  WITH CHECK ADD  CONSTRAINT [FK_Cotacao_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([FK_Key])
GO
ALTER TABLE [dbo].[Cotacao] CHECK CONSTRAINT [FK_Cotacao_Produto]
GO
ALTER TABLE [dbo].[CotacaoBeneficiario]  WITH CHECK ADD  CONSTRAINT [FK_CotacaoBeneficiario_Cotacao] FOREIGN KEY([Id])
REFERENCES [dbo].[Cotacao] ([Id])
GO
ALTER TABLE [dbo].[CotacaoBeneficiario] CHECK CONSTRAINT [FK_CotacaoBeneficiario_Cotacao]
GO
ALTER TABLE [dbo].[CotacaoBeneficiario]  WITH CHECK ADD  CONSTRAINT [FK_CotacaoBeneficiario_TipoParentesco] FOREIGN KEY([IdParentesco])
REFERENCES [dbo].[TipoParentesco] ([FK_Key])
GO
ALTER TABLE [dbo].[CotacaoBeneficiario] CHECK CONSTRAINT [FK_CotacaoBeneficiario_TipoParentesco]
GO
ALTER TABLE [dbo].[CotacaoCobertura]  WITH CHECK ADD  CONSTRAINT [FK_CotacaoCobertura_Cobertura] FOREIGN KEY([IdCobertura])
REFERENCES [dbo].[Cobertura] ([FK_Key])
GO
ALTER TABLE [dbo].[CotacaoCobertura] CHECK CONSTRAINT [FK_CotacaoCobertura_Cobertura]
GO
ALTER TABLE [dbo].[CotacaoCobertura]  WITH CHECK ADD  CONSTRAINT [FK_CotacaoCobertura_Cotacao] FOREIGN KEY([IdCotacao])
REFERENCES [dbo].[Cotacao] ([Id])
GO
ALTER TABLE [dbo].[CotacaoCobertura] CHECK CONSTRAINT [FK_CotacaoCobertura_Cotacao]
GO
USE [master]
GO
ALTER DATABASE [Omnibees] SET  READ_WRITE 
GO
