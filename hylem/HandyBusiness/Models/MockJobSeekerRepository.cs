﻿using HandyBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class MockJobSeekerRepository : IJobSeekerRepository
    {
        private List<JobSeeker> _jobSeekers;

        public MockJobSeekerRepository()
        {
            _jobSeekers = new List<JobSeeker>()
            {
                new JobSeeker{
                    Id = 1,
                    Firstname = "Josh",
                    Lastname = "Mann",
                    Email = "Jmann@gmail.com",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1990, 09, 22),
                    Phone = "0844194884",
                    SkillDescription = "I write some code",
                    IDNumber = "1234321234123",
                    profilePicture = string.Empty
                },
                 new JobSeeker{
                    Id = 2,
                    Firstname = "Kris",
                    Lastname = "Olaku",
                    Email = "kolaku@gmail.com",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1980, 04, 14),
                    Phone = "0678436284",
                    SkillDescription = "I sing.. Go check out OMO DUDU",
                    IDNumber = "1234556654684",
                    profilePicture = string.Empty
                },
                  new JobSeeker{
                    Id = 1,
                    Firstname = "Dolce",
                    Lastname = "Gabanna",
                    Email = "dg@gmail.com",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(1970, 11, 01),
                    Phone = "02245427532",
                    SkillDescription = "When you think of designers think of me",
                    IDNumber = "3212356790075",
                    profilePicture = string.Empty
                }
            };
        }

        public List<JobSeeker> GetAllJobSeekers()
        {
            return _jobSeekers;
        }
    }
}