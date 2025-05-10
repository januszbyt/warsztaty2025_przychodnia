-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Maj 10, 2025 at 09:28 AM
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
(159, 332, 'Adam', 'Kowalski', 'Kardiolog'),
(160, 333, 'Beata', 'Wi?niewska', 'Pediatra'),
(161, 334, 'Cezary', 'Zieli?ski', 'Neurolog'),
(162, 335, 'Dorota', 'Lewandowska', 'Dermatolog'),
(163, 336, 'Edward', 'Szyma?ski', 'Ortopeda'),
(164, 337, 'Feliks', 'Piotrowski', 'Ginekolog'),
(165, 338, 'Gra?yna', 'Jankowska', 'Okulista'),
(166, 339, 'Henryk', 'Nowicki', 'Chirurg'),
(167, 340, 'Izabela', 'Kaczmarek', 'Endokrynolog'),
(168, 341, 'Jacek', 'Wo?niak', 'Urolog'),
(169, 351, 'x', 'x', 'x');

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
(2, 3, '2025-05-02', 'RTG p?uc', 'Brak uwag', '/documents/pacjent3_rtg.pdf');

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
(2, NULL, 3, 1, '2025-05-04 12:00:00', 'RX789012', 'Ibuprofen 400mg, 2 tabletki dziennie', 'W razie b?lu');

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
(2, NULL, 3, 1, '2025-05-04 12:30:00', 'Skierowanie na badanie', 'Tomografia komputerowa', 'Kontrola po urazie');

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
(330, 'Lekarz'),
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
(351, 'Lekarz');

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
(1, 'Anna', 'Kowalska', 'anna.kowalska@example.com', '', 'Pacjent', '1985-03-15 00:00:00', '85031512345', '123456789', 'hashed_password_1', 'salt_1', 'ul. Lipowa 5', 'Warszawa', '00-123'),
(2, 'Jan', 'Nowak', 'jan.nowak@example.com', NULL, 'Lekarz', '1975-06-20 00:00:00', '75062054321', '987654321', 'hashed_password_2', 'salt_2', 'ul. S?oneczna 10', 'Krak?w', '30-456'),
(3, 'Maria', 'Wi?niewska', 'maria.wisniewska@example.com', NULL, 'Pacjent', '1990-11-10 00:00:00', '90111098765', '555666777', 'hashed_password_3', 'salt_3', 'ul. Kwiatowa 3', 'Gda?sk', '80-789'),
(329, 'Anna', 'Nowak', 'anna.nowak@example.com', NULL, 'pacjent', '1985-06-12 00:00:00', '85061212345', '500100200', NULL, NULL, 'ul. S?oneczna 1', 'Warszawa', '00-001'),
(330, 'Jan', 'Kowalski', 'jan.kowalski@example.com', 'haslo456', 'Lekarz', '1978-11-05 00:00:00', '78110554321', '501200300', NULL, NULL, 'ul. Le?na 2', 'Krak?w', '30-002'),
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
(351, 'Adam', 'Kowalski', 'x', 'x', 'Lekarz', '1972-05-10 00:00:00', '72051012345', '601234567', 'hashed_password_332', 'salt_332', 'ul. Mickiewicza 10', 'Warszawa', '00-345'),
(352, 'Beata', 'Wi?niewska', 'beata.wisniewska@example.com', NULL, 'Lekarz', '1978-09-22 00:00:00', '78092267890', '602345678', 'hashed_password_333', 'salt_333', 'ul. Krakowska 5', 'Krak?w', '30-678'),
(353, 'Cezary', 'Zieli?ski', 'cezary.zielinski@example.com', NULL, 'Lekarz', '1969-12-15 00:00:00', '69121554321', '603456789', 'hashed_password_334', 'salt_334', 'ul. Morska 20', 'Gda?sk', '80-901'),
(354, 'Dorota', 'Lewandowska', 'dorota.lewandowska@example.com', NULL, 'Lekarz', '1981-03-08 00:00:00', '81030898765', '604567890', 'hashed_password_335', 'salt_335', 'ul. Piotrkowska 15', '??d?', '90-234'),
(355, 'Edward', 'Szyma?ski', 'edward.szymanski@example.com', NULL, 'Lekarz', '1975-07-19 00:00:00', '75071945678', '605678901', 'hashed_password_336', 'salt_336', 'ul. Grunwaldzka 8', 'Pozna?', '60-567'),
(356, 'Feliks', 'Piotrowski', 'feliks.piotrowski@example.com', NULL, 'Lekarz', '1970-11-30 00:00:00', '70113032109', '606789012', 'hashed_password_337', 'salt_337', 'ul. Portowa 12', 'Szczecin', '70-890'),
(357, 'Gra?yna', 'Jankowska', 'grazyna.jankowska@example.com', NULL, 'Lekarz', '1983-02-14 00:00:00', '83021478901', '607890123', 'hashed_password_338', 'salt_338', 'ul. Sienkiewicza 3', 'Lublin', '20-123'),
(358, 'Henryk', 'Nowicki', 'henryk.nowicki@example.com', NULL, 'Lekarz', '1967-06-25 00:00:00', '67062565432', '608901234', 'hashed_password_339', 'salt_339', 'ul. Katowicka 7', 'Katowice', '40-456'),
(359, 'Izabela', 'Kaczmarek', 'izabela.kaczmarek@example.com', NULL, 'Lekarz', '1979-10-03 00:00:00', '79100312345', '609012345', 'hashed_password_340', 'salt_340', 'ul. Toru?ska 9', 'Bydgoszcz', '85-789'),
(360, 'Jacek', 'Wo?niak', 'jacek.wozniak@example.com', NULL, 'Lekarz', '1973-04-27 00:00:00', '73042798765', '610123456', 'hashed_password_341', 'salt_341', 'ul. Rzzy?ska 11', 'Rzesz?w', '35-234'),
(361, 'wwww', 'ww', 'ww', 'w', 'Pacjent', '2025-05-09 10:39:16', '333', NULL, NULL, NULL, '333', 'dfdd', '3322'),
(362, 'dwad', 'dwadwad', 'adw@dwa.dawd', 'dwad', 'Pacjent', '2025-05-10 08:34:28', '321321', NULL, NULL, NULL, 'dadw', 'dwad', '3213');

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
(2, 1, 3, '2025-05-04 11:00:00', 'Zaplanowana', 'Kontrola po urazie', NULL, NULL, 'Kardiolog');

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=170;

--
-- AUTO_INCREMENT for table `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `recepty`
--
ALTER TABLE `recepty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `skierowania`
--
ALTER TABLE `skierowania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=363;

--
-- AUTO_INCREMENT for table `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

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
