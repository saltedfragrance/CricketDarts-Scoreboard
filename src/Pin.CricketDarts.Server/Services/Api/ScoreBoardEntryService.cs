﻿
using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;
using System.Net.Http.Json;

namespace Pin.CricketDarts.Server.Services.Api
{
    public class ScoreBoardEntryService : IScoreBoardEntryService
    {
        private string baseUrl = "https://localhost:7117/api/ScoreBoardEntries";
        private readonly HttpClient _httpClient;

        public ScoreBoardEntryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateScoreBoardEntry(ScoreBoardEntry scoreBoardEntry)
        {
            var dto = new ScoreBoardEntryRequestDto
            {
                Id = scoreBoardEntry.Id,
                GameId = scoreBoardEntry.GameId,
                PlayerId = scoreBoardEntry.PlayerId,
                Status = scoreBoardEntry.Status,
                Target = scoreBoardEntry.Target,
            };

            _httpClient.PostAsJsonAsync<ScoreBoardEntryRequestDto>(baseUrl, dto);
        }

        public async Task<List<ScoreBoardEntry>> GetScoreBoardEntries()
        {
            var scoreBoardEntries = await _httpClient.GetFromJsonAsync<ScoreBoardEntryResponseDto[]>($"{baseUrl}");

            return scoreBoardEntries.Select(s => new ScoreBoardEntry
            {
                Id = s.Id,
                GameId = s.GameId,
                PlayerId = s.PlayerId,
                Status = s.Status,
                Target = s.Target
            }).ToList();
        }

        public async Task UpdateScoreBoardEntry(ScoreBoardEntry scoreBoardEntry)
        {
            var dto = new ScoreBoardEntryRequestDto
            {
                Id = scoreBoardEntry.Id,
                Target = scoreBoardEntry.Target,
                Status = scoreBoardEntry.Status,
                PlayerId = scoreBoardEntry.PlayerId,
                GameId = scoreBoardEntry.GameId,
            };

            await _httpClient.PutAsJsonAsync<ScoreBoardEntryRequestDto>($"{baseUrl}", dto);
        }
    }
}
