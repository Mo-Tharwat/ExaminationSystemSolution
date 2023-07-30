using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem.Questions;

namespace ExaminationSystem.Exams
{
    class FinalExam : BaseExam
    {
        public TFQuestion[] TFQuestions { get; set; }

        public MCQQuestion[] MCQQuestions { get; set; }

        public FinalExam()
        {

        }
        public FinalExam(int time, int numQ, TFQuestion[] questionTF, MCQQuestion[] questionMCQ) : base(time, numQ)
        {
            TFQuestions = questionTF;
            MCQQuestions = questionMCQ;
        }

        //public override void RunExam()
        //{
        //    throw new NotImplementedException();
        //}

        public override string ToString()
        {
            string trueFalse = "";
            string mcq = "";
            if(TFQuestions is not null)
                foreach(TFQuestion questionTF in TFQuestions)
                    trueFalse += questionTF.ToString();
            if(MCQQuestions is not null)
                foreach(MCQQuestion conQ in MCQQuestions)
                    mcq += conQ.ToString();

            return $"Time :: {TimeExamPerMinute} - NumbersQuestions :: {NumberOfQuestion} \nTrue & False Questions :: \n{trueFalse}\nMCQ Questions :: \n{mcq}";
        }
    }
}
