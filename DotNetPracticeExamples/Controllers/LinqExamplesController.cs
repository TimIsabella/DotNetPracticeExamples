using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;
using System;
using System.Linq;

namespace DotNetPracticeExamples.Controllers
{
	[Route("api/LinqExamplesController")]
	[ApiController]
	public class LinqExamplesController : ControllerBase
	{
		[HttpGet("RandomNumbers")]
		public IActionResult RandomNumbers()
		{
			//Instantiate 'Random' object
			var rand = new Random();

			//Generate a collection of numbers from 1 - 11
			var numbers = Enumerable.Range(1, 11);

			//Select numbers at random up to 11
			//Underscore is a placeholder for '.Select()' but does not need to be used
			var randomNumbers = numbers.Select(_ => rand.Next(11));

			return StatusCode(200, randomNumbers);
		}

		[HttpGet("MapNumbers")]
		public IActionResult MapNumbers()
		{
			var numbers = Enumerable.Range(1, 11);

			//Multiply each number from above by itself
			//Like a '.Map()', '.Select()' returns the result for each element
			var mappedNumbers = numbers.Select(number => number * number);
			
			return StatusCode(200, mappedNumbers);
		}

		[HttpGet("MapSentenceAndOutputObject")]
		public IActionResult MapSentenceAndOutputObject()
		{
			var sentence = "This sentence has a few words in it";
			var sentenceArray = sentence.Split();

			//Map sentence to output an object including the word and word length
			var mappedSentence = sentenceArray.Select(word => new { 
																	Word = word, 
																	WordLength = word.Length 
																  });

			return StatusCode(404, mappedSentence);
		}

		[HttpGet("MapMultipleNestedStrings")]
		public IActionResult MapMultipleNestedStrings()
		{
			//Jagged array of strings
			var arrayOfStrings = new[] { 
										 "red,green,blue", 
										 "orange",
										 "white,pink"
									   };

			//Using '.SelectMany()' can handle nested logic within an element
			//- Result is a flattened collection of individual strings
			var mappedStrings = arrayOfStrings.SelectMany(word => word.Split(','));

			return StatusCode(404, mappedStrings);
		}

		[HttpGet("MapMultipleArraysTogether")]
		public IActionResult MapMultipleArraysTogether()
		{
			var arrayOfObjects = new[] {
										 "House",
										 "Car",
										 "Cicycle"
									   };

			var arrayOfColors = new[] { 
										"Red", 
										"Green", 
										"Blue" 
									  };

			//Map each color for each object and output results 
			//var pairs = arrayOfColors.SelectMany(_ => arrayOfObjects,
			//											(col, obj) => $"{col} {obj}");		//Map on single line
			
			var pairs = arrayOfColors.SelectMany(_ => arrayOfObjects, 
													  (col, obj) => new						//Map with separate column
																	{
																		Color = col,
																		Object = obj
																	});

			return StatusCode(404, pairs);
		}
	}
}
