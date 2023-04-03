CREATE PROCEDURE [dbo].[GetArtistAlbum]

@artistID INT

AS
BEGIN

	SELECT Album.imageURL AS albumImageURL, Album.title AS albumTitle, Album.year
	FROM Album
	WHERE
		artistID = @artistID
		
END


