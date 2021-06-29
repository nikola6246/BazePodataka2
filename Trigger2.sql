use HospitalDBN

GO

ALTER TRIGGER [dbo].[SestraDezurstva]
ON [dbo].[Zaposlenis_Sestra]
AFTER INSERT,UPDATE
AS 
BEGIN
    DECLARE @varchar AS varchar(50);
    DECLARE @Var INT
    SET @Var =  (SELECT COUNT(*) FROM Zaposlenis_Sestra WHERE brojDezurstava > 10)
    IF(@Var > 0)
    BEGIN
        SET @varchar = 'Broj dezurstava mora biti veci od 10'
        RAISERROR(@varchar,16,1)
    END
END