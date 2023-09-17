using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using InterviewProject;
using Newtonsoft.Json;


// initialize the client
HttpClient client = new() { BaseAddress = new Uri("https://candidate.hubteam.com") };

// Retrive partners
HttpResponseMessage response = await client.GetAsync("candidateTest/v3/problem/dataset?userKey=673e04937a3531efcca72a572feb");


var response1 = await client.GetFromJsonAsync<PartnerList>("candidateTest/v3/problem/dataset?userKey=673e04937a3531efcca72a572feb");
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("retrieved list of partners");
}
var jsonResponse = await response.Content.ReadAsStringAsync();


// Process partners
//Console.WriteLine($"{jsonResponse}\n");
var partners = JsonConvert.DeserializeObject<PartnerList>(jsonResponse);

Console.WriteLine($"Total list of partners = {partners.partners.Count}");

partners.partners.Sort();
AttendeeList attendeeList = partners.GetEventPartners();


// Post partners ivite info
string json = JsonConvert.SerializeObject(attendeeList, Formatting.Indented);
StringContent jsonContent = new(json, Encoding.UTF8, "application/json");
response = await client.PostAsync("candidateTest/v3/problem/result?userKey=673e04937a3531efcca72a572feb", jsonContent);
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("posted list of partners successfully!");
}
