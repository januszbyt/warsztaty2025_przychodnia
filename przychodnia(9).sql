-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Maj 16, 2025 at 06:27 PM
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
(5, 10, 15, 5, '2025-05-20 18:30:00', 'RX005', 'Sumatryptan 50 mg', 'W razie migreny');

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
(5, 10, 15, 5, '2025-05-20 18:30:00', 'MRI', 'MRI glowy', 'Pilne, podejrzenie migreny');

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
  `KodPocztowy` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Imie`, `Nazwisko`, `Email`, `Haslo`, `Rola`, `DateOfBirth`, `PESEL`, `PhoneNumber`, `Adres`, `Miasto`, `KodPocztowy`) VALUES
(1, 'Anna', 'Nowak', 'anna.nowak@example.com', 'haslo1234', 'Lekarz', '1985-01-01', '85010112345', '123456789', 'ul. Kwiatowa 1', 'Warszawa', '00-001'),
(2, 'Jan', 'Kowalski', 'jan.kowalski@example.com', 'haslo1234', 'Lekarz', '1980-02-02', '80020254321', '987654321', 'ul. Sloneczna 2', 'Krakow', '30-002'),
(3, 'Katarzyna', 'Wisniewska', 'katarzyna.w@example.com', 'haslo1234', 'Lekarz', '1985-03-03', '85030367890', '555666777', 'ul. Lipowa 3', 'Gdansk', '80-003'),
(4, 'Piotr', 'Zielinski', 'piotr.z@example.com', 'haslo1234', 'Lekarz', '1990-04-04', '90040498765', '111222333', 'ul. Brzozowa 4', 'Wroclaw', '50-004'),
(5, 'Maria', 'Lewandowska', 'maria.l@example.com', 'haslo1234', 'Lekarz', '1995-05-05', '95050523456', '444555666', 'ul. Sosnowa 5', 'Poznan', '60-005'),
(6, 'Tomasz', 'Wojcik', 'tomasz.w@example.com', 'haslo1234', 'Pacjent', '1987-06-06', '87060654321', '222333444', 'ul. Polna 6', 'Lodz', '90-006'),
(7, 'Ewa', 'Kaminska', 'ewa.k@example.com', 'haslo1234', 'Pacjent', '1988-07-07', '88070712345', '333444555', 'ul. Ogrodowa 7', 'Szczecin', '70-007'),
(8, 'Michal', 'Szymanski', 'michal.s@example.com', 'haslo1234', 'Pacjent', '1989-08-08', '89080867890', '444555666', 'ul. Wiosenna 8', 'Katowice', '40-008'),
(9, 'Agnieszka', 'Dabrowska', 'agnieszka.d@example.com', 'haslo1234', 'Pacjent', '1990-09-09', '90090923456', '555666777', 'ul. Jesienna 9', 'Lublin', '20-009'),
(10, 'Krzysztof', 'Jankowski', 'krzysztof.j@example.com', 'haslo1234', 'Pacjent', '1991-01-01', '91010198765', '666777888', 'ul. Zimowa 10', 'Bydgoszcz', '85-010'),
(11, 'Zofia', 'Mazur', 'zofia.m@example.com', 'haslo1234', 'Pacjent', '1992-02-02', '92020254321', '777888999', 'ul. Letnia 11', 'Rzeszow', '35-011'),
(12, 'Lukasz', 'Kaczmarek', 'lukasz.k@example.com', 'haslo1234', 'Pacjent', '1993-03-03', '93030312345', '888999000', 'ul. Parkowa 12', 'Olsztyn', '10-012'),
(13, 'Monika', 'Grabowska', 'monika.g@example.com', 'haslo1234', 'Pacjent', '1994-04-04', '94040467890', '999000111', 'ul. Lesna 13', 'Torun', '87-013'),
(14, 'Pawel', 'Witkowski', 'pawel.w@example.com', 'haslo1234', 'Pacjent', '1995-05-05', '95050523457', '000111222', 'ul. Rzeczna 14', 'Gdynia', '81-014'),
(15, 'Joanna', 'Piotrowska', 'joanna.p@example.com', 'haslo1234', 'Pacjent', '1996-06-06', '96060698765', '111222333', 'ul. Morska 15', 'Sopot', '81-015');

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
(1, 1, 6, '2025-05-11 09:00:00', 'zaplanowana', 'Konsultacja kardiologiczna', NULL, NULL, 'Kardiolog'),
(2, 2, 7, '2025-05-12 10:00:00', 'odbyta', 'Badanie kontrolne dziecka', 'Zdrowe', 'Kontynuacja diety', 'Pediatra'),
(3, 3, 8, '2025-05-13 11:00:00', 'zaplanowana', 'Problemy skorne', NULL, NULL, 'Dermatolog'),
(4, 4, 9, '2025-05-14 12:00:00', 'odbyta', 'Bol kolana', 'Zapalenie stawu', 'Leki przeciwzapalne', 'Ortopeda'),
(5, 5, 10, '2025-05-15 13:00:00', 'zaplanowana', 'Zawroty glowy', NULL, NULL, 'Neurolog'),
(6, 1, 11, '2025-05-16 14:00:00', 'odbyta', 'Kontrola cisnienia', 'Nadcisnienie', 'Zmiana lekow', 'Kardiolog'),
(7, 2, 12, '2025-05-17 15:00:00', 'zaplanowana', 'Szczepienie', NULL, NULL, 'Pediatra'),
(8, 3, 13, '2025-05-18 16:00:00', 'odbyta', 'Wysypka', 'Alergia', 'Masci sterydowe', 'Dermatolog'),
(9, 4, 14, '2025-05-19 17:00:00', 'zaplanowana', 'Bol plecow', NULL, NULL, 'Ortopeda'),
(10, 5, 15, '2025-05-20 18:00:00', 'odbyta', 'Problemy z pamiecia', 'Podejrzenie migreny', 'Badanie MRI', 'Neurolog');

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
-- Indeksy dla tabeli `opinie`
--
ALTER TABLE `opinie`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `idx_opinie_pacjentid` (`PacjentId`),
  ADD KEY `idx_opinie_lekarzid` (`LekarzId`);

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
-- AUTO_INCREMENT for table `recepty`
--
ALTER TABLE `recepty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `skierowania`
--
ALTER TABLE `skierowania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `wizyty`
--
ALTER TABLE `wizyty`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
