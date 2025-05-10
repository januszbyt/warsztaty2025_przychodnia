-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Maj 08, 2025 at 08:12 PM
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
(1, 2, 'Jan', 'Nowak', 'Kardiolog'),
(140, 332, 'Adam', 'Kowalski', 'Kardiolog'),
(141, 333, 'Beata', 'Wi?niewska', 'Pediatra'),
(142, 334, 'Cezary', 'Zieli?ski', 'Neurolog'),
(143, 335, 'Dorota', 'Lewandowska', 'Dermatolog'),
(144, 336, 'Edward', 'Szyma?ski', 'Ortopeda'),
(145, 337, 'Feliks', 'Piotrowski', 'Ginekolog'),
(146, 338, 'Gra?yna', 'Jankowska', 'Okulista'),
(147, 339, 'Henryk', 'Nowicki', 'Chirurg'),
(148, 340, 'Izabela', 'Kaczmarek', 'End FIFAolog'),
(149, 341, 'Jacek', 'Wo?niak', 'Urolog'),
(159, 332, 'Adam', 'Kowalski', 'Kardiolog'),
(160, 333, 'Beata', 'Wi?niewska', 'Pediatra'),
(161, 334, 'Cezary', 'Zieli?ski', 'Neurolog'),
(162, 335, 'Dorota', 'Lewandowska', 'Dermatolog'),
(163, 336, 'Edward', 'Szyma?ski', 'Ortopeda'),
(164, 337, 'Feliks', 'Piotrowski', 'Ginekolog'),
(165, 338, 'Gra?yna', 'Jankowska', 'Okulista'),
(166, 339, 'Henryk', 'Nowicki', 'Chirurg'),
(167, 340, 'Izabela', 'Kaczmarek', 'Endokrynolog'),
(168, 341, 'Jacek', 'Wo?niak', 'Urolog');

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
(1, 1, '2025-05-01', 'Wyniki krwi', 'Badanie morfologii', '/documents/pacjent1_morfologia.pdf'),
(2, 3, '2025-05-02', 'RTG p?uc', 'Brak uwag', '/documents/pacjent3_rtg.pdf'),
(3, 342, '2025-05-10', 'Wyniki EKG', 'Podejrzenie arytmii', '/documents/p342_ekg.pdf'),
(4, 344, '2025-05-11', 'Notatki z wizyty', 'Migrena, zalecono sumatryptan', '/documents/p344_notatki.pdf'),
(5, 346, '2025-05-12', 'Wyniki RTG', 'Zapalenie stawu kolanowego', '/documents/p346_rtg.pdf'),
(6, 348, '2025-05-13', 'Badanie wzroku', 'Za?ma w prawym oku', '/documents/p348_wzrok.pdf'),
(7, 350, '2025-05-14', 'Wyniki krwi', 'Niedoczynno?? tarczycy potwierdzona', '/documents/p350_krew.pdf'),
(8, 352, '2025-05-15', 'Wyniki Holter EKG', 'Tachykardia', '/documents/p352_holter.pdf'),
(9, 354, '2025-05-16', 'Wyniki audiometrii', 'Zaburzenia b??dnika', '/documents/p354_audiometria.pdf'),
(10, 356, '2025-05-17', 'Wyniki MRI', 'Dyskopatia L4-L5', '/documents/p356_mri.pdf'),
(11, 358, '2025-05-18', 'Skierowanie na zabieg', 'Operacja za?my', '/documents/p358_skierowanie.pdf'),
(12, 360, '2025-05-19', 'Wyniki USG', 'Wole tarczycy', '/documents/p360_usg.pdf'),
(13, 362, '2025-05-20', 'Wyniki krwi', 'Podwy?szone ci?nienie', '/documents/p362_krew.pdf'),
(14, 363, '2025-05-20', 'Szczepienie', 'Szczepienie przeciwko grypie', '/documents/p363_szczepienie.pdf'),
(15, 364, '2025-05-21', 'Notatki z wizyty', 'Bezsenno??, zalecono melatonin?', '/documents/p364_notatki.pdf'),
(16, 365, '2025-05-21', 'Testy alergiczne', 'Alergia na py?ki', '/documents/p365_alergia.pdf'),
(17, 366, '2025-05-22', 'Wyniki RTG', 'Zapalenie ?ci?gna barku', '/documents/p366_rtg.pdf'),
(18, 367, '2025-05-22', 'Badanie USG', 'Ci??a, wszystko w normie', '/documents/p367_usg.pdf'),
(19, 368, '2025-05-23', 'Badanie wzroku', 'Wada wzroku, zalecono okulary', '/documents/p368_wzrok.pdf'),
(20, 369, '2025-05-23', 'Notatki przedoperacyjne', 'Konsultacja chirurgiczna', '/documents/p369_notatki.pdf'),
(21, 370, '2025-05-24', 'Wyniki krwi', 'Cukrzyca typu 2', '/documents/p370_krew.pdf'),
(22, 371, '2025-05-24', 'Wyniki moczu', 'Brak infekcji', '/documents/p371_mocz.pdf');

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
(1, 1, 1, 1, '2025-05-03 10:00:00', 'RX123456', 'Aspiryna 500mg, 1 tabletka dziennie', 'Przyjmowa? po posi?ku'),
(2, NULL, 3, 1, '2025-05-04 12:00:00', 'RX789012', 'Ibuprofen 400mg, 2 tabletki dziennie', 'W razie b?lu'),
(18, 72, 342, 140, '2025-05-10 09:30:00', 'RX200001', 'Bisoprolol 5mg, 1 tabletka dziennie', 'Przyjmowa? rano'),
(19, 74, 344, 142, '2025-05-11 11:30:00', 'RX200002', 'Sumatryptan 50mg, w razie potrzeby', 'Na migreny'),
(20, 76, 346, 144, '2025-05-12 09:00:00', 'RX200003', 'Ibuprofen 400mg, 2 tabletki dziennie', 'Na b?l kolana'),
(21, 78, 348, 146, '2025-05-13 11:00:00', 'RX200004', 'Krople nawil?aj?ce, 2 razy dziennie', 'Przed zabiegiem za?my'),
(22, 80, 350, 148, '2025-05-14 13:00:00', 'RX200005', 'Lewotyroksyna 100mcg, 1 tabletka dziennie', 'Na niedoczynno?? tarczycy'),
(23, 82, 352, 140, '2025-05-15 09:30:00', 'RX200006', 'Metoprolol 50mg, 1 tabletka dziennie', 'Na tachykardi?'),
(24, 84, 354, 142, '2025-05-16 11:30:00', 'RX200007', 'Dimenhydrynat 50mg, w razie potrzeby', 'Na zawroty g?owy'),
(25, 86, 356, 144, '2025-05-17 09:00:00', 'RX200008', 'Diklofenak 50mg, 2 tabletki dziennie', 'Na b?l plec?w'),
(26, 88, 358, 146, '2025-05-18 11:00:00', 'RX200009', 'Krople sterydowe, 3 razy dziennie', 'Przed operacj? za?my'),
(27, 90, 360, 148, '2025-05-19 13:00:00', 'RX200010', 'Eutyroks 50mcg, 1 tabletka dziennie', 'Na wole tarczycy'),
(28, NULL, 377, 140, '2025-05-20 14:30:00', 'RX200011', 'Amlodypina 5mg, 1 tabletka dziennie', 'Na nadci?nienie'),
(29, NULL, 378, 141, '2025-05-21 15:30:00', 'RX200012', 'Amoksycylina 500mg, 3 razy dziennie', 'Na infekcj?'),
(30, NULL, 379, 142, '2025-05-22 16:30:00', 'RX200013', 'Melatonina 3mg, 1 tabletka przed snem', 'Na bezsenno??'),
(31, NULL, 380, 143, '2025-05-23 17:30:00', 'RX200014', 'Loratadyna 10mg, 1 tabletka dziennie', 'Na alergi?'),
(32, NULL, 381, 144, '2025-05-24 18:30:00', 'RX200015', 'Naproksen 500mg, 1 tabletka dziennie', 'Na b?l barku');

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
(1, 1, 1, 1, '2025-05-03 10:30:00', 'Skierowanie do specjalisty', 'Konsultacja neurologiczna', 'Podejrzenie migren'),
(2, NULL, 3, 1, '2025-05-04 12:30:00', 'Skierowanie na badanie', 'Tomografia komputerowa', 'Kontrola po urazie'),
(20, 72, 342, 140, '2025-05-10 09:30:00', 'Skierowanie na badanie', 'EKG', 'Podejrzenie arytmii'),
(21, 74, 344, 142, '2025-05-11 11:30:00', 'Skierowanie do specjalisty', 'Konsultacja neurologiczna', 'Cz?ste migreny'),
(22, 76, 346, 144, '2025-05-12 09:00:00', 'Skierowanie na fizjoterapi?', 'Rehabilitacja kolana', 'Zapalenie stawu'),
(23, 78, 348, 146, '2025-05-13 11:00:00', 'Skierowanie na zabieg', 'Operacja za?my', 'Pogorszenie wzroku'),
(24, 80, 350, 148, '2025-05-14 13:00:00', 'Skierowanie na badanie', 'USG tarczycy', 'Niedoczynno?? tarczycy'),
(25, 82, 352, 140, '2025-05-15 09:30:00', 'Skierowanie na badanie', 'Holter EKG', 'Tachykardia'),
(26, 84, 354, 142, '2025-05-16 11:30:00', 'Skierowanie na badanie', 'Audiometria', 'Zawroty g?owy'),
(27, 86, 356, 144, '2025-05-17 09:00:00', 'Skierowanie na rezonans', 'MRI kr?gos?upa', 'Dyskopatia'),
(28, 88, 358, 146, '2025-05-18 11:00:00', 'Skierowanie na zabieg', 'Operacja za?my', 'Zaawansowana za?ma'),
(29, 90, 360, 148, '2025-05-19 13:00:00', 'Skierowanie na USG', 'USG tarczycy', 'Wole tarczycy'),
(30, NULL, 372, 140, '2025-05-20 14:00:00', 'Skierowanie na badanie', 'Echo serca', 'Nadci?nienie'),
(31, NULL, 373, 141, '2025-05-21 15:00:00', 'Skierowanie na badanie', 'RTG p?uc', 'Przewlek?y kaszel'),
(32, NULL, 374, 142, '2025-05-22 16:00:00', 'Skierowanie do specjalisty', 'Konsultacja psychiatryczna', 'Problemy ze snem'),
(33, NULL, 375, 143, '2025-05-23 17:00:00', 'Skierowanie na badanie', 'Testy alergiczne', 'Wysypka'),
(34, NULL, 376, 144, '2025-05-24 18:00:00', 'Skierowanie na fizjoterapi?', 'Rehabilitacja barku', 'Zapalenie ?ci?gna');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `userroles`
--

CREATE TABLE `userroles` (
  `UserId` int(11) NOT NULL,
  `RoleName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `userroles`
--

INSERT INTO `userroles` (`UserId`, `RoleName`) VALUES
(1, 'Pacjent'),
(2, 'Lekarz'),
(3, 'Pacjent'),
(332, 'Lekarz'),
(333, 'Lekarz'),
(334, 'Lekarz'),
(335, 'Lekarz'),
(336, 'Lekarz'),
(337, 'Lekarz'),
(338, 'Lekarz'),
(339, 'Lekarz'),
(340, 'Lekarz'),
(341, 'Lekarz'),
(342, 'Pacjent'),
(343, 'Pacjent'),
(344, 'Pacjent'),
(345, 'Pacjent'),
(346, 'Pacjent'),
(347, 'Pacjent'),
(348, 'Pacjent'),
(349, 'Pacjent'),
(350, 'Pacjent'),
(351, 'Pacjent'),
(352, 'Pacjent'),
(353, 'Pacjent'),
(354, 'Pacjent'),
(355, 'Pacjent'),
(356, 'Pacjent'),
(357, 'Pacjent'),
(358, 'Pacjent'),
(359, 'Pacjent'),
(360, 'Pacjent'),
(361, 'Pacjent'),
(362, 'Pacjent'),
(363, 'Pacjent'),
(364, 'Pacjent'),
(365, 'Pacjent'),
(366, 'Pacjent'),
(367, 'Pacjent'),
(368, 'Pacjent'),
(369, 'Pacjent'),
(370, 'Pacjent'),
(371, 'Pacjent'),
(372, 'Pacjent'),
(373, 'Pacjent'),
(374, 'Pacjent'),
(375, 'Pacjent'),
(376, 'Pacjent'),
(377, 'Pacjent'),
(378, 'Pacjent'),
(379, 'Pacjent'),
(380, 'Pacjent'),
(381, 'Pacjent'),
(382, 'Pacjent'),
(383, 'Pacjent'),
(384, 'Pacjent'),
(385, 'Pacjent'),
(386, 'Pacjent'),
(387, 'Pacjent'),
(388, 'Pacjent'),
(389, 'Pacjent'),
(390, 'Pacjent'),
(391, 'Pacjent');

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
  `DateOfBirth` datetime DEFAULT NULL,
  `PESEL` varchar(11) DEFAULT NULL,
  `PhoneNumber` varchar(20) DEFAULT NULL,
  `PasswordHash` varchar(255) DEFAULT NULL,
  `Salt` varchar(128) DEFAULT NULL,
  `Adres` varchar(255) DEFAULT NULL,
  `Miasto` varchar(255) DEFAULT NULL,
  `KodPocztowy` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Imie`, `Nazwisko`, `Email`, `Haslo`, `Rola`, `DateOfBirth`, `PESEL`, `PhoneNumber`, `PasswordHash`, `Salt`, `Adres`, `Miasto`, `KodPocztowy`) VALUES
(1, 'Anna', 'Kowalska', 'anna.kowalska@example.com', NULL, 'Pacjent', '1985-03-15 00:00:00', '85031512345', '123456789', 'hashed_password_1', 'salt_1', 'ul. Lipowa 5', 'Warszawa', '00-123'),
(2, 'Jan', 'Nowak', 'jan.nowak@example.com', NULL, 'Lekarz', '1975-06-20 00:00:00', '75062054321', '987654321', 'hashed_password_2', 'salt_2', 'ul. S?oneczna 10', 'Krak?w', '30-456'),
(3, 'Maria', 'Wi?niewska', 'maria.wisniewska@example.com', NULL, 'Pacjent', '1990-11-10 00:00:00', '90111098765', '555666777', 'hashed_password_3', 'salt_3', 'ul. Kwiatowa 3', 'Gda?sk', '80-789'),
(329, 'Anna', 'Nowak', 'anna.nowak@example.com', 'haslo123', 'pacjent', '1985-06-12 00:00:00', '85061212345', '500100200', NULL, NULL, 'ul. S?oneczna 1', 'Warszawa', '00-001'),
(330, 'Jan', 'Kowalski', 'jan.kowalski@example.com', 'haslo456', 'lekarz', '1978-11-05 00:00:00', '78110554321', '501200300', NULL, NULL, 'ul. Le?na 2', 'Krak?w', '30-002'),
(331, 'Krzysztof', 'Zieli?ski', 'krzysztof.zielinski@example.com', NULL, 'Lekarz', '1970-04-12 00:00:00', '70041212345', '501234567', 'hashed_password_332', 'salt_332', 'ul. Polna 12', 'Warszawa', '00-234'),
(332, 'Ewa', 'Lewandowska', 'ewa.lewandowska@example.com', NULL, 'Lekarz', '1975-08-25 00:00:00', '75082567890', '502345678', 'hashed_password_333', 'salt_333', 'ul. Ogrodowa 8', 'Krak?w', '30-567'),
(333, 'Piotr', 'Wo?niak', 'piotr.wozniak@example.com', NULL, 'Lekarz', '1968-11-03 00:00:00', '68110354321', '503456789', 'hashed_password_334', 'salt_334', 'ul. Le?na 15', 'Gda?sk', '80-890'),
(334, 'Alicja', 'Kami?ska', 'alicja.kaminska@example.com', NULL, 'Lekarz', '1980-02-17 00:00:00', '80021798765', '504567890', 'hashed_password_335', 'salt_335', 'ul. S?oneczna 3', 'Wroc?aw', '50-123'),
(335, 'Marek', 'Jankowski', 'marek.jankowski@example.com', NULL, 'Lekarz', '1972-06-30 00:00:00', '72063045678', '505678901', 'hashed_password_336', 'salt_336', 'ul. Kwiatowa 7', '??d?', '90-456'),
(336, 'Joanna', 'Szyma?ska', 'joanna.szymanska@example.com', NULL, 'Lekarz', '1978-09-14 00:00:00', '78091432109', '506789012', 'hashed_password_337', 'salt_337', 'ul. Parkowa 20', 'Pozna?', '60-789'),
(337, 'Tomasz', 'Kaczmarek', 'tomasz.kaczmarek@example.com', NULL, 'Lekarz', '1965-12-22 00:00:00', '65122278901', '507890123', 'hashed_password_338', 'salt_338', 'ul. Brzozowa 4', 'Szczecin', '70-234'),
(338, 'Katarzyna', 'Piotrowska', 'katarzyna.piotrowska@example.com', NULL, 'Lekarz', '1982-03-05 00:00:00', '82030565432', '508901234', 'hashed_password_339', 'salt_339', 'ul. Lipowa 9', 'Lublin', '20-567'),
(339, 'Micha?', 'Grabowski', 'michal.grabowski@example.com', NULL, 'Lekarz', '1973-07-19 00:00:00', '73071912345', '509012345', 'hashed_password_340', 'salt_340', 'ul. D?bowa 11', 'Katowice', '40-890'),
(340, 'Agnieszka', 'Nowicka', 'agnieszka.nowicka@example.com', NULL, 'Lekarz', '1977-10-28 00:00:00', '77102898765', '510123456', 'hashed_password_341', 'salt_341', 'ul. Sosnowa 6', 'Bydgoszcz', '85-123'),
(341, 'Robert', 'Adamczyk', 'robert.adamczyk@example.com', NULL, 'Lekarz', '1969-01-09 00:00:00', '69010954321', '511234567', 'hashed_password_342', 'salt_342', 'ul. Wiosenna 14', 'Rzesz?w', '35-456'),
(342, 'Monika', 'Zaj?c', 'monika.zajac@example.com', NULL, 'Lekarz', '1985-05-16 00:00:00', '85051632109', '512345678', 'hashed_password_343', 'salt_343', 'ul. Jesienna 2', 'Olsztyn', '10-789'),
(343, '?ukasz', 'Kr?l', 'lukasz.krol@example.com', NULL, 'Lekarz', '1971-08-07 00:00:00', '71080778901', '513456789', 'hashed_password_344', 'salt_344', 'ul. Zielona 18', 'Toru?', '87-234'),
(344, 'Barbara', 'W?jcik', 'barbara.wojcik@example.com', NULL, 'Lekarz', '1974-04-23 00:00:00', '74042365432', '514567890', 'hashed_password_345', 'salt_345', 'ul. R??ana 5', 'Kielce', '25-567'),
(345, 'Grzegorz', 'Kowalczyk', 'grzegorz.kowalczyk@example.com', NULL, 'Lekarz', '1967-02-11 00:00:00', '67021112345', '515678901', 'hashed_password_346', 'salt_346', 'ul. Wi?niowa 13', 'Gdynia', '81-890'),
(346, 'Zofia', 'Mazur', 'zofia.mazur@example.com', NULL, 'Lekarz', '1983-06-29 00:00:00', '83062998765', '516789012', 'hashed_password_347', 'salt_347', 'ul. Topolowa 10', 'Radom', '26-123'),
(347, 'Rafa?', 'Kubiak', 'rafal.kubiak@example.com', NULL, 'Lekarz', '1976-12-04 00:00:00', '76120454321', '517890123', 'hashed_password_348', 'salt_348', 'ul. Kasztanowa 16', 'Zielona G?ra', '65-456'),
(348, 'El?bieta', 'Sikora', 'elzbieta.sikora@example.com', NULL, 'Lekarz', '1979-09-08 00:00:00', '79090832109', '518901234', 'hashed_password_349', 'salt_349', 'ul. Akacjowa 1', 'Opole', '45-789'),
(349, 'Andrzej', 'Lis', 'andrzej.lis@example.com', NULL, 'Lekarz', '1966-03-26 00:00:00', '66032678901', '519012345', 'hashed_password_350', 'salt_350', 'ul. Modrzewiowa 19', 'Bia?ystok', '15-234'),
(350, 'Ma?gorzata', 'Baran', 'malgorzata.baran@example.com', NULL, 'Lekarz', '1981-11-15 00:00:00', '81111565432', '520123456', 'hashed_password_351', 'salt_351', 'ul. Ja?minowa 17', 'Cz?stochowa', '42-567'),
(351, 'Adam', 'Kowalski', 'adam.kowalski@example.com', NULL, 'Lekarz', '1972-05-10 00:00:00', '72051012345', '601234567', 'hashed_password_332', 'salt_332', 'ul. Mickiewicza 10', 'Warszawa', '00-345'),
(352, 'Beata', 'Wi?niewska', 'beata.wisniewska@example.com', NULL, 'Lekarz', '1978-09-22 00:00:00', '78092267890', '602345678', 'hashed_password_333', 'salt_333', 'ul. Krakowska 5', 'Krak?w', '30-678'),
(353, 'Cezary', 'Zieli?ski', 'cezary.zielinski@example.com', NULL, 'Lekarz', '1969-12-15 00:00:00', '69121554321', '603456789', 'hashed_password_334', 'salt_334', 'ul. Morska 20', 'Gda?sk', '80-901'),
(354, 'Dorota', 'Lewandowska', 'dorota.lewandowska@example.com', NULL, 'Lekarz', '1981-03-08 00:00:00', '81030898765', '604567890', 'hashed_password_335', 'salt_335', 'ul. Piotrkowska 15', '??d?', '90-234'),
(355, 'Edward', 'Szyma?ski', 'edward.szymanski@example.com', NULL, 'Lekarz', '1975-07-19 00:00:00', '75071945678', '605678901', 'hashed_password_336', 'salt_336', 'ul. Grunwaldzka 8', 'Pozna?', '60-567'),
(356, 'Feliks', 'Piotrowski', 'feliks.piotrowski@example.com', NULL, 'Lekarz', '1970-11-30 00:00:00', '70113032109', '606789012', 'hashed_password_337', 'salt_337', 'ul. Portowa 12', 'Szczecin', '70-890'),
(357, 'Gra?yna', 'Jankowska', 'grazyna.jankowska@example.com', NULL, 'Lekarz', '1983-02-14 00:00:00', '83021478901', '607890123', 'hashed_password_338', 'salt_338', 'ul. Sienkiewicza 3', 'Lublin', '20-123'),
(358, 'Henryk', 'Nowicki', 'henryk.nowicki@example.com', NULL, 'Lekarz', '1967-06-25 00:00:00', '67062565432', '608901234', 'hashed_password_339', 'salt_339', 'ul. Katowicka 7', 'Katowice', '40-456'),
(359, 'Izabela', 'Kaczmarek', 'izabela.kaczmarek@example.com', NULL, 'Lekarz', '1979-10-03 00:00:00', '79100312345', '609012345', 'hashed_password_340', 'salt_340', 'ul. Toru?ska 9', 'Bydgoszcz', '85-789'),
(360, 'Jacek', 'Wo?niak', 'jacek.wozniak@example.com', NULL, 'Lekarz', '1973-04-27 00:00:00', '73042798765', '610123456', 'hashed_password_341', 'salt_341', 'ul. Rzzy?ska 11', 'Rzesz?w', '35-234'),
(361, 'Anna', 'Kowalska', 'anna.kowalska1@example.com', NULL, 'Pacjent', '1990-01-15 00:00:00', '90011512345', '701234567', 'hashed_password_342', 'salt_342', 'ul. Polna 1', 'Warszawa', '00-111'),
(362, 'Bartosz', 'Nowak', 'bartosz.nowak1@example.com', NULL, 'Pacjent', '1985-03-22 00:00:00', '85032267890', '702345678', 'hashed_password_343', 'salt_343', 'ul. Krakowska 2', 'Krak?w', '30-222'),
(363, 'Celina', 'Wi?niewska', 'celina.wisniewska@example.com', NULL, 'Pacjent', '1978-06-10 00:00:00', '78061054321', '703456789', 'hashed_password_344', 'salt_344', 'ul. Morska 3', 'Gda?sk', '80-333'),
(364, 'Dawid', 'Zieli?ski', 'dawid.zielinski@example.com', NULL, 'Pacjent', '1995-09-05 00:00:00', '95090598765', '704567890', 'hashed_password_345', 'salt_345', 'ul. Piotrkowska 4', '??d?', '90-444'),
(365, 'Eliza', 'Lewandowska', 'eliza.lewandowska@example.com', NULL, 'Pacjent', '1982-11-30 00:00:00', '82113045678', '705678901', 'hashed_password_346', 'salt_346', 'ul. Grunwaldzka 5', 'Pozna?', '60-555'),
(366, 'Filip', 'Szyma?ski', 'filip.szymanski@example.com', NULL, 'Pacjent', '1992-02-14 00:00:00', '92021432109', '706789012', 'hashed_password_347', 'salt_347', 'ul. Portowa 6', 'Szczecin', '70-666'),
(367, 'Gabriela', 'Jankowska', 'gabriela.jankowska@example.com', NULL, 'Pacjent', '1988-04-27 00:00:00', '88042778901', '707890123', 'hashed_password_348', 'salt_348', 'ul. Sienkiewicza 7', 'Lublin', '20-777'),
(368, 'Hubert', 'Nowicki', 'hubert.nowicki@example.com', NULL, 'Pacjent', '1975-07-19 00:00:00', '75071965432', '708901234', 'hashed_password_349', 'salt_349', 'ul. Katowicka 8', 'Katowice', '40-888'),
(369, 'Irena', 'Kaczmarek', 'irena.kaczmarek@example.com', NULL, 'Pacjent', '1998-10-03 00:00:00', '98100312345', '709012345', 'hashed_password_350', 'salt_350', 'ul. Toru?ska 9', 'Bydgoszcz', '85-999'),
(370, 'Jakub', 'Wo?niak', 'jakub.wozniak@example.com', NULL, 'Pacjent', '1980-12-25 00:00:00', '80122598765', '710123456', 'hashed_password_351', 'salt_351', 'ul. Rzzy?ska 10', 'Rzesz?w', '35-000'),
(371, 'Karolina', 'Kowalczyk', 'karolina.kowalczyk@example.com', NULL, 'Pacjent', '1993-01-08 00:00:00', '93010854321', '711234567', 'hashed_password_352', 'salt_352', 'ul. Wiosenna 11', 'Olsztyn', '10-111'),
(372, 'Leon', 'Mazur', 'leon.mazur@example.com', NULL, 'Pacjent', '1987-03-16 00:00:00', '87031632109', '712345678', 'hashed_password_353', 'salt_353', 'ul. Jesienna 12', 'Toru?', '87-222'),
(373, 'Magdalena', 'Kubiak', 'magdalena.kubiak@example.com', NULL, 'Pacjent', '1991-05-29 00:00:00', '91052978901', '713456789', 'hashed_password_354', 'salt_354', 'ul. Zielona 13', 'Kielce', '25-333'),
(374, 'Norbert', 'Sikora', 'norbert.sikora@example.com', NULL, 'Pacjent', '1979-08-12 00:00:00', '79081265432', '714567890', 'hashed_password_355', 'salt_355', 'ul. R??ana 14', 'Gdynia', '81-444'),
(375, 'Olga', 'Lis', 'olga.lis@example.com', NULL, 'Pacjent', '1984-10-20 00:00:00', '84102012345', '715678901', 'hashed_password_356', 'salt_356', 'ul. Wi?niowa 15', 'Radom', '26-555'),
(376, 'Patryk', 'Baran', 'patryk.baran@example.com', NULL, 'Pacjent', '1996-12-07 00:00:00', '96120798765', '716789012', 'hashed_password_357', 'salt_357', 'ul. Topolowa 16', 'Zielona G?ra', '65-666'),
(377, 'Renata', 'Zaj?c', 'renata.zajac@example.com', NULL, 'Pacjent', '1981-02-23 00:00:00', '81022354321', '717890123', 'hashed_password_358', 'salt_358', 'ul. Kasztanowa 17', 'Opole', '45-777'),
(378, 'Szymon', 'Kr?l', 'szymon.krol@example.com', NULL, 'Pacjent', '1989-04-11 00:00:00', '89041132109', '718901234', 'hashed_password_359', 'salt_359', 'ul. Akacjowa 18', 'Bia?ystok', '15-888'),
(379, 'Teresa', 'W?jcik', 'teresa.wojcik@example.com', NULL, 'Pacjent', '1977-06-28 00:00:00', '77062878901', '719012345', 'hashed_password_360', 'salt_360', 'ul. Modrzewiowa 19', 'Cz?stochowa', '42-999'),
(380, 'Urszula', 'Adamczyk', 'urszula.adamczyk@example.com', NULL, 'Pacjent', '1994-09-14 00:00:00', '94091465432', '720123456', 'hashed_password_361', 'salt_361', 'ul. Ja?minowa 20', 'Wroc?aw', '50-000'),
(381, 'Wiktor', 'Grabowski', 'wiktor.grabowski@example.com', NULL, 'Pacjent', '1986-11-02 00:00:00', '86110212345', '721234567', 'hashed_password_362', 'salt_362', 'ul. Lipowa 21', 'Warszawa', '00-112'),
(382, 'Zuzanna', 'Piotrowska', 'zuzanna.piotrowska@example.com', NULL, 'Pacjent', '1997-01-19 00:00:00', '97011998765', '722345678', 'hashed_password_363', 'salt_363', 'ul. Ogrodowa 22', 'Krak?w', '30-223'),
(383, 'Adrian', 'Kami?ski', 'adrian.kaminski@example.com', NULL, 'Pacjent', '1983-03-25 00:00:00', '83032554321', '723456789', 'hashed_password_364', 'salt_364', 'ul. Le?na 23', 'Gda?sk', '80-334'),
(384, 'Barbara', 'Szyma?ska', 'barbara.szymanska@example.com', NULL, 'Pacjent', '1990-05-30 00:00:00', '90053032109', '724567890', 'hashed_password_365', 'salt_365', 'ul. S?oneczna 24', '??d?', '90-445'),
(385, 'Czes?aw', 'Jankowski', 'czeslaw.jankowski@example.com', NULL, 'Pacjent', '1976-08-07 00:00:00', '76080778901', '725678901', 'hashed_password_366', 'salt_366', 'ul. Parkowa 25', 'Pozna?', '60-556'),
(386, 'Dominika', 'Nowicka', 'dominika.nowicka@example.com', NULL, 'Pacjent', '1988-10-15 00:00:00', '88101565432', '726789012', 'hashed_password_367', 'salt_367', 'ul. Brzozowa 26', 'Szczecin', '70-667'),
(387, 'Emil', 'Kaczmarek', 'emil.kaczmarek@example.com', NULL, 'Pacjent', '1993-12-22 00:00:00', '93122212345', '727890123', 'hashed_password_368', 'salt_368', 'ul. D?bowa 27', 'Lublin', '20-778'),
(388, 'Fiona', 'Wo?niak', 'fiona.wozniak@example.com', NULL, 'Pacjent', '1981-02-09 00:00:00', '81020998765', '728901234', 'hashed_password_369', 'salt_369', 'ul. Sosnowa 28', 'Katowice', '40-889'),
(389, 'Gustaw', 'Kowalczyk', 'gustaw.kowalczyk@example.com', NULL, 'Pacjent', '1979-04-26 00:00:00', '79042654321', '729012345', 'hashed_password_370', 'salt_370', 'ul. Wiosenna 29', 'Bydgoszcz', '85-990'),
(390, 'Hanna', 'Mazur', 'hanna.mazur@example.com', NULL, 'Pacjent', '1995-07-03 00:00:00', '95070332109', '730123456', 'hashed_password_371', 'salt_371', 'ul. Jesienna 30', 'Rzesz?w', '35-001'),
(391, 'Ignacy', 'Kubiak', 'ignacy.kubiak@example.com', NULL, 'Pacjent', '1987-09-18 00:00:00', '87091878901', '731234567', 'hashed_password_372', 'salt_372', 'ul. Zielona 31', 'Olsztyn', '10-112'),
(392, 'Jadwiga', 'Sikora', 'jadwiga.sikora@example.com', NULL, 'Pacjent', '1978-11-24 00:00:00', '78112465432', '732345678', 'hashed_password_373', 'salt_373', 'ul. R??ana 32', 'Toru?', '87-223'),
(393, 'Kamil', 'Lis', 'kamil.lis@example.com', NULL, 'Pacjent', '1992-01-31 00:00:00', '92013112345', '733456789', 'hashed_password_374', 'salt_374', 'ul. Wi?niowa 33', 'Kielce', '25-334'),
(394, 'Lidia', 'Baran', 'lidia.baran@example.com', NULL, 'Pacjent', '1984-04-12 00:00:00', '84041298765', '734567890', 'hashed_password_375', 'salt_375', 'ul. Topolowa 34', 'Gdynia', '81-445'),
(395, 'Marcin', 'Zaj?c', 'marcin.zajac@example.com', NULL, 'Pacjent', '1990-06-20 00:00:00', '90062054321', '735678901', 'hashed_password_376', 'salt_376', 'ul. Kasztanowa 35', 'Radom', '26-556'),
(396, 'Natalia', 'Kr?l', 'natalia.krol@example.com', NULL, 'Pacjent', '1982-08-27 00:00:00', '82082732109', '736789012', 'hashed_password_377', 'salt_377', 'ul. Akacjowa 36', 'Zielona G?ra', '65-667'),
(397, 'Oskar', 'W?jcik', 'oskar.wojcik@example.com', NULL, 'Pacjent', '1996-10-04 00:00:00', '96100478901', '737890123', 'hashed_password_378', 'salt_378', 'ul. Modrzewiowa 37', 'Opole', '45-778'),
(398, 'Paulina', 'Adamczyk', 'paulina.adamczyk@example.com', NULL, 'Pacjent', '1989-12-11 00:00:00', '89121165432', '738901234', 'hashed_password_379', 'salt_379', 'ul. Ja?minowa 38', 'Bia?ystok', '15-889'),
(399, 'Rados?aw', 'Grabowski', 'radoslaw.grabowski@example.com', NULL, 'Pacjent', '1977-02-18 00:00:00', '77021812345', '739012345', 'hashed_password_380', 'salt_380', 'ul. Lipowa 39', 'Cz?stochowa', '42-990'),
(400, 'Sandra', 'Piotrowska', 'sandra.piotrowska@example.com', NULL, 'Pacjent', '1994-04-25 00:00:00', '94042598765', '740123456', 'hashed_password_381', 'salt_381', 'ul. Ogrodowa 40', 'Wroc?aw', '50-001'),
(401, 'Tadeusz', 'Kami?ski', 'tadeusz.kaminski@example.com', NULL, 'Pacjent', '1981-07-02 00:00:00', '81070254321', '741234567', 'hashed_password_382', 'salt_382', 'ul. Le?na 41', 'Warszawa', '00-113'),
(402, 'Ula', 'Szyma?ska', 'ula.szymanska@example.com', NULL, 'Pacjent', '1986-09-09 00:00:00', '86090932109', '742345678', 'hashed_password_383', 'salt_383', 'ul. S?oneczna 42', 'Krak?w', '30-224'),
(403, 'Wac?aw', 'Jankowski', 'waclaw.jankowski@example.com', NULL, 'Pacjent', '1979-11-16 00:00:00', '79111678901', '743456789', 'hashed_password_384', 'salt_384', 'ul. Parkowa 43', 'Gda?sk', '80-335'),
(404, 'Zofia', 'Nowicka', 'zofia.nowicka1@example.com', NULL, 'Pacjent', '1993-01-23 00:00:00', '93012365432', '744567890', 'hashed_password_385', 'salt_385', 'ul. Brzozowa 44', '??d?', '90-446'),
(405, 'Alan', 'Kaczmarek', 'alan.kaczmarek@example.com', NULL, 'Pacjent', '1988-03-30 00:00:00', '88033012345', '745678901', 'hashed_password_386', 'salt_386', 'ul. D?bowa 45', 'Pozna?', '60-557'),
(406, 'Basia', 'Wo?niak', 'basia.wozniak@example.com', NULL, 'Pacjent', '1991-06-06 00:00:00', '91060698765', '746789012', 'hashed_password_387', 'salt_387', 'ul. Sosnowa 46', 'Szczecin', '70-668'),
(407, 'Cyprian', 'Kowalczyk', 'cyprian.kowalczyk@example.com', NULL, 'Pacjent', '1980-08-13 00:00:00', '80081354321', '747890123', 'hashed_password_388', 'salt_388', 'ul. Wiosenna 47', 'Lublin', '20-779'),
(408, 'Daria', 'Mazur', 'daria.mazur@example.com', NULL, 'Pacjent', '1997-10-20 00:00:00', '97102032109', '748901234', 'hashed_password_389', 'salt_389', 'ul. Jesienna 48', 'Katowice', '40-880'),
(409, 'Eryk', 'Kubiak', 'eryk.kubiak@example.com', NULL, 'Pacjent', '1985-12-27 00:00:00', '85122778901', '749012345', 'hashed_password_390', 'salt_390', 'ul. Zielona 49', 'Bydgoszcz', '85-991'),
(410, 'Fryderyk', 'Sikora', 'fryderyk.sikora@example.com', NULL, 'Pacjent', '1976-02-03 00:00:00', '76020365432', '750123456', 'hashed_password_391', 'salt_391', 'ul. R??ana 50', 'Rzesz?w', '35-002');

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
  `Specjalizacja` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `wizyty`
--

INSERT INTO `wizyty` (`Id`, `LekarzId`, `PacjentId`, `DataWizyty`, `Status`, `Opis`, `Diagnoza`, `Zalecenia`, `Specjalizacja`) VALUES
(1, 1, 1, '2025-05-03 09:00:00', 'Zako?czona', 'Pacjent zg?asza b?le g?owy', 'Migrena', 'Przyjmowa? aspiryn?, konsultacja neurologiczna', 'Kardiolog'),
(2, 1, 3, '2025-05-04 11:00:00', 'Zaplanowana', 'Kontrola po urazie', NULL, NULL, 'Kardiolog'),
(72, 140, 342, '2025-05-10 09:00:00', 'Zako?czona', 'B?l w klatce piersiowej', 'Podejrzenie arytmii', 'EKG, beta-blokery', 'Kardiolog'),
(73, 141, 343, '2025-05-10 10:00:00', 'Zaplanowana', 'Kontrola po zapaleniu oskrzeli', NULL, NULL, 'Pediatra'),
(74, 142, 344, '2025-05-11 11:00:00', 'Zako?czona', 'Cz?ste b?le g?owy', 'Migrena', 'Sumatryptan, konsultacja neurologiczna', 'Neurolog'),
(75, 143, 345, '2025-05-11 12:00:00', 'Zaplanowana', 'Zmiany sk?rne na twarzy', NULL, NULL, 'Dermatolog'),
(76, 144, 346, '2025-05-12 08:30:00', 'Zako?czona', 'B?l kolana po urazie', 'Zapalenie stawu', 'Fizjoterapia, ibuprofen', 'Ortopeda'),
(77, 145, 347, '2025-05-12 09:30:00', 'Zaplanowana', 'Kontrola ci??y', NULL, NULL, 'Ginekolog'),
(78, 146, 348, '2025-05-13 10:30:00', 'Zako?czona', 'Problemy ze wzrokiem', 'Za?ma', 'Skierowanie na zabieg', 'Okulista'),
(79, 147, 349, '2025-05-13 11:30:00', 'Anulowana', 'Konsultacja przedoperacyjna', NULL, NULL, 'Chirurg'),
(80, 148, 350, '2025-05-14 12:30:00', 'Zako?czona', 'Zm?czenie, wahania wagi', 'Niedoczynno?? tarczycy', 'Lewotyroksyna', 'Endokrynolog'),
(81, 149, 351, '2025-05-14 13:30:00', 'Zaplanowana', 'Kontrola po zapaleniu p?cherza', NULL, NULL, 'Urolog'),
(82, 140, 352, '2025-05-15 09:00:00', 'Zako?czona', 'Ko?atanie serca', 'Tachykardia', 'Holter EKG, leki', 'Kardiolog'),
(83, 141, 353, '2025-05-15 10:00:00', 'Zaplanowana', 'Szczepienie dzieci?ce', NULL, NULL, 'Pediatra'),
(84, 142, 354, '2025-05-16 11:00:00', 'Zako?czona', 'Zawroty g?owy', 'Zaburzenia b??dnika', 'Leki przeciwhistaminowe', 'Neurolog'),
(85, 143, 355, '2025-05-16 12:00:00', 'Zaplanowana', 'Wysypka alergiczna', NULL, NULL, 'Dermatolog'),
(86, 144, 356, '2025-05-17 08:30:00', 'Zako?czona', 'B?l plec?w', 'Dyskopatia', 'Rehabilitacja, diklofenak', 'Ortopeda'),
(87, 145, 357, '2025-05-17 09:30:00', 'Zaplanowana', 'Badanie profilaktyczne', NULL, NULL, 'Ginekolog'),
(88, 146, 358, '2025-05-18 10:30:00', 'Zako?czona', 'Pogorszenie wzroku', 'Za?ma', 'Operacja za?my', 'Okulista'),
(89, 147, 359, '2025-05-18 11:30:00', 'Zaplanowana', 'Konsultacja przedoperacyjna', NULL, NULL, 'Chirurg'),
(90, 148, 360, '2025-05-19 12:30:00', 'Zako?czona', 'Problemy z tarczyc?', 'Wole tarczycy', 'USG tarczycy', 'Endokrynolog'),
(91, 149, 361, '2025-05-19 13:30:00', 'Zaplanowana', 'Kontrola po infekcji nerek', NULL, NULL, 'Urolog'),
(92, 140, 362, '2025-05-20 09:00:00', 'Zako?czona', 'Wysokie ci?nienie', 'Nadci?nienie', 'Amlodypina', 'Kardiolog'),
(93, 141, 363, '2025-05-20 10:00:00', 'Zaplanowana', 'Kaszel u dziecka', NULL, NULL, 'Pediatra'),
(94, 142, 364, '2025-05-21 11:00:00', 'Zako?czona', 'Problemy ze snem', 'Bezsenno??', 'Melatonina, konsultacja psychiatryczna', 'Neurolog'),
(95, 143, 365, '2025-05-21 12:00:00', 'Zaplanowana', 'Kontrola tr?dziku', NULL, NULL, 'Dermatolog'),
(96, 144, 366, '2025-05-22 08:30:00', 'Zako?czona', 'B?l barku', 'Zapalenie ?ci?gna', 'Fizjoterapia', 'Ortopeda'),
(97, 145, 367, '2025-05-22 09:30:00', 'Zaplanowana', 'Kontrola po porodzie', NULL, NULL, 'Ginekolog'),
(98, 146, 368, '2025-05-23 10:30:00', 'Zako?czona', 'Problemy z widzeniem', 'Wada wzroku', 'Okulary korekcyjne', 'Okulista'),
(99, 147, 369, '2025-05-23 11:30:00', 'Zaplanowana', 'Konsultacja przedoperacyjna', NULL, NULL, 'Chirurg'),
(100, 148, 370, '2025-05-24 12:30:00', 'Zako?czona', 'Wahania cukru', 'Cukrzyca typu 2', 'Metformina', 'Endokrynolog'),
(101, 149, 371, '2025-05-24 13:30:00', 'Zaplanowana', 'Kontrola po zapaleniu prostaty', NULL, NULL, 'Urolog');

--
-- Indeksy dla zrzutów tabel
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
-- Indeksy dla tabeli `userroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`UserId`,`RoleName`);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=169;

--
-- AUTO_INCREMENT for table `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `recepty`
--
ALTER TABLE `recepty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `skierowania`
--
ALTER TABLE `skierowania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=411;

--
-- AUTO_INCREMENT for table `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

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
-- Constraints for table `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

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
