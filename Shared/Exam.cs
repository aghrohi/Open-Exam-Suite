﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Shared
{
    public class Exam
    {
        public Properties Properties { get; set; }

        public List<Section> Sections { get; set; }

        public Exam()
        {
            Sections = new List<Section>();
        }

        //Methods
        public void AddSection(string sectionName)
        {
            Section section = Sections.FirstOrDefault(s => s.Title == sectionName);
            if(section == null)
            {
                section = new Section();
                section.Title = sectionName;
                Sections.Add(section);
            }
        }

        public void RemoveSection(string sectionName)
        {
            Section section = Sections.FirstOrDefault(s => s.Title == sectionName);
            if (section != null)
                Sections.Remove(section);
        }

        public void AddQuestion(string sectionName, Question question)
        {
            Section section = Sections.FirstOrDefault(s => s.Title == sectionName);
            if (section == null)
            {
                section = new Section();
                section.Title = sectionName;
                Sections.Add(section);
                question.No = 1;
                section.Questions.Add(question);
            }
            else
            {
                question.No = 1;
                section.Questions.Add(question);
            }
        }

        public void RemoveQuestion(string sectionName, Question question)
        {
            Section section = Sections.FirstOrDefault(s => s.Title == sectionName);
            if (section != null)
            {
                section.Questions.Remove(question);
            }
        }
    }

    public class Properties
    {
        public string Title { get; set; }

        public string Code { get; set; }
        
        public int Version { get; set; }

        public double Passmark { get; set; }

        public int TimeLimit { get; set; }

        public string Instructions { get; set; }
    }

    public class Section
    {
        public string Title { get; set; }

        public List<Question> Questions { get; set; }

        public Section()
        {
            Questions = new List<Question>();
        }
    }

    public class Question
    {
        public int No { get; set; }

        public string Text { get; set; }

        public Bitmap Image { get; set; }

        public char Answer { get; set; }

        public List<Option> Options { get; set; }

        public Question()
        {
            Options = new List<Option>();
        }
    }

    public class Option
    {
        public char Alphabet { get; set; }

        public string Text { get; set; }
    }
}