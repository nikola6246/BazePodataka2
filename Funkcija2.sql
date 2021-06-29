CREATE FUNCTION RadniciPreko30000()
RETURNS DECIMAL
AS
	BEGIN
		DECLARE @Cursor INT
		SET @Cursor = 0

		WHILE @Cursor<(SELECT COUNT(*) FROM Zaposlenis WHERE Zaposlenis.PlataZap > 30000)
		BEGIN
			SET @Cursor = @Cursor + 1
		END
		RETURN @Cursor
	END

declare @n int
exec @n = [dbo].[RadniciPreko30000];
select @n