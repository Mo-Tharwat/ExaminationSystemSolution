using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.Questions;

namespace ExaminationSystem.Exams
{
    class PracticalExam : BaseExam
    {
        public TFQuestion[] TFQuestions { get; set; }

        public PracticalExam()
        {
            
        }

        public PracticalExam(int time, int numQ, TFQuestion[] questionTF) : base(time, numQ)
        {
            TFQuestions = questionTF;
        }

        public override string ToString()
        {
            string trueFalse = "";
            if (TFQuestions is not null)
                foreach (TFQuestion questionTF in TFQuestions)
                    trueFalse += questionTF.ToString();
            return $"Time :: {TimeExamPerMinute} - NumbersQuestions :: {NumberOfQuestion} \nTrue & False Questions :: \n{trueFalse}";
        }
    }
}
