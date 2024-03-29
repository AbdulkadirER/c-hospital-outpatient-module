USE [PoliklinikDefteri]
GO
/****** Object:  Table [dbo].[Doktorlar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doktorlar](
	[DoktorId] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
	[Soyad] [varchar](50) NULL,
	[DogumTarihi] [date] NULL,
	[Cinsiyet] [varchar](10) NULL,
	[Email] [varchar](100) NULL,
	[Telefon] [varchar](50) NULL,
	[Klinik] [int] NULL,
	[KullaniciAdi] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
 CONSTRAINT [PK_Doktorlar] PRIMARY KEY CLUSTERED 
(
	[DoktorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eklenenİlaclar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eklenenİlaclar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[İlac_Adı] [varchar](450) NULL,
	[Kullanim_Sekli] [varchar](150) NULL,
	[Kac_Kez] [varchar](50) NULL,
	[Kac_Doz] [varchar](50) NULL,
	[Kutu] [varchar](50) NULL,
	[Periyod] [varchar](50) NULL,
	[Periyod_Birim] [varchar](150) NULL,
	[Ac_Tok] [varchar](50) NULL,
	[Rapor_Durum] [varchar](150) NULL,
	[Aciklama] [varchar](250) NULL,
	[Tarih] [date] NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_Eklenenİlaclar_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HastaBulgusu]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HastaBulgusu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Bulgusu] [varchar](150) NULL,
	[Aciklama] [varchar](250) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_HastaBulgusu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HastaKabul]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HastaKabul](
	[DosyaNo] [int] NOT NULL,
	[TcNo] [varchar](11) NULL,
	[Ad] [varchar](40) NULL,
	[Soyad] [varchar](40) NULL,
	[GelisNedeni] [varchar](250) NULL,
	[GelisTarihi] [date] NULL,
	[Sikayeti] [varchar](250) NULL,
	[Poliklinik] [int] NOT NULL,
 CONSTRAINT [PK_HastaKabul] PRIMARY KEY CLUSTERED 
(
	[DosyaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastalar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastalar](
	[DosyaNo] [int] IDENTITY(1,1) NOT NULL,
	[TcNo] [varchar](11) NOT NULL,
	[Ad] [varchar](40) NULL,
	[Soyad] [varchar](40) NULL,
	[DogumTarih] [date] NULL,
	[DogumYeri] [varchar](50) NULL,
	[Cinsiyet] [varchar](10) NULL,
	[Kayitli_il_Id] [int] NULL,
	[Kayitli_ilce_Id] [int] NULL,
	[MedeniHali] [varchar](10) NULL,
	[AnneAdi] [varchar](50) NULL,
	[BabaAdi] [varchar](50) NULL,
	[KanGrubu] [varchar](8) NULL,
	[Kurumu] [varchar](50) NULL,
 CONSTRAINT [PK_Hastalar] PRIMARY KEY CLUSTERED 
(
	[TcNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HastaSikayetleri]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HastaSikayetleri](
	[HastaSikayetID] [int] IDENTITY(1,1) NOT NULL,
	[Yakinması] [varchar](500) NULL,
	[Tarih] [date] NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_HastaSikayetleri] PRIMARY KEY CLUSTERED 
(
	[HastaSikayetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HastaTedavi]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HastaTedavi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tedavi_Adi] [varchar](250) NULL,
	[Günde] [varchar](10) NULL,
	[Kullanim_Miktari] [varchar](10) NULL,
	[Uygulama_Saati] [varchar](50) NULL,
	[Tedavi_Tarihi] [datetime] NULL,
	[Tedavi_Süresi] [varchar](10) NULL,
	[Aciklama] [varchar](320) NULL,
	[Görevli_Hemsire] [varchar](150) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_HastaTedavi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hizmetler]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hizmetler](
	[HizmetID] [int] IDENTITY(1,1) NOT NULL,
	[HizmetAdı] [varchar](150) NULL,
	[Ücret] [float] NULL,
 CONSTRAINT [PK_Hizmetler] PRIMARY KEY CLUSTERED 
(
	[HizmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ilac_Tedavi]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ilac_Tedavi](
	[ilac_TPID] [int] IDENTITY(1,1) NOT NULL,
	[Tedavi_Adı] [varchar](150) NULL,
	[İlac_Adi] [varchar](50) NULL,
	[Tedavi_Süresi] [varchar](10) NULL,
	[Kullanım_Miktarı] [varchar](10) NULL,
	[Uygulama_Saati] [varchar](150) NULL,
	[Kullanım_Şekli] [varchar](30) NULL,
	[AçTok_Durumu] [varchar](10) NULL,
	[Tedavi_Tarihi] [datetime] NULL,
	[Aciklama] [varchar](200) NULL,
	[Birim_Adi] [varchar](150) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_ilac_Tedavi] PRIMARY KEY CLUSTERED 
(
	[ilac_TPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[İlacDepo]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[İlacDepo](
	[MalzemeID] [int] IDENTITY(1,1) NOT NULL,
	[Malzeme_Adı] [varchar](250) NULL,
	[Etken_Madde] [varchar](250) NULL,
	[Stok] [varchar](50) NULL,
	[Birim_Adı] [varchar](150) NULL,
	[Depo] [varchar](50) NULL,
 CONSTRAINT [PK_İlacDepo] PRIMARY KEY CLUSTERED 
(
	[MalzemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[İlacListe]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[İlacListe](
	[İlacID] [int] IDENTITY(1,1) NOT NULL,
	[İlacAd] [varchar](250) NULL,
	[Rapor] [varchar](50) NULL,
 CONSTRAINT [PK_İlacListe] PRIMARY KEY CLUSTERED 
(
	[İlacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[İlacSarfCikis]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[İlacSarfCikis](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MalzemeID] [int] NULL,
	[Adı] [varchar](150) NULL,
	[Tarih] [date] NULL,
	[Adet] [int] NULL,
	[Kullanim_Miktarı] [varchar](50) NULL,
	[Birim_Adı] [varchar](150) NULL,
	[Doktor] [varchar](90) NULL,
	[Donör_ID] [int] NULL,
	[Kullanim_Sekli] [varchar](50) NULL,
	[Ac_Tok] [varchar](10) NULL,
	[Aciklama] [varchar](350) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_İlacSarfCikis] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KararAciklamalari]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KararAciklamalari](
	[KararAciklamaID] [int] IDENTITY(1,1) NOT NULL,
	[Karar_Aciklamasi] [varchar](250) NULL,
	[Doktor] [varchar](150) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_KararAciklamalari] PRIMARY KEY CLUSTERED 
(
	[KararAciklamaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klinikler]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klinikler](
	[KlinikId] [int] IDENTITY(1,1) NOT NULL,
	[KlinikAdi] [varchar](50) NULL,
 CONSTRAINT [PK_Klinikler] PRIMARY KEY CLUSTERED 
(
	[KlinikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabSonuc]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabSonuc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adı_Soyadı] [varchar](150) NULL,
	[Doktoru] [varchar](150) NULL,
	[Sonuc_No] [int] NOT NULL,
 CONSTRAINT [PK_LabSonuc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mudahale]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mudahale](
	[MudahaleID] [int] IDENTITY(1,1) NOT NULL,
	[Hizmet_Tarih] [date] NULL,
	[Hizmet] [varchar](150) NULL,
	[Adet] [int] NULL,
	[Fiyat] [int] NULL,
	[Tutar] [int] NULL,
	[Aciklama] [varchar](150) NULL,
	[Doktor] [varchar](150) NULL,
	[İslemYapanPersonel] [varchar](150) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_Mudahale] PRIMARY KEY CLUSTERED 
(
	[MudahaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personeller]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personeller](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](250) NULL,
 CONSTRAINT [PK_Personeller] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceteAciklamalar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceteAciklamalar](
	[AciklamaID] [int] IDENTITY(1,1) NOT NULL,
	[Aciklama] [varchar](350) NULL,
	[Türü] [varchar](80) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_ReceteAciklamalar] PRIMARY KEY CLUSTERED 
(
	[AciklamaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceteListe]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceteListe](
	[ReceteID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](150) NULL,
	[Doktor_AdSoyad] [varchar](150) NULL,
	[İlac_Adi] [varchar](250) NULL,
	[Recete_Türü] [varchar](50) NULL,
	[Recete_Tarih] [date] NULL,
	[Recete_Durum] [varchar](50) NULL,
	[Kullanim_Sekli] [varchar](150) NULL,
	[Rapor_Durum] [varchar](70) NULL,
	[DosyaNo] [int] NULL,
	[SeriNo] [int] NULL,
 CONSTRAINT [PK_ReceteListe] PRIMARY KEY CLUSTERED 
(
	[ReceteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SarfDepo]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SarfDepo](
	[Malzeme_ID] [int] IDENTITY(1,1) NOT NULL,
	[Malzeme_Adı] [varchar](150) NULL,
	[Kritik_Miktar] [int] NULL,
	[Minimum_Miktar] [int] NULL,
	[Etken_Madde] [varchar](50) NULL,
	[SonKullanmaTarihi] [date] NULL,
	[Stok_Miktarı] [int] NULL,
	[Depo] [varchar](100) NULL,
	[Malzeme_Tip] [varchar](50) NULL,
 CONSTRAINT [PK_SarfDepo] PRIMARY KEY CLUSTERED 
(
	[Malzeme_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaburcuOlanHastalar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaburcuOlanHastalar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HastaAdSoyad] [varchar](150) NULL,
	[AnaTanisi] [varchar](50) NULL,
	[Tetkik] [varchar](150) NULL,
	[CikisTarihi] [date] NULL,
	[CikisHali] [varchar](70) NULL,
	[KararNotu] [varchar](250) NULL,
	[Doktor] [varchar](150) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_TaburcuOlanHastalar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tanilar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tanilar](
	[ID] [nvarchar](255) NULL,
	[Tanı_Adı] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tanimlar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tanimlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tarih] [date] NULL,
	[Tani_Tipi] [varchar](50) NULL,
	[Tanı] [varchar](500) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_Tanimlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tedavi]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tedavi](
	[BasvuruNo] [int] IDENTITY(1,1) NOT NULL,
	[Yakınması] [varchar](200) NULL,
	[BulguTipi] [varchar](50) NULL,
	[BulguAciklama] [varchar](200) NULL,
	[Tanisi] [varchar](40) NULL,
 CONSTRAINT [PK_Tedavi] PRIMARY KEY CLUSTERED 
(
	[BasvuruNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tetkikler]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tetkikler](
	[SonucNo] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](150) NULL,
	[TetkikYapilanDosyaNo] [int] NULL,
	[Hizmet_Adı] [varchar](250) NULL,
	[Karşılayan_Birim] [varchar](350) NULL,
	[İstek_Durumu] [varchar](50) NULL,
	[Doktor] [varchar](150) NULL,
	[İsteyenDoktor] [varchar](150) NULL,
	[Tarih] [date] NULL,
 CONSTRAINT [PK_Tetkikler] PRIMARY KEY CLUSTERED 
(
	[SonucNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YatisVerilenHastalar]    Script Date: 18.05.2022 00:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YatisVerilenHastalar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HastaAdSoyad] [varchar](150) NULL,
	[AnaTanisi] [varchar](50) NULL,
	[YatisOnayTarihi] [date] NULL,
	[KararNotu] [varchar](250) NULL,
	[Doktor] [varchar](150) NULL,
	[DosyaNo] [int] NULL,
 CONSTRAINT [PK_YatisVerilenHastalar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doktorlar] ON 

INSERT [dbo].[Doktorlar] ([DoktorId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet], [Email], [Telefon], [Klinik], [KullaniciAdi], [Sifre]) VALUES (1, N'Ahmet Fudayl', N'Maraba', CAST(N'2001-03-08' AS Date), N'Erkek', N'ahmtbey08@gmail.com', N'(545) 523-5308', 1, N'ahmet', N'123456')
INSERT [dbo].[Doktorlar] ([DoktorId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet], [Email], [Telefon], [Klinik], [KullaniciAdi], [Sifre]) VALUES (2, N'Abdulkadir', N'Eraslan', CAST(N'1998-09-05' AS Date), N'Erkek', N'abdulkadir.eraslann@hotmail.com', N'(553) 915-5761', 4, N'abdulkadir', N'123456')
INSERT [dbo].[Doktorlar] ([DoktorId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet], [Email], [Telefon], [Klinik], [KullaniciAdi], [Sifre]) VALUES (3, N'admin', N'admin', CAST(N'2001-03-08' AS Date), N'Erkek', N'ahmetbey08@gmail.com', N'5455235308', 1, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[Doktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Eklenenİlaclar] ON 

INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1, N'LANTUS SOLOSTAR 100 IU 5 3 ML', N'Ağız İçi', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'Denemesi Yapıldı', CAST(N'2022-05-13' AS Date), 5234)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (2, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'Ağız İçi', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'Denemesi Yapıldı', CAST(N'2022-05-13' AS Date), 5234)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (3, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'Ağız İçi', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'Denemesi Yapıldı', CAST(N'2022-05-13' AS Date), 5234)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (4, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'Hastalık', CAST(N'2022-05-13' AS Date), 5240)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (5, N'LEVEMIR FLEXPEN 100 IU 5 3 ML ', N'Göz Üzerine', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'asdfasdf', CAST(N'2022-05-15' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (6, N'LEVEMIR FLEXPEN 100 IU 5 3 ML ', N'Göz Üzerine', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'asdfasdf', CAST(N'2022-05-15' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (7, N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'Göz Üzerine', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsafd', CAST(N'2022-05-15' AS Date), 5240)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (8, N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'Göz Üzerine', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsafd', CAST(N'2022-05-15' AS Date), 5240)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (9, N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'Göz Üzerine', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsafd', CAST(N'2022-05-15' AS Date), 5240)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (10, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsdaf', CAST(N'2022-05-12' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (11, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsdaf', CAST(N'2022-05-12' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (12, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsdaf', CAST(N'2022-05-12' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (13, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'asdfasdfsdaf', CAST(N'2022-05-26' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (14, N'LANTUS SOLOSTAR 100 IU 5 3 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'İlaç Verildi', CAST(N'2022-05-15' AS Date), 4353)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1005, N'ENOX PREF.SYR SC 40 MG 10 .40 ML ', N'Burun İçi (Intranazal)', N'5', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'iyi gelir heralde', CAST(N'2022-05-17' AS Date), 9)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1006, N'NOVOMIX 30 FLEXPEN 100 IU 5 3 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORLU İLAÇ', N'hguıuuı', CAST(N'2022-05-17' AS Date), 5235)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1007, N'LANTUS SOLOSTAR 100 IU 5 3 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'ghj', CAST(N'2022-05-18' AS Date), 5235)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1008, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'Ağız İçi', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'asdfasdasdf', CAST(N'2022-05-18' AS Date), 8)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1009, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'ghghgh', CAST(N'2022-05-18' AS Date), 8)
INSERT [dbo].[Eklenenİlaclar] ([ID], [İlac_Adı], [Kullanim_Sekli], [Kac_Kez], [Kac_Doz], [Kutu], [Periyod], [Periyod_Birim], [Ac_Tok], [Rapor_Durum], [Aciklama], [Tarih], [DosyaNo]) VALUES (1010, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'Ağızdan (Oral)', N'1', N'1', N'1', N'1', N'GÜN', N'Tok', N'RAPORSUZ İLAÇ', N'ghghgh', CAST(N'2022-05-18' AS Date), 8)
SET IDENTITY_INSERT [dbo].[Eklenenİlaclar] OFF
GO
SET IDENTITY_INSERT [dbo].[HastaBulgusu] ON 

INSERT [dbo].[HastaBulgusu] ([ID], [Bulgusu], [Aciklama], [DosyaNo]) VALUES (1, N'Kalp ve Solunum (Fizik Muayenesi)', N'asdfasdf', 0)
INSERT [dbo].[HastaBulgusu] ([ID], [Bulgusu], [Aciklama], [DosyaNo]) VALUES (2, N'Psikolojik Muayene', N'DENEME', 5234)
INSERT [dbo].[HastaBulgusu] ([ID], [Bulgusu], [Aciklama], [DosyaNo]) VALUES (3, N'Psikolojik Muayene', N'sdfgsdfgsdfgsdfg', 4353)
INSERT [dbo].[HastaBulgusu] ([ID], [Bulgusu], [Aciklama], [DosyaNo]) VALUES (1002, N'Patolojik Bulgular', N'asdfasdfasdfasdf', 8)
INSERT [dbo].[HastaBulgusu] ([ID], [Bulgusu], [Aciklama], [DosyaNo]) VALUES (1003, N'Fizik Muayenesi (Genel Değerlendirme)', N'strese bağlı baş ağrısı ön görüldü', 9)
SET IDENTITY_INSERT [dbo].[HastaBulgusu] OFF
GO
INSERT [dbo].[HastaKabul] ([DosyaNo], [TcNo], [Ad], [Soyad], [GelisNedeni], [GelisTarihi], [Sikayeti], [Poliklinik]) VALUES (8, N'98745632111', N'Ahmet', N'Maraba', N'asdasdasd', CAST(N'2022-05-15' AS Date), N'adasdasd', 1)
INSERT [dbo].[HastaKabul] ([DosyaNo], [TcNo], [Ad], [Soyad], [GelisNedeni], [GelisTarihi], [Sikayeti], [Poliklinik]) VALUES (4353, N'96385274120', N'İbrahim', N'Sav', N'Bas Ağrısı', CAST(N'2022-04-12' AS Date), N'Gün Boyu Baş ağrısı,Halsizlik', 1)
INSERT [dbo].[HastaKabul] ([DosyaNo], [TcNo], [Ad], [Soyad], [GelisNedeni], [GelisTarihi], [Sikayeti], [Poliklinik]) VALUES (5233, N'74185296301', N'Hamsi', N'Style', N'Nefes Darlığı', CAST(N'2022-04-11' AS Date), N'Gece yatarken nefes darlığı başlıyor', 1)
INSERT [dbo].[HastaKabul] ([DosyaNo], [TcNo], [Ad], [Soyad], [GelisNedeni], [GelisTarihi], [Sikayeti], [Poliklinik]) VALUES (5234, N'78945612325', N'Derya', N'Polat', N'Gün boyu halsizlik ve baş ağrısı', CAST(N'2022-04-15' AS Date), N'Halsizlik', 1)
INSERT [dbo].[HastaKabul] ([DosyaNo], [TcNo], [Ad], [Soyad], [GelisNedeni], [GelisTarihi], [Sikayeti], [Poliklinik]) VALUES (5235, N'12345678910', N'Faruk', N'Güllüoglu', N'deneme', CAST(N'2022-04-14' AS Date), N'Deneme', 4)
INSERT [dbo].[HastaKabul] ([DosyaNo], [TcNo], [Ad], [Soyad], [GelisNedeni], [GelisTarihi], [Sikayeti], [Poliklinik]) VALUES (5240, N'96385274100', N'Faruk', N'Demir', N'asdf', CAST(N'2022-04-10' AS Date), N'asdf', 1)
GO
SET IDENTITY_INSERT [dbo].[Hastalar] ON 

INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (2, N'12345678910', N'Faruk', N'Güllüoglu', CAST(N'2001-02-11' AS Date), N'İstanbul', N'Erkek', 1, 1, N'Bekar', N'Ayşe', N'Samet', N'0Rh+', N'SGK')
INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (9, N'14359977653', N'Recep', N'Günol', CAST(N'2000-01-08' AS Date), N'Adana', N'Erkek', 3, 3, N'Bekar', N'Fadime', N'Erkan', N'ABRH+', N'Bağkur')
INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (3, N'74185296301', N'Hamsi', N'Style', CAST(N'2000-02-12' AS Date), N'Trabzon', N'Erkek', 61, 1, N'Bekar', N'Gül', N'Vedat', N'0Rh-', N'SGK')
INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (5, N'78945612325', N'Derya', N'Polat', CAST(N'1980-05-20' AS Date), N'Bartın', N'Kadın', 8, 3, N'Bekar', N'Fadime', N'Mehmet', N'0Rh-', N'SGK')
INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (7, N'96385274100', N'Faruk', N'Demir', CAST(N'2000-05-20' AS Date), N'Ankara', N'Erkek', 1, 2, N'Bekar', N'Keziban', N'Kadir', N'0Rh+', N'SGK')
INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (4, N'96385274120', N'İbrahim', N'Sav', CAST(N'1995-08-09' AS Date), N'Kayseri', N'Erkek', 3, 3, N'Evli', N'Jale', N'Berke', N'ARh+', N'SGK')
INSERT [dbo].[Hastalar] ([DosyaNo], [TcNo], [Ad], [Soyad], [DogumTarih], [DogumYeri], [Cinsiyet], [Kayitli_il_Id], [Kayitli_ilce_Id], [MedeniHali], [AnneAdi], [BabaAdi], [KanGrubu], [Kurumu]) VALUES (8, N'98745632111', N'Ahmet', N'Maraba', CAST(N'2001-03-08' AS Date), N'İstanbul', N'Erkek', 1, 1, N'Bekar', N'Denem', N'Deneme', N'0Rh+', N'SGK')
SET IDENTITY_INSERT [dbo].[Hastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[HastaSikayetleri] ON 

INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (1, N'Nefes Darlığı', CAST(N'2022-05-11' AS Date), 5234)
INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (2, N'Nefes Darlığı', CAST(N'2022-05-11' AS Date), 5234)
INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (3, N'Nefes Alamama', CAST(N'2022-05-11' AS Date), 5234)
INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (4, N'yakınmaa', CAST(N'2022-05-14' AS Date), 5234)
INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (5, N'sdfgdsfgdsgsdfg', CAST(N'2022-05-15' AS Date), 4353)
INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (1004, N'asdfasdfsdf', CAST(N'2022-05-15' AS Date), 8)
INSERT [dbo].[HastaSikayetleri] ([HastaSikayetID], [Yakinması], [Tarih], [DosyaNo]) VALUES (1005, N'baş ağrısı', CAST(N'2022-05-17' AS Date), 9)
SET IDENTITY_INSERT [dbo].[HastaSikayetleri] OFF
GO
SET IDENTITY_INSERT [dbo].[Hizmetler] ON 

INSERT [dbo].[Hizmetler] ([HizmetID], [HizmetAdı], [Ücret]) VALUES (1, N'Buhar Tedavisi', 5)
INSERT [dbo].[Hizmetler] ([HizmetID], [HizmetAdı], [Ücret]) VALUES (2, N'Silah Ruhsatı için Sağlık Raporu', 250)
INSERT [dbo].[Hizmetler] ([HizmetID], [HizmetAdı], [Ücret]) VALUES (3, N'Ultrason', 5)
INSERT [dbo].[Hizmetler] ([HizmetID], [HizmetAdı], [Ücret]) VALUES (4, N'Yoğun Bakım', 156)
INSERT [dbo].[Hizmetler] ([HizmetID], [HizmetAdı], [Ücret]) VALUES (5, N'24 Saat EKG Kaydı', 67)
SET IDENTITY_INSERT [dbo].[Hizmetler] OFF
GO
SET IDENTITY_INSERT [dbo].[ilac_Tedavi] ON 

INSERT [dbo].[ilac_Tedavi] ([ilac_TPID], [Tedavi_Adı], [İlac_Adi], [Tedavi_Süresi], [Kullanım_Miktarı], [Uygulama_Saati], [Kullanım_Şekli], [AçTok_Durumu], [Tedavi_Tarihi], [Aciklama], [Birim_Adi], [DosyaNo]) VALUES (1, N'İlaç Tedavisi', NULL, N'1', N'3x2', N'01:30 03:00 ', N'Ağızdan (Oral)', N'Tok', CAST(N'2022-05-12T10:21:56.580' AS DateTime), N'Deneme', N'Dahiliye', 5234)
INSERT [dbo].[ilac_Tedavi] ([ilac_TPID], [Tedavi_Adı], [İlac_Adi], [Tedavi_Süresi], [Kullanım_Miktarı], [Uygulama_Saati], [Kullanım_Şekli], [AçTok_Durumu], [Tedavi_Tarihi], [Aciklama], [Birim_Adi], [DosyaNo]) VALUES (2, N'İlaç Tedavisi', N'Majezik', N'1', N'1x1', N'01:00 02:00 ', N'Ağızdan (Oral)', N'Aç', CAST(N'2022-05-12T10:29:51.897' AS DateTime), N'Deneme', N'Dahiliye', 5234)
SET IDENTITY_INSERT [dbo].[ilac_Tedavi] OFF
GO
SET IDENTITY_INSERT [dbo].[İlacDepo] ON 

INSERT [dbo].[İlacDepo] ([MalzemeID], [Malzeme_Adı], [Etken_Madde], [Stok], [Birim_Adı], [Depo]) VALUES (1, N'Majezik', N'Flurbiprofen', N'Mevcut', N'Dahiliye', N'Dahiliye Deposu')
INSERT [dbo].[İlacDepo] ([MalzemeID], [Malzeme_Adı], [Etken_Madde], [Stok], [Birim_Adı], [Depo]) VALUES (2, N'Dolorex', N'diklofenak', N'Mevcut', N'Cildiye', N'Dahiliye Deposu')
INSERT [dbo].[İlacDepo] ([MalzemeID], [Malzeme_Adı], [Etken_Madde], [Stok], [Birim_Adı], [Depo]) VALUES (3, N'Aspirin', N'asetilsalisilik ', N'Mevcut', N'Anestezi ve Algoloji', N'Dahiliye Deposu')
INSERT [dbo].[İlacDepo] ([MalzemeID], [Malzeme_Adı], [Etken_Madde], [Stok], [Birim_Adı], [Depo]) VALUES (4, N'Beloc', N'metoprolol', N'Mevcut', N'Cildiye', N'Cildiye Deposu')
INSERT [dbo].[İlacDepo] ([MalzemeID], [Malzeme_Adı], [Etken_Madde], [Stok], [Birim_Adı], [Depo]) VALUES (5, N'KATARİN', N'antitüssif ', N'Yok', N'Dahiliye', N'Dahiliye Deposu')
SET IDENTITY_INSERT [dbo].[İlacDepo] OFF
GO
SET IDENTITY_INSERT [dbo].[İlacListe] ON 

INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (1, N'NOVORAPID FLEXPEN 100 IU 5 3 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (2, N'LANTUS SOLOSTAR 100 IU 5 3 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (3, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (4, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (5, N'NOVOMIX 30 FLEXPEN 100 IU 5 3 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (6, N'OKSAPAR PREF.SYR SC 40 MG 10 .40 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (7, N'APIDRA SOLOSTAR 100 IU 5 3 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (8, N'LEVEMIR FLEXPEN 100 IU 5 3 ML ', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (9, N'ENOX PREF.SYR SC 40 MG 10 .40 ML ', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (10, N'RYZODEG FLEXTOUCH PEN SC 100 IU /1ML 5 3 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (11, N'HUMALOG KWIKPEN 100 IU /1ML 5 3 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (12, N'HUMALOG MIX 25 KWIKPEN 100 IU /1ML 5 3 ML ', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (13, N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (14, N'GRANOCYTE 34 VIAL LYOPH+S 33.6 M 1 1 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (15, N'ENBREL PEN 50 MG 2 1 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (16, N'REMSIMA V.IV DRY 100 MG 1', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (17, N'OMNITROPE CARTRIDGES 10 MG 1 1.50 ML ', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (18, N'AXEPARIN PREFIL.SYRIN 60 MG 2 .60 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (19, N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (20, N'BINOCRIT PREF. SYR 4000 IU 6 .40 ML', N'RAPORLU İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (21, N'LEUCOSTIM PREFIL.SYRIN 30 M 5 1 ML', N'RAPORSUZ İLAÇ')
INSERT [dbo].[İlacListe] ([İlacID], [İlacAd], [Rapor]) VALUES (22, N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'RAPORSUZ İLAÇ')
SET IDENTITY_INSERT [dbo].[İlacListe] OFF
GO
SET IDENTITY_INSERT [dbo].[İlacSarfCikis] ON 

INSERT [dbo].[İlacSarfCikis] ([ID], [MalzemeID], [Adı], [Tarih], [Adet], [Kullanim_Miktarı], [Birim_Adı], [Doktor], [Donör_ID], [Kullanim_Sekli], [Ac_Tok], [Aciklama], [DosyaNo]) VALUES (2, 7, N'Derya Polat', CAST(N'2022-05-12' AS Date), 4, N'4x1', N'1', N'Ahmet Fudayl Maraba', 421, N'Ağızdan (Oral)', N'Aç', N'deneme', 5234)
INSERT [dbo].[İlacSarfCikis] ([ID], [MalzemeID], [Adı], [Tarih], [Adet], [Kullanim_Miktarı], [Birim_Adı], [Doktor], [Donör_ID], [Kullanim_Sekli], [Ac_Tok], [Aciklama], [DosyaNo]) VALUES (3, 4, N'İbrahim Sav', CAST(N'2022-05-15' AS Date), 3, N'1x3', N'1', N'Ahmet Fudayl Maraba', 543, N'Ağızdan (Oral)', N'Aç', N'asdfasdfsadf', 4353)
INSERT [dbo].[İlacSarfCikis] ([ID], [MalzemeID], [Adı], [Tarih], [Adet], [Kullanim_Miktarı], [Birim_Adı], [Doktor], [Donör_ID], [Kullanim_Sekli], [Ac_Tok], [Aciklama], [DosyaNo]) VALUES (1003, 8, N'Recep Günol', CAST(N'2022-05-17' AS Date), 1, N'3x1', N'4', N'Abdulkadir Eraslan', 0, N'Ağız İçi', N'Tok', N'bunu kullan iyi gelir', 9)
SET IDENTITY_INSERT [dbo].[İlacSarfCikis] OFF
GO
SET IDENTITY_INSERT [dbo].[KararAciklamalari] ON 

INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (2, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (3, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (4, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (5, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (6, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (7, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (8, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (9, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (10, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (11, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (12, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (13, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (14, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (15, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (16, N'a', N'Ahmet Fudayl Maraba', 5240)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (17, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 0)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (18, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (19, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (20, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (21, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (22, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (23, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (24, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (25, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 0)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (26, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (27, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (28, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (29, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (30, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (31, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (32, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (33, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (34, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (35, N'Reçete Verildi', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1002, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1003, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1004, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1005, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1006, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1007, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1008, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1009, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1010, N'Kontrole Gelecek', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1011, N'Önerilerde Bulunuldu', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1012, N'Reçete Verildi', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1013, N'Reçete Verildi', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1014, N'Önerilerde Bulunuldu', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1015, N'Önerilerde Bulunuldu', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1016, N'Önerilerde Bulunuldu', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[KararAciklamalari] ([KararAciklamaID], [Karar_Aciklamasi], [Doktor], [DosyaNo]) VALUES (1017, N'Önerilerde Bulunuldu', N'Abdulkadir Eraslan', 9)
SET IDENTITY_INSERT [dbo].[KararAciklamalari] OFF
GO
SET IDENTITY_INSERT [dbo].[Klinikler] ON 

INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (1, N'Dahiliye')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (2, N'Cildiye')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (3, N'Fizik Tedavi')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (4, N'Kardiyoloji')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (5, N'Göz Hastalıkları')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (6, N'Nöroloji')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (7, N'Göğüs Hastalıkları')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (8, N'Çocuk Hastalıkları')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (9, N'Kalp Damar Cerrahi')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (10, N'Beyin ve Sinir Cerrahisi')
INSERT [dbo].[Klinikler] ([KlinikId], [KlinikAdi]) VALUES (11, N'Genel Cerrahi')
SET IDENTITY_INSERT [dbo].[Klinikler] OFF
GO
SET IDENTITY_INSERT [dbo].[Mudahale] ON 

INSERT [dbo].[Mudahale] ([MudahaleID], [Hizmet_Tarih], [Hizmet], [Adet], [Fiyat], [Tutar], [Aciklama], [Doktor], [İslemYapanPersonel], [DosyaNo]) VALUES (1, CAST(N'2022-05-12' AS Date), N'Silah Ruhsatı için Sağlık Raporu', 2, 250, 500, N'ffddsffdsfds', N'Ahmet Fudayl Maraba', N'Ahmet kuku', 4353)
INSERT [dbo].[Mudahale] ([MudahaleID], [Hizmet_Tarih], [Hizmet], [Adet], [Fiyat], [Tutar], [Aciklama], [Doktor], [İslemYapanPersonel], [DosyaNo]) VALUES (2, CAST(N'2022-05-15' AS Date), N'Silah Ruhsatı için Sağlık Raporu', 4, 250, 1000, N'İlaç', N'Ahmet Fudayl Maraba', N'Ahmet kuku', 4353)
INSERT [dbo].[Mudahale] ([MudahaleID], [Hizmet_Tarih], [Hizmet], [Adet], [Fiyat], [Tutar], [Aciklama], [Doktor], [İslemYapanPersonel], [DosyaNo]) VALUES (1002, CAST(N'2022-05-15' AS Date), N'Buhar Tedavisi', 4, 5, 20, N'asdfasdfasdfasdf', N'Ahmet Fudayl Maraba', N'Aleyna Özdemir', 8)
INSERT [dbo].[Mudahale] ([MudahaleID], [Hizmet_Tarih], [Hizmet], [Adet], [Fiyat], [Tutar], [Aciklama], [Doktor], [İslemYapanPersonel], [DosyaNo]) VALUES (1003, CAST(N'2022-05-17' AS Date), N'Buhar Tedavisi', 2, 5, 10, N'buhar sinüsleri açacağı için bağ ağrısı haifler', N'Abdulkadir Eraslan', N'Ahmet kuku', 9)
SET IDENTITY_INSERT [dbo].[Mudahale] OFF
GO
SET IDENTITY_INSERT [dbo].[Personeller] ON 

INSERT [dbo].[Personeller] ([ID], [AdSoyad]) VALUES (1, N'Ahmet kuku')
INSERT [dbo].[Personeller] ([ID], [AdSoyad]) VALUES (2, N'Akif Çuvalcı')
INSERT [dbo].[Personeller] ([ID], [AdSoyad]) VALUES (3, N'Aleyna Özdemir')
INSERT [dbo].[Personeller] ([ID], [AdSoyad]) VALUES (4, N'Ali Keloğlu')
INSERT [dbo].[Personeller] ([ID], [AdSoyad]) VALUES (5, N'Öznur Polat')
INSERT [dbo].[Personeller] ([ID], [AdSoyad]) VALUES (6, N'Rabia Bulut')
SET IDENTITY_INSERT [dbo].[Personeller] OFF
GO
SET IDENTITY_INSERT [dbo].[ReceteAciklamalar] ON 

INSERT [dbo].[ReceteAciklamalar] ([AciklamaID], [Aciklama], [Türü], [DosyaNo]) VALUES (1, N'Tedavisi Yapıldı', N'Tedavi Süresi', 5240)
INSERT [dbo].[ReceteAciklamalar] ([AciklamaID], [Aciklama], [Türü], [DosyaNo]) VALUES (2, N'Reçtenin Açıklaması', N'Teşhis/Tanı', 4353)
SET IDENTITY_INSERT [dbo].[ReceteAciklamalar] OFF
GO
SET IDENTITY_INSERT [dbo].[ReceteListe] ON 

INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (1, N'Derya Polat', N'Ahmet Fudayl Maraba', N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'NORMAL', CAST(N'2022-05-13' AS Date), N'Yeni', N'Ağız İçi', N'RAPORSUZ İLAÇ', 5234, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (2, N'Faruk Demir', N'Ahmet Fudayl Maraba', N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'NORMAL', CAST(N'2022-05-13' AS Date), N'Yeni', N'Ağızdan (Oral)', N'RAPORLU İLAÇ', 5240, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (5, N'Faruk Demir', N'Ahmet Fudayl Maraba', N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'TURUNCU', CAST(N'2022-05-15' AS Date), N'Hatalı', N'Göz Üzerine', N'RAPORLU İLAÇ', 5240, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (6, N'Faruk Demir', N'Ahmet Fudayl Maraba', N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'KIRMIZI', CAST(N'2022-05-15' AS Date), N'Hatalı', N'Göz Üzerine', N'RAPORLU İLAÇ', 5240, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (7, N'Faruk Demir', N'Ahmet Fudayl Maraba', N'OVITRELLE PREF.SYR SC 250 Y 1 .50 ML', N'YEŞİL', CAST(N'2022-05-15' AS Date), N'Hatalı', N'Göz Üzerine', N'RAPORLU İLAÇ', 5240, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (8, N'İbrahim Sav', N'Ahmet Fudayl Maraba', N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'TURUNCU', CAST(N'2022-05-12' AS Date), N'Yeni', N'Ağızdan (Oral)', N'RAPORLU İLAÇ', 4353, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (9, N'İbrahim Sav', N'Ahmet Fudayl Maraba', N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'KIRMIZI', CAST(N'2022-05-12' AS Date), N'Yeni', N'Ağızdan (Oral)', N'RAPORLU İLAÇ', 4353, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (11, N'İbrahim Sav', N'Ahmet Fudayl Maraba', N'ENOX PREF.SYR SC 60 MG 2 .60 ML', N'NORMAL', CAST(N'2022-05-26' AS Date), N'Yeni', N'Ağızdan (Oral)', N'RAPORLU İLAÇ', 4353, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (1003, N'Recep Günol', N'Abdulkadir Eraslan', N'ENOX PREF.SYR SC 40 MG 10 .40 ML ', N'KIRMIZI', CAST(N'2022-05-17' AS Date), N'Düzenlendi', N'Burun İçi (Intranazal)', N'RAPORSUZ İLAÇ', 9, NULL)
INSERT [dbo].[ReceteListe] ([ReceteID], [AdSoyad], [Doktor_AdSoyad], [İlac_Adi], [Recete_Türü], [Recete_Tarih], [Recete_Durum], [Kullanim_Sekli], [Rapor_Durum], [DosyaNo], [SeriNo]) VALUES (1006, N'Ahmet Maraba', N'Ahmet Fudayl Maraba', N'OKSAPAR PREF.SYR SC 60 MG 2 .60 ML', N'YEŞİL', CAST(N'2022-05-18' AS Date), N'Yeni', N'Ağızdan (Oral)', N'RAPORSUZ İLAÇ', 8, 469036)
SET IDENTITY_INSERT [dbo].[ReceteListe] OFF
GO
SET IDENTITY_INSERT [dbo].[SarfDepo] ON 

INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (1, N'Bıçak', 3, 5, NULL, CAST(N'2023-05-12' AS Date), 8, N'Cerrahi Alet Deposu', N'Cerrahi')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (2, N'Neşter', 5, 10, NULL, CAST(N'2023-08-03' AS Date), 23, N'Cerrahi Alet Deposu', N'Cerrahi')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (3, N'Şok Cihazı', 2, 5, NULL, CAST(N'2026-12-13' AS Date), 3, N'Cerrahi Alet Deposu', N'Teknolojik')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (4, N'Job', 2, 3, NULL, CAST(N'2025-02-02' AS Date), 4, N'Güvenlik Deposu', N'Koruma')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (5, N'A4 Kağıt', 10, 5, NULL, CAST(N'2026-01-02' AS Date), 100, N'Güvenlik Deposu', N'Kırtasiye')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (6, N'Kalem', 5, 3, NULL, CAST(N'2030-02-01' AS Date), 41, N'Güvenlik Deposu', N'Kırtasiye')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (7, N'Majezik', 100, 150, N'Ağrı Kesici', CAST(N'2027-02-01' AS Date), 3450, N'Eczane Deposu', N'İlaç')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (8, N'Dolorex', 13, 50, N'Ağrı Kesici', CAST(N'2040-04-10' AS Date), 300, N'Eczane Deposu', N'İlaç')
INSERT [dbo].[SarfDepo] ([Malzeme_ID], [Malzeme_Adı], [Kritik_Miktar], [Minimum_Miktar], [Etken_Madde], [SonKullanmaTarihi], [Stok_Miktarı], [Depo], [Malzeme_Tip]) VALUES (9, N'Aspirin', 40, 50, N'Ağrı Kesici', CAST(N'2033-01-04' AS Date), 235, N'Eczane Deposu', N'ilaç')
SET IDENTITY_INSERT [dbo].[SarfDepo] OFF
GO
SET IDENTITY_INSERT [dbo].[TaburcuOlanHastalar] ON 

INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1, N'İbrahim Sav', N'A00 Kolera', N'Glukoz,', CAST(N'2022-05-15' AS Date), N'Deneme', N'1 Hafta Sonra Kontrole Gelicek', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (2, N'İbrahim Sav', N'A00 Kolera', N'Glukoz,', CAST(N'2022-05-15' AS Date), N'Kendi Halinde', N'Kontrolleri yapıldı Reçetesi Verildi', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (3, N'İbrahim Sav', N'A00 Grip', N'Glukoz,', CAST(N'2022-05-15' AS Date), N'Kendi Halinde', N'Kontrolleri yapıldı, hastalığı hakkında öneriler de bulunuldu', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (4, N'İbrahim Sav', N'A00 Aids', N'Glukoz,', CAST(N'2022-05-15' AS Date), N'asdf', N'asdfasdf', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (5, N'İbrahim Sav', N'A00 Kolera', N'Glukoz,', CAST(N'2022-05-15' AS Date), N'ghjghj', N'ghjghjgjghjghj', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (6, N'İbrahim Sav', N'A00 Kolera', N'Glukoz,', CAST(N'2022-05-20' AS Date), N'asdfasdf', N'asdfasdfsadf', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (7, N'Derya Polat', N'Korona', N'EKG,Tomografi,', CAST(N'2022-05-15' AS Date), N'Medeni', N'Denemesi Yapıldı', N'Ahmet Fudayl Maraba', 5234)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (8, N'İbrahim Sav', N'A00 Kolera', N'Glukoz,', CAST(N'2022-05-15' AS Date), N'Deneme', N'İyileşti', N'Ahmet Fudayl Maraba', 4353)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1004, N'Ahmet Maraba', N'Grip', N'asfdgsa', CAST(N'2022-05-15' AS Date), N'asdfasdfas', N'asdfasdfadsfasdf', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1005, N'Ahmet Maraba', N'G43 Migren', N'sdfg', CAST(N'2022-05-15' AS Date), N'dfdsfgsd', N'dsfgsdsdgdsfgdsfg', N'Ahmet Fudayl Maraba', 8)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1006, N'Recep Günol', N'G43 Migren', N'BilirubinMR,', CAST(N'2022-05-17' AS Date), N'kaçtı', N'öneride bunuldu', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1007, N'Recep Günol', N'G43 Migren', N'BilirubinMR,', CAST(N'2022-05-17' AS Date), N'çıktı', N'öneride bunuldu', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1008, N'Recep Günol', N'G43 Migren', N'BilirubinMR,', CAST(N'2022-05-17' AS Date), N'sdfsdf', N'sdfsfsdfsdfsdf', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1009, N'Recep Günol', N'G43 Migren', N'BilirubinMR,', CAST(N'2022-05-17' AS Date), N'ttytyty', N'tytytyyyy', N'Abdulkadir Eraslan', 9)
INSERT [dbo].[TaburcuOlanHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [Tetkik], [CikisTarihi], [CikisHali], [KararNotu], [Doktor], [DosyaNo]) VALUES (1010, N'Recep Günol', N'G43 Migren', N'BilirubinMR,', CAST(N'2022-05-17' AS Date), N'asdfasdf', N'asdfasdfasdfasdf', N'Abdulkadir Eraslan', 9)
SET IDENTITY_INSERT [dbo].[TaburcuOlanHastalar] OFF
GO
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G40.8', N'Epilepsiler, diğer')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G40.9', N'Epilepsi, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G41', N'Status epileptikus')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G41.0', N'Grand mal status epileptikus')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G41.1', N'Petit mal status epileptikus')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G41.2', N'Kompleks kısmi status epileptikus')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G41.8', N'Status epileptikuslar, diğer')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G41.9', N'Status epileptikus, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43', N'Migren')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43.0', N'Aurasız migren [common migraine]')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43.1', N'Auralı migren [klasik migren]')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43.2', N'Status migrenozus')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43.3', N'Komplikasyonlu migren')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43.8', N'Migrenler, diğer')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G43.9', N'Migren, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A00', N'Kolera')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A00.0', N'Kolera, Vibrio cholorea 01, biovar kolera’ya bağlı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A00.1', N'Kolera, Vibrio cholerae 01, biovar eltor’a bağlı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A00.9', N'Kolera, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A01', N'Tifo ve paratifo')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A01.0', N'Tifo')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A01.1', N'Paratifo A')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A01.2', N'Paratifo B')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A01.3', N'Paratifo C')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A01.4', N'Paratifo, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A02', N'Salmonella enfeksiyonları, diğer')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A02.0', N'Salmonella enteriti')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A02.1', N'Salmonella septisemisi')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A02.2', N'Salmonella enfeksiyonları, lokalize')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A02.8', N'Salmonella enfeksiyonları, diğer tanımlanmış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A02.9', N'Salmonella enfeksiyonu, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03', N'Şigelloz')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03.0', N'Şigelloz, Shigella dysenteriae’ye bağlı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03.1', N'Şigelloz, Shigella flexneri’ye bağlı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03.2', N'Şigelloz, Shigella boydii’ye bağlı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03.3', N'Şigelloz, Shigella sonnei’ye bağlı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03.8', N'Şigellozlar, diğer')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'A03.9', N'Şigelloz, tanımlanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44', N'Baş ağrısı, diğer sendromları')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44.0', N'Küme baş ağrısı sendromu')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44.1', N'Vasküler baş ağrısı, başka yerde sınıflanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44.2', N'Gerilim baş ağrısı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44.3', N'Kronik post-travmatik baş ağrısı')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44.4', N'İlaca bağlı baş ağrısı, başka yerde sınıflanmamış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'G44.8', N'Baş ağrısı sendromları diğer, tanımlanmış')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'J45', N'Astım')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'J45.0', N'Astım, allerjik')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'J45.1', N'Astım, İntrensek (allerjik olmayan)')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'J45.8', N'Astım, karma')
INSERT [dbo].[Tanilar] ([ID], [Tanı_Adı]) VALUES (N'J45.9', N'Astım, tanımlanmamış')
GO
SET IDENTITY_INSERT [dbo].[Tanimlar] ON 

INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (7, CAST(N'2022-05-11' AS Date), N'Kesin Tanı', N'J45 Astım', 5234)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (8, CAST(N'2022-05-14' AS Date), N'Kesin Tanı', N'G40.8 System.Data.DataRowView', 5234)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (9, CAST(N'2022-05-14' AS Date), N'Kesin Tanı', N'G40.8 System.Data.DataRowView', 5234)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (10, CAST(N'2022-05-14' AS Date), N'Kesin Tanı', N'G40.9 Epilepsi, tanımlanmamış', 5234)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (11, CAST(N'2022-05-14' AS Date), N'Kesin Tanı', N'A03.1 Şigelloz, Shigella flexneri’ye bağlı', 5240)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (13, CAST(N'2022-05-15' AS Date), N'Kesin Tanı', N'G43 Migren', 5234)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (14, CAST(N'2022-05-15' AS Date), N'Kesin Tanı', N'A01.1 Paratifo A', 4353)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (1011, CAST(N'2022-05-15' AS Date), N'Kesin Tanı', N'G43 Migren', 8)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (1012, CAST(N'2022-05-17' AS Date), N'Kesin Tanı', N'G43 Migren', 4353)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (1013, CAST(N'2022-05-17' AS Date), N'Kesin Tanı', N'G43 Migren', 9)
INSERT [dbo].[Tanimlar] ([ID], [Tarih], [Tani_Tipi], [Tanı], [DosyaNo]) VALUES (1014, CAST(N'2022-05-17' AS Date), N'Kesin Tanı', N'G43 Migren', 9)
SET IDENTITY_INSERT [dbo].[Tanimlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Tetkikler] ON 

INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (1, N'Deneme', 5234, N'label1Glukoz,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-14' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (2, NULL, 5240, N'Röntgen,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-14' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (3, NULL, 4353, N'EKG,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', NULL)
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (4, NULL, 5234, N'Glukoz,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-14' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (5, NULL, 5234, N'Bilirubin,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-14' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (6, NULL, 5240, N'Magnezyum,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', NULL)
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (7, NULL, 5234, N'Kreatinin,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', NULL)
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (8, NULL, 5234, N'Kreatinin,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', NULL)
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (9, NULL, 5234, N'Kreatinin,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', NULL)
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (10, NULL, 5234, N'EKG,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-14' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (11, NULL, 5234, N'EKG,Röntgen,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-14' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (12, NULL, 4353, N'Glukoz,', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-15' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (13, NULL, 5234, N'EKG,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-15' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (14, NULL, 5234, N'EKG,Tomografi,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-15' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (15, N'Ahmet Maraba', 8, N'Glukoz', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-16' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (16, N'Ahmet Maraba', 8, N'Glukoz', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-16' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (17, N'Ahmet Maraba', 8, N'Kreatinin', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-16' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (18, N'Ahmet Maraba', 8, N'Albümin', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-16' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (19, N'Ahmet Maraba', 8, N'Magnezyum', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-16' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (20, N'Ahmet Maraba', 8, N'Kolesterol', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Ahmet Fudayl Maraba', N'Ahmet Fudayl Maraba', CAST(N'2022-05-16' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (21, N'Recep Günol', 9, N'Glukoz', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (22, N'Recep Günol', 9, N'Bilirubin', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (23, N'Recep Günol', 9, N'Kalsiyum', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (24, N'Recep Günol', 9, N'Magnezyum', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (25, N'Recep Günol', 9, N'Kolesterol', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (26, N'Recep Günol', 9, N'KolesterolMR,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (27, N'Recep Günol', 9, N'Glukoz', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (28, N'Recep Günol', 9, N'Bilirubin', N'Biyokimya Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
INSERT [dbo].[Tetkikler] ([SonucNo], [AdSoyad], [TetkikYapilanDosyaNo], [Hizmet_Adı], [Karşılayan_Birim], [İstek_Durumu], [Doktor], [İsteyenDoktor], [Tarih]) VALUES (29, N'Recep Günol', 9, N'BilirubinMR,', N'Radyoloji Laboratuvarı', N'İstek Yapıldı', N'Abdulkadir Eraslan', N'Abdulkadir Eraslan', CAST(N'2022-05-17' AS Date))
SET IDENTITY_INSERT [dbo].[Tetkikler] OFF
GO
SET IDENTITY_INSERT [dbo].[YatisVerilenHastalar] ON 

INSERT [dbo].[YatisVerilenHastalar] ([ID], [HastaAdSoyad], [AnaTanisi], [YatisOnayTarihi], [KararNotu], [Doktor], [DosyaNo]) VALUES (1, N'İbrahim Sav', N'A00 Kolera', CAST(N'2022-05-15' AS Date), N'asdfasdfasdf', N'Ahmet Fudayl Maraba', 4353)
SET IDENTITY_INSERT [dbo].[YatisVerilenHastalar] OFF
GO
ALTER TABLE [dbo].[Doktorlar]  WITH CHECK ADD  CONSTRAINT [FK_Doktorlar_Klinikler] FOREIGN KEY([Klinik])
REFERENCES [dbo].[Klinikler] ([KlinikId])
GO
ALTER TABLE [dbo].[Doktorlar] CHECK CONSTRAINT [FK_Doktorlar_Klinikler]
GO
ALTER TABLE [dbo].[HastaKabul]  WITH CHECK ADD  CONSTRAINT [FK_HastaKabul_Hastalar] FOREIGN KEY([TcNo])
REFERENCES [dbo].[Hastalar] ([TcNo])
GO
ALTER TABLE [dbo].[HastaKabul] CHECK CONSTRAINT [FK_HastaKabul_Hastalar]
GO
ALTER TABLE [dbo].[HastaKabul]  WITH CHECK ADD  CONSTRAINT [FK_HastaKabul_Klinikler] FOREIGN KEY([Poliklinik])
REFERENCES [dbo].[Klinikler] ([KlinikId])
GO
ALTER TABLE [dbo].[HastaKabul] CHECK CONSTRAINT [FK_HastaKabul_Klinikler]
GO
