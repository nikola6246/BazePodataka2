use HospitalDBN

GO

CREATE TRIGGER [dbo].[PostanskiBr3]
ON [dbo].[Grads]
AFTER INSERT,UPDATE
AS 
BEGIN
    DECLARE @varchar AS varchar(50);
    DECLARE @Var INT
    SET @Var =  (SELECT COUNT(*) FROM Grads WHERE PostanskiBr < 200)
    IF(@Var > 0)
    BEGIN
        SET @varchar = 'Postanski broj mora biti veci od 200 '
        RAISERROR(@varchar,16,1)
    END
END