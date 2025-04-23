IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_NAME = 'DokumentyPacjenta'
)
BEGIN
    CREATE TABLE DokumentyPacjenta (
        Id INT PRIMARY KEY IDENTITY(1,1),
        PacjentId INT NOT NULL,
        DataDodania DATE NOT NULL,
        Typ NVARCHAR(100) NOT NULL,
        Uwagi NVARCHAR(MAX),
        SciezkaPliku NVARCHAR(300) NOT NULL
    );
END
