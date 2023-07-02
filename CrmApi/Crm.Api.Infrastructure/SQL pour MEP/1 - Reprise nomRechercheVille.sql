  -- =======================================================           
  -- Projet               : 
  -- Author               : frederic depret
  -- Create date          : 26/05/2020
  -- Description          : CHANGE LE NOM RECHERCHE POUR L'AVOIR SANS tiret et sans apostrophe
  -- History              : 
  -- Version              : 1.1
  -- ======================================================= 
  
  
  BEGIN TRY
  
  	BEGIN TRANSACTION
 
		
        UPDATE [dbo].[City] WITH (ROWLOCK)
		SET SearchName = REPLACE(REPLACE(SearchName, '-', ' '), CHAR(39), ' ')
		WHERE SearchName LIKE '%' + CHAR(39) + '%'  OR SearchName LIKE '%-%'

        UPDATE v
        SET SearchName =  SearchName+ ' '+replace(replace(SearchName, 'saint ', 'st '), 'sainte ', 'ste ')
        FROM city v WITH (ROWLOCK)
        WHERE name like '%SAINT-%' OR  name like '%SAINTE-%' 

    COMMIT TRANSACTION
  END TRY   
  
  BEGIN CATCH
      DECLARE @nvchErrorMessage NVARCHAR(MAX),
              @intErrorSeverity INT,
              @intErrorState INT,
              @intErrorLine INT
  
      SELECT      @nvchErrorMessage = ERROR_MESSAGE(),
                  @intErrorSeverity = ERROR_SEVERITY(),
                  @intErrorState = ERROR_STATE(),
                  @intErrorLine = ERROR_LINE()
      
      ROLLBACK TRANSACTION
      
      RAISERROR ( @nvchErrorMessage, -- Message text.
                       @intErrorSeverity, -- Severity.
                       @intErrorState) -- State.
      PRINT 'Error occured at line (' + CAST(@intErrorLine AS VARCHAR(10)) + ') : ' + @nvchErrorMessage
  END CATCH