-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 24, 2025 at 06:36 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.0.30

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

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `userroles`
--

CREATE TABLE `userroles` (
  `UserId` int(11) NOT NULL,
  `RoleName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `recepty`
--
ALTER TABLE `recepty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `skierowania`
--
ALTER TABLE `skierowania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `doctors`
--
ALTER TABLE `doctors`
  ADD CONSTRAINT `doctors_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`);

--
-- Constraints for table `dokumentypacjenta`
--
ALTER TABLE `dokumentypacjenta`
  ADD CONSTRAINT `dokumentypacjenta_ibfk_1` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`);

--
-- Constraints for table `recepty`
--
ALTER TABLE `recepty`
  ADD CONSTRAINT `recepty_ibfk_1` FOREIGN KEY (`WizytaId`) REFERENCES `wizyty` (`Id`),
  ADD CONSTRAINT `recepty_ibfk_2` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`),
  ADD CONSTRAINT `recepty_ibfk_3` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`);

--
-- Constraints for table `skierowania`
--
ALTER TABLE `skierowania`
  ADD CONSTRAINT `skierowania_ibfk_1` FOREIGN KEY (`WizytaId`) REFERENCES `wizyty` (`Id`),
  ADD CONSTRAINT `skierowania_ibfk_2` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`),
  ADD CONSTRAINT `skierowania_ibfk_3` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`);

--
-- Constraints for table `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`);

--
-- Constraints for table `wizyty`
--
ALTER TABLE `wizyty`
  ADD CONSTRAINT `wizyty_ibfk_1` FOREIGN KEY (`LekarzId`) REFERENCES `doctors` (`Id`),
  ADD CONSTRAINT `wizyty_ibfk_2` FOREIGN KEY (`PacjentId`) REFERENCES `users` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
