namespace RickAndMortyApp.Tests;

[TestClass]
[TestCategory("Integration")]
public class RickAndMortyCharacterServiceIntegrationTests
{
    private RickAndMortyManager _service = null!;

    [TestInitialize]
    public void Setup()
    {
        _service = new RickAndMortyManager();
    }

    // Here we use async Task instead of void because
    // we want to await the GetCharactersAsync method and 
    // ensure that the test waits for the asynchronous operation 
    // to complete before making assertions. 
    // This allows us to properly test the asynchronous behavior 
    // of the method and ensures that we are checking the results
    // after the data has been retrieved.

    [TestMethod]
    public async Task TestVerifyCharacterExistence_ShouldReturnSpecificCharacter()
    {
        // Arrange
        string mockName = "Rick Sanchez";
        // Act
        var character = await _service.GetCharacterByNameAsync(mockName);

        // Assert
        Assert.IsNotNull(character);
        Assert.AreEqual(1, character.Id);
        Assert.AreEqual("Human", character.Species);
    }

    [TestMethod]
    public async Task TestGetEpisodesByCharAndValidate_ShouldReturnEpisode()
    {
        // Arrange
        var mockCharacter = new Character
        {
            Id = 1,
            Name = "Rick Sanchez"
        };

        // Act
        var episodes = await _service.GetEpisodesByCharacterAsync(mockCharacter);

        // Assert
        Assert.IsNotNull(episodes);
        var episode = episodes[0];
            Assert.AreEqual("Pilot", episode.Name);

        var rick = episode.Characters[0].Split('/').Last();
            Assert.AreEqual($"{mockCharacter.Id}", rick);
            
    }

}