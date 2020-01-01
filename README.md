# Manufacturing Execution System (MES) Automation
 
This is the Manufacturing Execution System without Sensors. You can add/update/delete for Operators who are employees of the Factory. You can also add/update/delete customers,machines on factory.

To use this program, you have to create tables of databases.


Database name: MAS2019

USE [MAS2019]
GO

/****** Object:  Table [dbo].[Admin]    Script Date: 1.01.2020 22:53:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](30) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[Ad] [nvarchar](20) NOT NULL,
	[Soyad] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [MAS2019]
GO

/****** Object:  Table [dbo].[AdminSistemRaporu]    Script Date: 1.01.2020 22:54:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdminSistemRaporu](
	[SistemID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [int] NOT NULL,
	[SistemeGirisTarihi] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminSistemRaporu] PRIMARY KEY CLUSTERED 
(
	[SistemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AdminSistemRaporu]  WITH CHECK ADD  CONSTRAINT [FK_AdminSistemRaporu_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO

ALTER TABLE [dbo].[AdminSistemRaporu] CHECK CONSTRAINT [FK_AdminSistemRaporu_Admin]
GO




USE [MAS2019]
GO

/****** Object:  Table [dbo].[AliciTablosu]    Script Date: 1.01.2020 22:54:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AliciTablosu](
	[AliciID] [int] IDENTITY(1,1) NOT NULL,
	[AliciAD] [nvarchar](max) NOT NULL,
	[AliciSirketNO] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AliciTablosu] PRIMARY KEY CLUSTERED 
(
	[AliciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




USE [MAS2019]
GO

/****** Object:  Table [dbo].[DurusRaporTablosu]    Script Date: 1.01.2020 22:54:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DurusRaporTablosu](
	[RaporID] [int] IDENTITY(1,1) NOT NULL,
	[DurusID] [int] NOT NULL,
	[OperatorID] [int] NOT NULL,
	[DurusBaslangicTarihi] [datetime] NOT NULL,
	[DurusBitisTarihi] [datetime] NOT NULL,
 CONSTRAINT [PK_DurusRaporTablosu] PRIMARY KEY CLUSTERED 
(
	[RaporID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DurusRaporTablosu]  WITH CHECK ADD  CONSTRAINT [FK_DurusRaporTablosu_DurusTablosu] FOREIGN KEY([DurusID])
REFERENCES [dbo].[DurusTablosu] ([DurusID])
GO

ALTER TABLE [dbo].[DurusRaporTablosu] CHECK CONSTRAINT [FK_DurusRaporTablosu_DurusTablosu]
GO

ALTER TABLE [dbo].[DurusRaporTablosu]  WITH CHECK ADD  CONSTRAINT [FK_DurusRaporTablosu_Operator] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
GO

ALTER TABLE [dbo].[DurusRaporTablosu] CHECK CONSTRAINT [FK_DurusRaporTablosu_Operator]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[DurusTablosu]    Script Date: 1.01.2020 22:54:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DurusTablosu](
	[DurusID] [int] IDENTITY(1,1) NOT NULL,
	[DurusAd] [nvarchar](50) NOT NULL,
	[DurusAciklama] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_DurusTablosu] PRIMARY KEY CLUSTERED 
(
	[DurusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [MAS2019]
GO

/****** Object:  Table [dbo].[MakinelerTablosu]    Script Date: 1.01.2020 22:54:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MakinelerTablosu](
	[MakineID] [int] IDENTITY(1,1) NOT NULL,
	[MakineAdi] [nvarchar](max) NOT NULL,
	[MakineKodu] [nvarchar](max) NOT NULL,
	[OperasyonID] [int] NOT NULL,
 CONSTRAINT [PK_MakinelerTablosu] PRIMARY KEY CLUSTERED 
(
	[MakineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[MakinelerTablosu]  WITH CHECK ADD  CONSTRAINT [FK_MakinelerTablosu_OperasyonlarTablosu] FOREIGN KEY([OperasyonID])
REFERENCES [dbo].[OperasyonlarTablosu] ([OperasyonID])
GO

ALTER TABLE [dbo].[MakinelerTablosu] CHECK CONSTRAINT [FK_MakinelerTablosu_OperasyonlarTablosu]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[OperasyonlarTablosu]    Script Date: 1.01.2020 22:54:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OperasyonlarTablosu](
	[OperasyonID] [int] IDENTITY(1,1) NOT NULL,
	[OperasyonAdi] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OperasyonlarTablosu] PRIMARY KEY CLUSTERED 
(
	[OperasyonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[Operator]    Script Date: 1.01.2020 22:54:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Operator](
	[OperatorID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](30) NULL,
	[Soyad] [nvarchar](30) NULL,
	[TCKimlik] [nvarchar](11) NULL,
	[DogumTarihi] [datetime] NULL,
	[SicilNo] [nvarchar](30) NULL,
	[IseBaslangicTarihi] [datetime] NULL,
	[IstenCikisTarihi] [datetime] NULL,
	[DurumAP] [bit] NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[PlanTablosu]    Script Date: 1.01.2020 22:54:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlanTablosu](
	[PlanID] [int] IDENTITY(1,1) NOT NULL,
	[SiparisID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[IsEmriNo] [nvarchar](50) NOT NULL,
	[MakinaID] [int] NOT NULL,
	[AliciID] [int] NOT NULL,
	[IsEmriAdeti] [int] NOT NULL,
 CONSTRAINT [PK_PlanTablosu] PRIMARY KEY CLUSTERED 
(
	[PlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlanTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PlanTablosu_AliciTablosu] FOREIGN KEY([AliciID])
REFERENCES [dbo].[AliciTablosu] ([AliciID])
GO

ALTER TABLE [dbo].[PlanTablosu] CHECK CONSTRAINT [FK_PlanTablosu_AliciTablosu]
GO

ALTER TABLE [dbo].[PlanTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PlanTablosu_MakinelerTablosu] FOREIGN KEY([MakinaID])
REFERENCES [dbo].[MakinelerTablosu] ([MakineID])
GO

ALTER TABLE [dbo].[PlanTablosu] CHECK CONSTRAINT [FK_PlanTablosu_MakinelerTablosu]
GO

ALTER TABLE [dbo].[PlanTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PlanTablosu_SiparisTablosu] FOREIGN KEY([SiparisID])
REFERENCES [dbo].[SiparisTablosu] ([SiparisID])
GO

ALTER TABLE [dbo].[PlanTablosu] CHECK CONSTRAINT [FK_PlanTablosu_SiparisTablosu]
GO

ALTER TABLE [dbo].[PlanTablosu]  WITH CHECK ADD  CONSTRAINT [FK_PlanTablosu_UrunTablosu] FOREIGN KEY([UrunID])
REFERENCES [dbo].[UrunTablosu] ([UrunID])
GO

ALTER TABLE [dbo].[PlanTablosu] CHECK CONSTRAINT [FK_PlanTablosu_UrunTablosu]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[Rapor]    Script Date: 1.01.2020 22:55:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rapor](
	[RaporID] [int] IDENTITY(1,1) NOT NULL,
	[ToplamSiparis] [int] NULL,
	[ToplamUretim] [int] NULL,
	[ToplamNet] [int] NULL,
	[OrtalamaSiparis] [int] NULL,
	[OrtalamaUretim] [int] NULL,
	[ToplamHurda] [int] NULL,
	[OrtalamaHurda] [int] NULL,
	[OrtalamaPerformans] [int] NULL,
	[BaslangicTarih] [datetime] NULL,
	[BitisTarih] [datetime] NOT NULL,
 CONSTRAINT [PK_Rapor] PRIMARY KEY CLUSTERED 
(
	[RaporID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[SiparisTablosu]    Script Date: 1.01.2020 22:55:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SiparisTablosu](
	[SiparisID] [int] IDENTITY(1,1) NOT NULL,
	[AliciID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Miktar] [int] NOT NULL,
	[IstedigiTarih] [datetime] NOT NULL,
	[TeslimTarihi] [datetime] NULL,
 CONSTRAINT [PK_SiparisTablosu] PRIMARY KEY CLUSTERED 
(
	[SiparisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SiparisTablosu]  WITH CHECK ADD  CONSTRAINT [FK_SiparisTablosu_AliciTablosu] FOREIGN KEY([AliciID])
REFERENCES [dbo].[AliciTablosu] ([AliciID])
GO

ALTER TABLE [dbo].[SiparisTablosu] CHECK CONSTRAINT [FK_SiparisTablosu_AliciTablosu]
GO

ALTER TABLE [dbo].[SiparisTablosu]  WITH CHECK ADD  CONSTRAINT [FK_SiparisTablosu_UrunTablosu] FOREIGN KEY([UrunID])
REFERENCES [dbo].[UrunTablosu] ([UrunID])
GO

ALTER TABLE [dbo].[SiparisTablosu] CHECK CONSTRAINT [FK_SiparisTablosu_UrunTablosu]
GO



USE [MAS2019]
GO

/****** Object:  Table [dbo].[UretimRapor]    Script Date: 1.01.2020 22:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UretimRapor](
	[KeyID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NULL,
	[AliciID] [int] NULL,
	[OperatorID] [int] NULL,
	[SiparisID] [int] NULL,
	[MakineID] [int] NULL,
	[PlanID] [int] NULL,
	[BaslamaTarihi] [datetime] NULL,
	[BitisTarihi] [datetime] NULL,
	[SiparisAdet] [int] NULL,
	[UretimAdet] [int] NULL,
	[HurdaAdet] [int] NULL,
 CONSTRAINT [PK_IsEmriRapor] PRIMARY KEY CLUSTERED 
(
	[KeyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UretimRapor]  WITH CHECK ADD  CONSTRAINT [FK_UretimRapor_AliciTablosu] FOREIGN KEY([AliciID])
REFERENCES [dbo].[AliciTablosu] ([AliciID])
GO

ALTER TABLE [dbo].[UretimRapor] CHECK CONSTRAINT [FK_UretimRapor_AliciTablosu]
GO

ALTER TABLE [dbo].[UretimRapor]  WITH CHECK ADD  CONSTRAINT [FK_UretimRapor_MakinelerTablosu] FOREIGN KEY([MakineID])
REFERENCES [dbo].[MakinelerTablosu] ([MakineID])
GO

ALTER TABLE [dbo].[UretimRapor] CHECK CONSTRAINT [FK_UretimRapor_MakinelerTablosu]
GO

ALTER TABLE [dbo].[UretimRapor]  WITH CHECK ADD  CONSTRAINT [FK_UretimRapor_Operator] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
GO

ALTER TABLE [dbo].[UretimRapor] CHECK CONSTRAINT [FK_UretimRapor_Operator]
GO

ALTER TABLE [dbo].[UretimRapor]  WITH CHECK ADD  CONSTRAINT [FK_UretimRapor_PlanTablosu] FOREIGN KEY([PlanID])
REFERENCES [dbo].[PlanTablosu] ([PlanID])
GO

ALTER TABLE [dbo].[UretimRapor] CHECK CONSTRAINT [FK_UretimRapor_PlanTablosu]
GO

ALTER TABLE [dbo].[UretimRapor]  WITH CHECK ADD  CONSTRAINT [FK_UretimRapor_SiparisTablosu] FOREIGN KEY([SiparisID])
REFERENCES [dbo].[SiparisTablosu] ([SiparisID])
GO

ALTER TABLE [dbo].[UretimRapor] CHECK CONSTRAINT [FK_UretimRapor_SiparisTablosu]
GO

ALTER TABLE [dbo].[UretimRapor]  WITH CHECK ADD  CONSTRAINT [FK_UretimRapor_UrunTablosu] FOREIGN KEY([UrunID])
REFERENCES [dbo].[UrunTablosu] ([UrunID])
GO

ALTER TABLE [dbo].[UretimRapor] CHECK CONSTRAINT [FK_UretimRapor_UrunTablosu]
GO


USE [MAS2019]
GO

/****** Object:  Table [dbo].[UrunTablosu]    Script Date: 1.01.2020 22:55:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UrunTablosu](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](50) NOT NULL,
	[UrunAciklama] [nvarchar](max) NULL,
	[UrunKodu] [nvarchar](max) NOT NULL,
	[En] [float] NOT NULL,
	[Boy] [float] NOT NULL,
 CONSTRAINT [PK_UrunTablosu] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




