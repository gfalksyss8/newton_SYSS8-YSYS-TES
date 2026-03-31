using Moq;
using Moq.Protected;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyApp.Tests;

[TestClass]
[TestCategory("Unit")]
public sealed class RickAndMortyManagerUnitTests
{
    private RickAndMortyManager _service = null!;
    private Mock<HttpMessageHandler> _mockHandler = null!;
    private HttpClient _httpClient = null!;

    [TestInitialize]
    public void Setup()
    {
        _mockHandler = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_mockHandler.Object);
        _service = new RickAndMortyManager(_httpClient);
    }

    private string GetMockCharacterResponse()
    {
        return @"{
            ""info"": {
                ""count"": 826,
                ""pages"": 42,
                ""next"": ""https://rickandmortyapi.com/api/character?page=2"",
                ""prev"": null
            },
            ""results"": [
                {
                    ""id"": 1,
                    ""name"": ""Rick Sanchez"",
                    ""status"": ""Alive"",
                    ""species"": ""Human"",
                    ""type"": """",
                    ""gender"": ""Male"",
                    ""origin"": {
                        ""name"": ""Earth (C-137)"",
                        ""url"": ""https://rickandmortyapi.com/api/location/1""
                    },
                    ""location"": {
                        ""name"": ""Citadel of Ricks"",
                        ""url"": ""https://rickandmortyapi.com/api/location/3""
                    },
                    ""image"": ""https://rickandmortyapi.com/api/character/avatar/1.jpeg"",
                    ""episode"": [
                        ""https://rickandmortyapi.com/api/episode/1""
                    ],
                    ""url"": ""https://rickandmortyapi.com/api/character/1"",
                    ""created"": ""2017-11-04T18:48:46.250Z""
                },
                {
                    ""id"": 2,
                    ""name"": ""Morty Smith"",
                    ""status"": ""Alive"",
                    ""species"": ""Human"",
                    ""type"": """",
                    ""gender"": ""Male"",
                    ""origin"": {
                        ""name"": ""unknown"",
                        ""url"": """"
                    },
                    ""location"": {
                        ""name"": ""Citadel of Ricks"",
                        ""url"": ""https://rickandmortyapi.com/api/location/3""
                    },
                    ""image"": ""https://rickandmortyapi.com/api/character/avatar/2.jpeg"",
                    ""episode"": [
                        ""https://rickandmortyapi.com/api/episode/1""
                    ],
                    ""url"": ""https://rickandmortyapi.com/api/character/2"",
                    ""created"": ""2017-11-04T18:50:21.651Z""
                }
            ]
        }";
    }

    private string GetMockEpisodeResponse()
    {
        return @"{
              ""info"": {
                ""count"": 51,
                ""pages"": 3,
                ""next"": ""https://rickandmortyapi.com/api/episode?page=2"",
                ""prev"": null
              },
              ""results"": [
                {
                  ""id"": 1,
                  ""name"": ""Pilot"",
                  ""air_date"": ""December 2, 2013"",
                  ""episode"": ""S01E01"",
                  ""characters"": [
                    ""https://rickandmortyapi.com/api/character/1"",
                    ""https://rickandmortyapi.com/api/character/2"",
                    ""https://rickandmortyapi.com/api/character/35"",
                    ""https://rickandmortyapi.com/api/character/38"",
                    ""https://rickandmortyapi.com/api/character/62"",
                    ""https://rickandmortyapi.com/api/character/92"",
                    ""https://rickandmortyapi.com/api/character/127"",
                    ""https://rickandmortyapi.com/api/character/144"",
                    ""https://rickandmortyapi.com/api/character/158"",
                    ""https://rickandmortyapi.com/api/character/175"",
                    ""https://rickandmortyapi.com/api/character/179"",
                    ""https://rickandmortyapi.com/api/character/181"",
                    ""https://rickandmortyapi.com/api/character/239"",
                    ""https://rickandmortyapi.com/api/character/249"",
                    ""https://rickandmortyapi.com/api/character/271"",
                    ""https://rickandmortyapi.com/api/character/338"",
                    ""https://rickandmortyapi.com/api/character/394"",
                    ""https://rickandmortyapi.com/api/character/395"",
                    ""https://rickandmortyapi.com/api/character/435""
                  ],
                  ""url"": ""https://rickandmortyapi.com/api/episode/1"",
                  ""created"": ""2017-11-10T12:56:33.798Z""
                },
                {
                  ""id"": 2,
                  ""name"": ""Lawnmower Dog"",
                  ""air_date"": ""December 9, 2013"",
                  ""episode"": ""S01E02"",
                  ""characters"": [
                    ""https://rickandmortyapi.com/api/character/1"",
                    ""https://rickandmortyapi.com/api/character/2"",
                    ""https://rickandmortyapi.com/api/character/38"",
                    ""https://rickandmortyapi.com/api/character/46"",
                    ""https://rickandmortyapi.com/api/character/63"",
                    ""https://rickandmortyapi.com/api/character/80"",
                    ""https://rickandmortyapi.com/api/character/175"",
                    ""https://rickandmortyapi.com/api/character/221"",
                    ""https://rickandmortyapi.com/api/character/239"",
                    ""https://rickandmortyapi.com/api/character/246"",
                    ""https://rickandmortyapi.com/api/character/304"",
                    ""https://rickandmortyapi.com/api/character/305"",
                    ""https://rickandmortyapi.com/api/character/306"",
                    ""https://rickandmortyapi.com/api/character/329"",
                    ""https://rickandmortyapi.com/api/character/338"",
                    ""https://rickandmortyapi.com/api/character/396"",
                    ""https://rickandmortyapi.com/api/character/397"",
                    ""https://rickandmortyapi.com/api/character/398"",
                    ""https://rickandmortyapi.com/api/character/405""
                  ],
                  ""url"": ""https://rickandmortyapi.com/api/episode/2"",
                  ""created"": ""2017-11-10T12:56:33.916Z""
                },
                {
                  ""id"": 3,
                  ""name"": ""Anatomy Park"",
                  ""air_date"": ""December 16, 2013"",
                  ""episode"": ""S01E03"",
                  ""characters"": [
                    ""https://rickandmortyapi.com/api/character/1"",
                    ""https://rickandmortyapi.com/api/character/2"",
                    ""https://rickandmortyapi.com/api/character/12"",
                    ""https://rickandmortyapi.com/api/character/17"",
                    ""https://rickandmortyapi.com/api/character/38"",
                    ""https://rickandmortyapi.com/api/character/45"",
                    ""https://rickandmortyapi.com/api/character/96"",
                    ""https://rickandmortyapi.com/api/character/97"",
                    ""https://rickandmortyapi.com/api/character/98"",
                    ""https://rickandmortyapi.com/api/character/99"",
                    ""https://rickandmortyapi.com/api/character/100"",
                    ""https://rickandmortyapi.com/api/character/101"",
                    ""https://rickandmortyapi.com/api/character/108"",
                    ""https://rickandmortyapi.com/api/character/112"",
                    ""https://rickandmortyapi.com/api/character/114"",
                    ""https://rickandmortyapi.com/api/character/169"",
                    ""https://rickandmortyapi.com/api/character/175"",
                    ""https://rickandmortyapi.com/api/character/186"",
                    ""https://rickandmortyapi.com/api/character/201"",
                    ""https://rickandmortyapi.com/api/character/268"",
                    ""https://rickandmortyapi.com/api/character/300"",
                    ""https://rickandmortyapi.com/api/character/302"",
                    ""https://rickandmortyapi.com/api/character/338"",
                    ""https://rickandmortyapi.com/api/character/356""
                  ],
                  ""url"": ""https://rickandmortyapi.com/api/episode/3"",
                  ""created"": ""2017-11-10T12:56:34.022Z""
                },
                {
                  ""id"": 4,
                  ""name"": ""M. Night Shaym-Aliens!"",
                  ""air_date"": ""January 13, 2014"",
                  ""episode"": ""S01E04"",
                  ""characters"": [
                    ""https://rickandmortyapi.com/api/character/1"",
                    ""https://rickandmortyapi.com/api/character/2"",
                    ""https://rickandmortyapi.com/api/character/38"",
                    ""https://rickandmortyapi.com/api/character/87"",
                    ""https://rickandmortyapi.com/api/character/175"",
                    ""https://rickandmortyapi.com/api/character/179"",
                    ""https://rickandmortyapi.com/api/character/181"",
                    ""https://rickandmortyapi.com/api/character/191"",
                    ""https://rickandmortyapi.com/api/character/239"",
                    ""https://rickandmortyapi.com/api/character/241"",
                    ""https://rickandmortyapi.com/api/character/270"",
                    ""https://rickandmortyapi.com/api/character/337"",
                    ""https://rickandmortyapi.com/api/character/338""
                  ],
                  ""url"": ""https://rickandmortyapi.com/api/episode/4"",
                  ""created"": ""2017-11-10T12:56:34.129Z""
                },
                {
                  ""id"": 5,
                  ""name"": ""Mock Episode"",
                  ""air_date"": ""December 32, 2000"",
                  ""episode"": ""S00E00"",
                  ""characters"": [
                    ""https://rickandmortyapi.com/api/character/2""
                  ],
                  ""url"": ""https://rickandmortyapi.com/api/episode/0"",
                  ""created"": ""2017-11-10T12:56:34.022Z""
                },
            ]
        }";
    }

    private void SetupMockHandler(string jsonResponse, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = statusCode,
            Content = new StringContent(jsonResponse, System.Text.Encoding.UTF8, "application/json")
        };

        _mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync", 
                ItExpr.IsAny<HttpRequestMessage>(), 
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponseMessage);
    }

    [TestMethod]
    public async Task TestGetCharacterByName_ShouldReturnCharacterId()
    {
        // Arrange
        SetupMockHandler(GetMockCharacterResponse());

        // Act
        var character = await _service.GetCharacterByNameAsync("Rick Sanchez");

        // Assert
        Console.WriteLine(character.Name, character.Id);
        Assert.AreEqual(1, character.Id);
        Assert.AreEqual("Rick Sanchez", character.Name);
    }

    [TestMethod]
    public async Task GetEpisodeByCharacter_ShouldReturnListOfEpisodes()
    {
        // Arrange
        SetupMockHandler(GetMockEpisodeResponse());
        var mockCharacter = new Character
        {
            Id = 1,
            Name = "Rick Sanchez"
        };

        // Act
        var episodes = await _service.GetEpisodesByCharacterAsync(mockCharacter);

        // Assert
        foreach (var episode in episodes)
        {
            Console.WriteLine(episode.EpisodeCode + episode.Name);
        }
        Assert.IsNotNull(episodes);
        Assert.IsNotEmpty(episodes);
        Assert.HasCount(4, episodes);
    }
}
