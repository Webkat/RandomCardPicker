using Microsoft.AspNetCore.Mvc;

namespace RandomCardPicker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomCardPickerController : ControllerBase
    {
        private static readonly string[] values = new[]
        {
        "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jacks", "queens", "kings", "joker"
        };
        private static readonly string[] suits = new[]
{
        "Clubs", "Diamonds", "Hearts", "Spades"
        };


        [HttpGet]
        public IActionResult GetRandomCard()
        {
            var result = new CardModel();

            Random random = new Random();
            int valueIndex = random.Next(values.Length);

            if (valueIndex == 13)
            {
                result.Card = values[valueIndex];

                return new OkObjectResult(result);
            }

            int suitIndex = random.Next(suits.Length);

            result.Card = suits[suitIndex] + " of " + values[valueIndex];

            return new OkObjectResult(result);
        }
    }
}