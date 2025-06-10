-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Cze 10, 2025 at 08:26 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `przychodnia`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `doctors`
--

CREATE TABLE `doctors` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Imie` varchar(100) DEFAULT NULL,
  `Nazwisko` varchar(100) DEFAULT NULL,
  `Specjalizacja` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctors`
--

INSERT INTO `doctors` (`Id`, `UserId`, `Imie`, `Nazwisko`, `Specjalizacja`) VALUES
(1, 1, 'Anna', 'Nowak', 'Kardiolog'),
(2, 2, 'Jan', 'Kowalski', 'Pediatra'),
(3, 3, 'Katarzyna', 'Wisniewska', 'Dermatolog'),
(4, 4, 'Piotr', 'Zielinski', 'Ortopeda'),
(5, 5, 'Maria', 'Lewandowska', 'Neurolog');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dokumentypacjenta`
--

CREATE TABLE `dokumentypacjenta` (
  `Id` int(11) NOT NULL,
  `PacjentId` int(11) NOT NULL,
  `DataDodania` date NOT NULL,
  `Typ` varchar(100) NOT NULL,
  `Uwagi` text DEFAULT NULL,
  `SciezkaPliku` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dokumentypacjenta`
--

INSERT INTO `dokumentypacjenta` (`Id`, `PacjentId`, `DataDodania`, `Typ`, `Uwagi`, `SciezkaPliku`) VALUES
(1, 6, '2025-05-01', 'Wyniki badan krwi', 'Wszystkie parametry w normie', '/dokumenty/pacjent6/wyniki_krwi_2025_05_01.pdf'),
(2, 7, '2025-05-02', 'Karta szczepien', 'Szczepienie przeciw odrze', '/dokumenty/pacjent7/karta_szczepien_2025_05_02.pdf'),
(3, 8, '2025-05-03', 'Wyniki testow alergicznych', 'Alergia na pylki', '/dokumenty/pacjent8/testy_alergiczne_2025_05_03.pdf'),
(4, 9, '2025-05-04', 'RTG kolana', 'Zapalenie stawu', '/dokumenty/pacjent9/rtg_kolana_2025_05_04.pdf'),
(5, 10, '2025-05-05', 'Karta pacjenta', 'Historia chorob', '/dokumenty/pacjent10/karta_pacjenta_2025_05_05.pdf'),
(6, 11, '2025-05-06', 'EKG', 'Nadcisnienie potwierdzone', '/dokumenty/pacjent11/ekg_2025_05_06.pdf'),
(7, 12, '2025-05-07', 'Plan szczepien', 'Zaplanowane na czerwiec', '/dokumenty/pacjent12/plan_szczepien_2025_05_07.pdf'),
(8, 13, '2025-05-08', 'Wyniki badan skory', 'Alergia potwierdzona', '/dokumenty/pacjent13/badania_skory_2025_05_08.pdf'),
(9, 14, '2025-05-09', 'Zdjecie RTG plecow', 'Brak odchylen', '/dokumenty/pacjent14/rtg_plecow_2025_05_09.pdf'),
(10, 15, '2025-05-10', 'MRI glowy', 'Podejrzenie migreny', '/dokumenty/pacjent15/mri_glowy_2025_05_10.pdf');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `opinie`
--

CREATE TABLE `opinie` (
  `Id` int(11) NOT NULL,
  `PacjentId` int(11) NOT NULL,
  `LekarzId` int(11) NOT NULL,
  `Ocena` int(11) NOT NULL CHECK (`Ocena` between 1 and 5),
  `Komentarz` text DEFAULT NULL,
  `DataDodania` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `opinie`
--

INSERT INTO `opinie` (`Id`, `PacjentId`, `LekarzId`, `Ocena`, `Komentarz`, `DataDodania`) VALUES
(1, 6, 1, 5, 'Swietny kardiolog bardzo pomocny', '2025-05-11 09:30:00'),
(2, 7, 2, 4, 'Dobry pediatra dziecko czuje sie komfortowo', '2025-05-12 10:30:00'),
(3, 8, 3, 3, 'Dermatolog ok ale dlugi czas oczekiwania', '2025-05-13 11:30:00'),
(4, 9, 4, 5, 'Ortopeda bardzo profesjonalny szybko pomogl z bolem', '2025-05-14 12:30:00'),
(5, 10, 5, 2, 'Neurolog malo komunikatywny', '2025-05-15 13:30:00'),
(6, 11, 1, 4, 'Kardiolog pomogl z cisnieniem polecam', '2025-05-16 14:30:00'),
(7, 12, 2, 5, 'Pediatra super podejscie do dzieci', '2025-05-17 15:30:00'),
(8, 13, 3, 4, 'Dermatolog skuteczny w leczeniu wysypki', '2025-05-18 16:30:00'),
(9, 14, 4, 3, 'Ortopeda ok ale malo szczegolowych wyjasnien', '2025-05-19 17:30:00'),
(10, 15, 5, 1, 'Neurolog nie slucha pacjenta', '2025-05-20 18:30:00');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `powiadomienia`
--

CREATE TABLE `powiadomienia` (
  `Id` int(11) NOT NULL,
  `PacjentId` int(11) NOT NULL,
  `TypPowiadomienia` enum('wizyta','recepta','skierowanie','dokument','opinia') NOT NULL,
  `Wiadomosc` text NOT NULL,
  `DataWyslania` datetime NOT NULL,
  `Kanal` enum('email','sms','push') NOT NULL,
  `Status` enum('wys?ane','b??d') DEFAULT 'wys?ane'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `powiadomienia`
--

INSERT INTO `powiadomienia` (`Id`, `PacjentId`, `TypPowiadomienia`, `Wiadomosc`, `DataWyslania`, `Kanal`, `Status`) VALUES
(1, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(2, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(3, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(4, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(5, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(6, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(7, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(8, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(9, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 12:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(10, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(11, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(12, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(13, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(14, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(15, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 09:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(16, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(17, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(18, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 15:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(19, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(20, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(21, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Anna Nowak', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(22, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(23, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 08:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(24, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(25, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(26, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 13:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(27, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(28, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(29, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(30, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(31, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(32, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(33, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(34, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(35, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(36, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(37, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(38, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:00:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(39, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(40, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(41, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(42, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 10:30:00 u lekarza Jan Kowalski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(43, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(44, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(45, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(46, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(47, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(48, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(49, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(50, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(51, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 12:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(52, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(53, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(54, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(55, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(56, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(57, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:30:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(58, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(59, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Katarzyna Wisniewska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(60, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 12:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(61, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(62, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(63, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(64, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(65, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(66, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(67, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(68, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(69, 12, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(70, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(71, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(72, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(73, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(74, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(75, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(76, 15, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(77, 7, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(78, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(79, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:30:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(80, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 12:00:00 u lekarza Piotr Zielinski', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(81, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(82, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 11:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(83, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(84, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 13:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(85, 8, 'wizyta', 'Zaplanowano wizyt? na 2025-06-04 09:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(86, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(87, 10, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(88, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(89, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 09:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(90, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(91, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(92, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 15:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(93, 14, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(94, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 14:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(95, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 11:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(96, 6, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(97, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-05 14:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(98, 11, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 08:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(99, 9, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 10:00:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane'),
(100, 13, 'wizyta', 'Zaplanowano wizyt? na 2025-06-06 12:30:00 u lekarza Maria Lewandowska', '2025-06-04 21:53:03', 'email', 'wysˆane');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `recepty`
--

CREATE TABLE `recepty` (
  `Id` int(11) NOT NULL,
  `WizytaId` int(11) DEFAULT NULL,
  `PacjentId` int(11) NOT NULL,
  `LekarzId` int(11) NOT NULL,
  `DataWystawienia` datetime NOT NULL,
  `KodRecepty` varchar(50) NOT NULL,
  `Leki` text NOT NULL,
  `Uwagi` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `recepty`
--

INSERT INTO `recepty` (`Id`, `WizytaId`, `PacjentId`, `LekarzId`, `DataWystawienia`, `KodRecepty`, `Leki`, `Uwagi`) VALUES
(1, 2, 7, 2, '2025-05-12 10:30:00', 'RX001', 'Witamina D 1000 IU', 'Przyjmowac raz dziennie'),
(2, 4, 9, 4, '2025-05-14 12:30:00', 'RX002', 'Ibuprofen 400 mg', 'Dwie tabletki dziennie przez 5 dni'),
(3, 6, 11, 1, '2025-05-16 14:30:00', 'RX003', 'Amlodypina 5 mg', 'Jedna tabletka dziennie'),
(4, 8, 13, 3, '2025-05-18 16:30:00', 'RX004', 'Hydrokortyzon krem', 'Stosowac dwa razy dziennie'),
(5, 10, 15, 5, '2025-05-20 18:30:00', 'RX005', 'Sumatryptan 50 mg', 'W razie migreny'),
(6, 11, 12, 4, '2025-06-06 12:00:00', 'RX021', 'Diklofenak 50 mg', 'Dwie tabletki dziennie przez 5 dni, stosowa? z jedzeniem'),
(7, 12, 8, 1, '2025-06-06 10:00:00', 'RX022', 'Atorwastatyna 20 mg', 'Jedna tabletka dziennie wieczorem, kontrola ci?nienia co tydzie?'),
(8, 20, 14, 2, '2025-06-05 08:00:00', 'RX030', 'Paracetamol 125 mg syrop', '10 kropli dziennie rano przez 6 miesi?cy'),
(9, 30, 11, 2, '2025-06-05 13:00:00', 'RX040', 'Ibuprofen 100 mg/5 ml', '2,5 ml co 8 godzin, podawa? z jedzeniem'),
(10, 36, 8, 5, '2025-06-04 09:30:00', 'RX046', 'Topiramat 25 mg', 'Jedna kapsu?ka wieczorem, zwi?ksza? dawk? po konsultacji');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `skierowania`
--

CREATE TABLE `skierowania` (
  `Id` int(11) NOT NULL,
  `WizytaId` int(11) DEFAULT NULL,
  `PacjentId` int(11) NOT NULL,
  `LekarzId` int(11) NOT NULL,
  `DataWystawienia` datetime NOT NULL,
  `Typ` varchar(100) NOT NULL,
  `Cel` text NOT NULL,
  `Uwagi` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `skierowania`
--

INSERT INTO `skierowania` (`Id`, `WizytaId`, `PacjentId`, `LekarzId`, `DataWystawienia`, `Typ`, `Cel`, `Uwagi`) VALUES
(1, 2, 7, 2, '2025-05-12 10:30:00', 'Szczepienie', 'Szczepienie przeciw odrze', 'Pilne'),
(2, 4, 9, 4, '2025-05-14 12:30:00', 'RTG', 'RTG kolana prawego', 'W ciagu 7 dni'),
(3, 6, 11, 1, '2025-05-16 14:30:00', 'EKG', 'Kontrola pracy serca', 'Rutynowe'),
(4, 8, 13, 3, '2025-05-18 16:30:00', 'Testy alergiczne', 'Okreslenie alergenow', 'Po ustapieniu objawow'),
(5, 10, 15, 5, '2025-05-20 18:30:00', 'MRI', 'MRI glowy', 'Pilne, podejrzenie migreny'),
(6, 11, 12, 4, '2025-06-06 12:00:00', 'RTG', 'Plan rehabilitacji', 'Konsultacja po zako?czeniu leczenia'),
(7, 30, 11, 2, '2025-06-05 13:00:00', 'Konsultacja alergologiczna', 'Ocena parametr?w krwi', 'Konsultacja po zako?czeniu leczenia'),
(8, 36, 8, 5, '2025-06-04 09:30:00', 'Konsultacja neurochirurgiczna', 'Ocena aktywno?ci m?zgu', 'Pilne, do wykonania w ci?gu 7 dni');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Imie` varchar(100) DEFAULT NULL,
  `Nazwisko` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Haslo` varchar(100) DEFAULT NULL,
  `Rola` varchar(50) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `PESEL` varchar(11) DEFAULT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  `Adres` varchar(255) DEFAULT NULL,
  `Miasto` varchar(255) DEFAULT NULL,
  `KodPocztowy` varchar(10) DEFAULT NULL,
  `CzyUbezpieczony` enum('Tak','Nie') NOT NULL DEFAULT 'Tak'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Imie`, `Nazwisko`, `Email`, `Haslo`, `Rola`, `DateOfBirth`, `PESEL`, `PhoneNumber`, `Adres`, `Miasto`, `KodPocztowy`, `CzyUbezpieczony`) VALUES
(1, 'Anna', 'Nowak', 'anna.nowak@example.com', 'haslo1234', 'Lekarz', '1985-01-01', '85010112345', '123456789', 'ul. Kwiatowa 1', 'Warszawa', '00-001', 'Tak'),
(2, 'Jan', 'Kowalski', 'jan.kowalski@example.com', 'haslo1234', 'Lekarz', '1980-02-02', '80020254321', '987654321', 'ul. Sloneczna 2', 'Krakow', '30-002', 'Tak'),
(3, 'Katarzyna', 'Wisniewska', 'katarzyna.w@example.com', 'haslo1234', 'Lekarz', '1985-03-03', '85030367890', '555666777', 'ul. Lipowa 3', 'Gdansk', '80-003', 'Tak'),
(4, 'Piotr', 'Zielinski', 'piotr.z@example.com', 'haslo1234', 'Lekarz', '1990-04-04', '90040498765', '111222333', 'ul. Brzozowa 4', 'Wroclaw', '50-004', 'Tak'),
(5, 'Maria', 'Lewandowska', 'maria.l@example.com', 'haslo1234', 'Lekarz', '1995-05-05', '95050523456', '444555666', 'ul. Sosnowa 5', 'Poznan', '60-005', 'Nie'),
(6, 'Tomasz', 'Wojcik', 'tomasz.w@example.com', 'haslo1234', 'Pacjent', '1987-06-06', '87060654321', '222333444', 'ul. Polna 6', 'Lodz', '90-006', 'Tak'),
(7, 'Ewa', 'Kaminska', 'ewa.k@example.com', 'haslo1234', 'Pacjent', '1988-07-07', '88070712345', '333444555', 'ul. Ogrodowa 7', 'Szczecin', '70-007', 'Tak'),
(8, 'Michal', 'Szymanski', 'michal.s@example.com', 'haslo1234', 'Pacjent', '1989-08-08', '89080867890', '444555666', 'ul. Wiosenna 8', 'Katowice', '40-008', 'Tak'),
(9, 'Agnieszka', 'Dabrowska', 'agnieszka.d@example.com', 'haslo1234', 'Pacjent', '1990-09-09', '90090923456', '555666777', 'ul. Jesienna 9', 'Lublin', '20-009', 'Tak'),
(10, 'Krzysztof', 'Jankowski', 'krzysztof.j@example.com', 'haslo1234', 'Pacjent', '1991-01-01', '91010198765', '666777888', 'ul. Zimowa 10', 'Bydgoszcz', '85-010', 'Nie'),
(11, 'Zofia', 'Mazur', 'zofia.m@example.com', 'haslo1234', 'Pacjent', '1992-02-02', '92020254321', '777888999', 'ul. Letnia 11', 'Rzeszow', '35-011', 'Tak'),
(12, 'Lukasz', 'Kaczmarek', 'lukasz.k@example.com', 'haslo1234', 'Pacjent', '1993-03-03', '93030312345', '888999000', 'ul. Parkowa 12', 'Olsztyn', '10-012', 'Tak'),
(13, 'Monika', 'Grabowska', 'monika.g@example.com', 'haslo1234', 'Pacjent', '1994-04-04', '94040467890', '999000111', 'ul. Lesna 13', 'Torun', '87-013', 'Nie'),
(14, 'Pawel', 'Witkowski', 'pawel.w@example.com', 'haslo1234', 'Pacjent', '1995-05-05', '95050523457', '000111222', 'ul. Rzeczna 14', 'Gdynia', '81-014', 'Tak'),
(15, 'Joanna', 'Piotrowska', 'joanna.p@example.com', 'haslo1234', 'Pacjent', '1996-06-06', '96060698765', '111222333', 'ul. Morska 15', 'Sopot', '81-015', 'Tak');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wizyty`
--

CREATE TABLE `wizyty` (
  `Id` int(11) NOT NULL,
  `LekarzId` int(11) NOT NULL,
  `PacjentId` int(11) NOT NULL,
  `DataWizyty` datetime NOT NULL,
  `Status` varchar(20) NOT NULL,
  `Opis` text DEFAULT NULL,
  `Diagnoza` text DEFAULT NULL,
  `Zalecenia` text DEFAULT NULL,
  `Specjalizacja` varchar(100) DEFAULT NULL,
  `Objawy` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `wizyty`
--

INSERT INTO `wizyty` (`Id`, `LekarzId`, `PacjentId`, `DataWizyty`, `Status`, `Opis`, `Diagnoza`, `Zalecenia`, `Specjalizacja`, `Objawy`) VALUES
(1, 1, 6, '2025-05-11 09:00:00', 'zaplanowana', 'Konsultacja kardiologiczna', NULL, NULL, 'Kardiolog', NULL),
(2, 2, 7, '2025-05-12 10:00:00', 'odbyta', 'Badanie kontrolne dziecka', 'Zdrowe', 'Kontynuacja diety', 'Pediatra', NULL),
(3, 3, 8, '2025-05-13 11:00:00', 'zaplanowana', 'Problemy skorne', NULL, NULL, 'Dermatolog', NULL),
(4, 4, 9, '2025-05-14 12:00:00', 'odbyta', 'Bol kolana', 'Zapalenie stawu', 'Leki przeciwzapalne', 'Ortopeda', NULL),
(5, 5, 10, '2025-05-15 13:00:00', 'zaplanowana', 'Zawroty glowy', NULL, NULL, 'Neurolog', NULL),
(6, 1, 11, '2025-05-16 14:00:00', 'odbyta', 'Kontrola cisnienia', 'Nadcisnienie', 'Zmiana lekow', 'Kardiolog', NULL),
(7, 2, 12, '2025-05-17 15:00:00', 'zaplanowana', 'Szczepienie', NULL, NULL, 'Pediatra', NULL),
(8, 3, 13, '2025-05-18 16:00:00', 'odbyta', 'Wysypka', 'Alergia', 'Masci sterydowe', 'Dermatolog', NULL),
(9, 4, 14, '2025-05-19 17:00:00', 'zaplanowana', 'Bol plecow', NULL, NULL, 'Ortopeda', NULL),
(10, 5, 15, '2025-05-20 18:00:00', 'odbyta', 'Problemy z pamiecia', 'Podejrzenie migreny', 'Badanie MRI', 'Neurolog', NULL),
(11, 4, 12, '2025-06-06 12:00:00', 'odbyta', 'Konsultacja Ortopeda', 'Zapalenie stawu kolanowego', 'Leki przeciwzapalne, rehabilitacja', 'Ortopeda', NULL),
(12, 1, 8, '2025-06-06 10:00:00', 'odbyta', 'Konsultacja Kardiolog', 'Nadci?nienie t?tnicze', 'Leki na nadci?nienie, kontrola za 2 tygodnie', 'Kardiolog', NULL),
(13, 1, 7, '2025-06-06 10:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(14, 3, 7, '2025-06-06 08:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(15, 4, 13, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(16, 4, 13, '2025-06-06 09:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(17, 2, 13, '2025-06-06 09:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(18, 1, 15, '2025-06-06 08:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(19, 4, 14, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(20, 2, 14, '2025-06-05 08:00:00', 'odbyta', 'Konsultacja Pediatra', 'Infekcja wirusowa', 'Syrop przeciwgor?czkowy, du?o p?yn?w', 'Pediatra', NULL),
(21, 3, 7, '2025-06-06 09:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(22, 4, 10, '2025-06-06 11:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(23, 2, 10, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(24, 2, 12, '2025-06-06 15:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(25, 5, 11, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(26, 1, 8, '2025-06-06 09:00:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(27, 5, 8, '2025-06-06 11:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(28, 4, 6, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(29, 3, 10, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(30, 2, 11, '2025-06-05 13:00:00', 'odbyta', 'Konsultacja Pediatra', 'Infekcja wirusowa', 'Syrop przeciwgor?czkowy, du?o p?yn?w', 'Pediatra', NULL),
(31, 2, 12, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(32, 1, 7, '2025-06-06 15:00:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(33, 4, 12, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(34, 5, 8, '2025-06-06 09:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(35, 5, 13, '2025-06-06 13:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(36, 5, 8, '2025-06-04 09:30:00', 'odbyta', 'Konsultacja Neurolog', 'B?le migrenowe', 'Leki przeciwmigrenowe, badanie MRI', 'Neurolog', NULL),
(37, 3, 12, '2025-06-06 11:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(38, 1, 15, '2025-06-06 08:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(39, 2, 12, '2025-06-06 10:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(40, 5, 14, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(41, 4, 12, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(42, 2, 13, '2025-06-06 11:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(43, 2, 8, '2025-06-06 09:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(44, 4, 14, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(45, 1, 10, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(46, 3, 8, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(47, 1, 7, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(48, 5, 10, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(49, 5, 14, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(50, 5, 9, '2025-06-06 09:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(51, 4, 12, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(52, 4, 13, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(53, 1, 9, '2025-06-06 12:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(54, 1, 9, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(55, 3, 10, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(56, 2, 8, '2025-06-06 15:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(57, 5, 6, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(58, 3, 12, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(59, 2, 13, '2025-06-06 09:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(60, 1, 12, '2025-06-06 11:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(61, 1, 9, '2025-06-06 08:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(62, 5, 13, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(63, 2, 12, '2025-06-06 13:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(64, 2, 15, '2025-06-06 08:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(65, 4, 8, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(66, 4, 6, '2025-06-06 13:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(67, 4, 11, '2025-06-06 10:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(68, 1, 9, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(69, 4, 6, '2025-06-06 15:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(70, 1, 9, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(71, 2, 10, '2025-06-06 08:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(72, 3, 15, '2025-06-06 09:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(73, 1, 15, '2025-06-05 09:00:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(74, 1, 8, '2025-06-06 15:00:00', 'Anulowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(75, 5, 9, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(76, 3, 12, '2025-06-06 12:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(77, 5, 14, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(78, 1, 9, '2025-06-06 10:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(79, 3, 6, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(80, 3, 6, '2025-06-06 08:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(81, 4, 8, '2025-06-06 10:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(82, 4, 15, '2025-06-06 08:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(83, 3, 8, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(84, 5, 9, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(85, 5, 11, '2025-06-05 11:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(86, 5, 6, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(87, 5, 9, '2025-06-05 14:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(88, 3, 6, '2025-06-06 11:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(89, 2, 11, '2025-06-06 11:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(90, 4, 7, '2025-06-06 08:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(91, 5, 11, '2025-06-06 08:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(92, 2, 14, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(93, 1, 12, '2025-06-05 15:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(94, 3, 12, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(95, 1, 6, '2025-06-06 13:00:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(96, 5, 9, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(97, 4, 6, '2025-06-06 11:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(98, 3, 8, '2025-06-06 11:30:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(99, 4, 8, '2025-06-06 14:30:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(100, 5, 13, '2025-06-06 12:30:00', 'zaplanowana', 'Konsultacja Neurolog', NULL, NULL, 'Neurolog', NULL),
(101, 2, 10, '2025-06-06 08:00:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(102, 3, 6, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(103, 2, 7, '2025-06-06 10:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(104, 2, 11, '2025-06-06 13:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(105, 1, 9, '2025-06-06 15:30:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(106, 4, 9, '2025-06-06 12:00:00', 'zaplanowana', 'Konsultacja Ortopeda', NULL, NULL, 'Ortopeda', NULL),
(107, 2, 14, '2025-06-06 14:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(108, 3, 15, '2025-06-06 10:00:00', 'zaplanowana', 'Konsultacja Dermatolog', NULL, NULL, 'Dermatolog', NULL),
(109, 1, 13, '2025-06-06 14:00:00', 'zaplanowana', 'Konsultacja Kardiolog', NULL, NULL, 'Kardiolog', NULL),
(110, 2, 8, '2025-06-05 10:30:00', 'zaplanowana', 'Konsultacja Pediatra', NULL, NULL, 'Pediatra', NULL),
(111, 4, 9, '2025-06-11 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Ortopeda', NULL),
(112, 4, 9, '2025-07-16 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Ortopeda', NULL),
(113, 2, 8, '2025-06-11 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Pediatra', NULL),
(114, 2, 8, '2025-06-27 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Pediatra', NULL),
(115, 3, 8, '2025-06-11 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Dermatolog', NULL),
(116, 3, 8, '2025-07-17 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Dermatolog', NULL),
(117, 4, 8, '2025-07-17 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Ortopeda', NULL),
(118, 5, 8, '2025-07-17 00:00:00', 'Zaplanowana', NULL, NULL, NULL, 'Neurolog', NULL);

--
-- Indeksy dla zrzutÃ³w tabel
--

--
-- Indeksy dla tabeli `doctors`
--
ALTER TABLE `doctors`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- Indeksy dla tabeli `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `PacjentId` (`PacjentId`);

--
-- Indeksy dla tabeli `opinie`
--
ALTER TABLE `opinie`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `idx_opinie_pacjentid` (`PacjentId`),
  ADD KEY `idx_opinie_lekarzid` (`LekarzId`);

--
-- Indeksy dla tabeli `powiadomienia`
--
ALTER TABLE `powiadomienia`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `PacjentId` (`PacjentId`);

--
-- Indeksy dla tabeli `recepty`
--
ALTER TABLE `recepty`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `WizytaId` (`WizytaId`),
  ADD KEY `PacjentId` (`PacjentId`),
  ADD KEY `LekarzId` (`LekarzId`);

--
-- Indeksy dla tabeli `skierowania`
--
ALTER TABLE `skierowania`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `WizytaId` (`WizytaId`),
  ADD KEY `PacjentId` (`PacjentId`),
  ADD KEY `LekarzId` (`LekarzId`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indeksy dla tabeli `wizyty`
--
ALTER TABLE `wizyty`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `LekarzId` (`LekarzId`),
  ADD KEY `PacjentId` (`PacjentId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `doctors`
--
ALTER TABLE `doctors`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `opinie`
--
ALTER TABLE `opinie`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `powiadomienia`
--
ALTER TABLE `powiadomienia`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT for table `recepty`
--
ALTER TABLE `recepty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `skierowania`
--
ALTER TABLE `skierowania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=119;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `doctors`
--
ALTER TABLE `doctors`
  ADD CONSTRAINT `doctors_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  ADD CONSTRAINT `dokumentypacjenta_ibfk_1` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `opinie`
--
ALTER TABLE `opinie`
  ADD CONSTRAINT `opinie_ibfk_1` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `opinie_ibfk_2` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `powiadomienia`
--
ALTER TABLE `powiadomienia`
  ADD CONSTRAINT `powiadomienia_ibfk_1` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `recepty`
--
ALTER TABLE `recepty`
  ADD CONSTRAINT `recepty_ibfk_1` FOREIGN KEY (`WizytaId`) REFERENCES `wizyty` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `recepty_ibfk_2` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `recepty_ibfk_3` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `skierowania`
--
ALTER TABLE `skierowania`
  ADD CONSTRAINT `skierowania_ibfk_1` FOREIGN KEY (`WizytaId`) REFERENCES `wizyty` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `skierowania_ibfk_2` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `skierowania_ibfk_3` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `wizyty`
--
ALTER TABLE `wizyty`
  ADD CONSTRAINT `wizyty_ibfk_1` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `wizyty_ibfk_2` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
