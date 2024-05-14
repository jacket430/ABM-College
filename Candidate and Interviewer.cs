using System;
using System.Collections.Generic;

class Interviewer
{
    public string Name { get; set; }
    public Interviewer(string name)
    {
        Name = name;
    }
}

class Candidate
{
    public string Name { get; set; }
    public Candidate(string name)
    {
        Name = name;
    }
}

class Question
{
    public string QuestionText { get; set; }
    public string ResponseText { get; set; }

    public Question(string questionText, string responseText)
    {
        QuestionText = questionText;
        ResponseText = responseText;
    }
}

class Interview
{
    public Interviewer Interviewer { get; set; }
    public Candidate Candidate { get; set; }
    public List<Question> Questions { get; set; }

    public Interview(Interviewer interviewer, Candidate candidate, List<Question> questions)
    {
        Interviewer = interviewer;
        Candidate = candidate;
        Questions = questions;
    }

    public void PrintInterview()
    {
        foreach (var question in Questions)
        {
            Console.WriteLine($"The Interviewer, {Interviewer.Name}, asked \"{question.QuestionText}\" and the Candidate, {Candidate.Name}, responded \"{question.ResponseText}\".");
        }
    }
}

class Program
{
    static void Main()
    {
        Interviewer interviewer = new Interviewer("Avery");
        Candidate candidate = new Candidate("Basant");

        List<Question> questions = new List<Question>
        {
            new Question("What is your favorite color?", "Blue"),
            new Question("What is your greatest strength?", "Programming"),
            new Question("What is your favorite season?", "Summer"),
            new Question("What is your favorite food?", "Apples")
        };

        Interview interview = new Interview(interviewer, candidate, questions);

        interview.PrintInterview();
    }
}