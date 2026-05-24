-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 24 May 2026, 09:42:09
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `site_yonetim`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `aidatlar`
--

CREATE TABLE `aidatlar` (
  `Id` int(11) NOT NULL,
  `DaireNo` int(11) NOT NULL,
  `AdSoyad` varchar(100) NOT NULL,
  `Ay` varchar(20) NOT NULL,
  `Yil` int(11) NOT NULL,
  `Tutar` decimal(10,2) NOT NULL,
  `SonOdemeTarihi` date NOT NULL,
  `Durum` varchar(20) NOT NULL DEFAULT 'Bekliyor'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `aidatlar`
--

INSERT INTO `aidatlar` (`Id`, `DaireNo`, `AdSoyad`, `Ay`, `Yil`, `Tutar`, `SonOdemeTarihi`, `Durum`) VALUES
(11, 2, 'enes arslan', 'Mayıs', 2026, 3000.00, '2026-05-06', 'Ödendi'),
(13, 3, 'ayşe aslan', 'Nisan', 2026, 5000.00, '2026-04-21', 'Gecikti');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `ID` int(11) NOT NULL,
  `AdSoyad` varchar(100) NOT NULL,
  `Eposta` varchar(100) NOT NULL,
  `Sifre` varchar(50) NOT NULL,
  `Rol` varchar(20) NOT NULL,
  `Fotograf` varchar(255) NOT NULL,
  `DaireNo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`ID`, `AdSoyad`, `Eposta`, `Sifre`, `Rol`, `Fotograf`, `DaireNo`) VALUES
(9, 'ayşe aslan', 'ayşe@site.com', '123456', 'Sakin', '', 3),
(10, 'ahmet kaplan', 'ahmet@site.com', '********', 'Sakin', '', NULL),
(13, 'enes ars', 'admin@site1.com', '1234567', 'Yonetici', '', NULL),
(15, 'enes arslan', 'ea5469680@gmail.com', 'enesarslan123', 'sakin', '', 2);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `aidatlar`
--
ALTER TABLE `aidatlar`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`ID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `aidatlar`
--
ALTER TABLE `aidatlar`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
