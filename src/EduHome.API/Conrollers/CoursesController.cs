﻿using EduHome.Business.Exceptions;
using EduHome.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EduHome.API.Conrollers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly ICourseService _courseService;

		public CoursesController(ICourseService courseService)
		{
			_courseService = courseService;
		}
		//[HttpGet,Route("GetCourses")]
		[HttpGet("")]
		public async Task<IActionResult> Get()
		{
			try
			{
				var courses = await _courseService.GetAllAsync();
				return Ok(courses);
			}
			catch (NotFoundException ex)
			{

				return NotFound(ex.Message);
			}

		}

		//[HttpGet]
		//public async Task<IActionResult> Get()
		//{
		//	var courses = await _courseService.GetAllAsync();

		//	if (courses == null || courses.Count==0 )
		//	{
		//		throw new NotFoundException("not found");
		//	}
		//	return Ok(courses);
		//}

		//public async Task  Create()
		//{

		//}
	}
}
