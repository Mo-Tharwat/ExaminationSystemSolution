using ExaminationSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Questions
{
    class MCQQuestion : BaseQuestion
    {
        #region Attributes & Auto Property

        private int rightAnswer;

        public Answer[] AnswerList { get; set; }

        #endregion

        public MCQQuestion()
        {

        }

        #region Constructor Overloading

        public MCQQuestion(BaseQuestion baseQuestion):base(baseQuestion)
        {
            
        }

        public MCQQuestion(string header, string body, int mark, int rightAnswer, Answer[] answersChoices) : base(header, body, mark)
        {
            RightAnswer = rightAnswer;
            AnswerList = answersChoices;

            while (!RightAnswerValidation())
            {
                int.TryParse(Console.ReadLine(), out this.rightAnswer);
            }
        }
        #endregion


        #region Full Property

        public int RightAnswer
        {
            get { return rightAnswer; }
            set
            {
                rightAnswer = value;

            }
        }

        #endregion

        #region Condition Methods

        public bool RightAnswerValidation()
        {
            if (rightAnswer >= 0 && rightAnswer < AnswerList?.Length)
                return true;
            else
            {
                Console.WriteLine("Please entry the valid naumber of length Answers List ... ");
                return false;
            }
        }

        #endregion

        public void showQuestion(out int result)
        {
            string choices = "";

            foreach(Answer choice in AnswerList)
            {
                choices += choice.AnswerText.ToString()+" \n";
            }

            Console.WriteLine($"Hearder Q: {HeaderQuestion}");
            Console.WriteLine($"Body Q   : {BodyQuestion}");
            Console.WriteLine($"\nplease entry the index of choices answers (from 0 to 3):\n" +
                              $"\n{choices}"+
                              $"\n-------------------------------------------------");

            int _answer;
            while (!int.TryParse(Console.ReadLine(), out _answer))
            {
                Console.WriteLine("Please entry the correct value (numbers only).");
            }

            if (_answer == RightAnswer)
                StartExam.Degree += Mark;

            StartExam.TotalMark += Mark;

            result = _answer;
        }

        public override string ToString()
        {
            string listAnswers = "";
            string correctAnswer = "";

            if(AnswerList is not null)
            {
                foreach (Answer answer in AnswerList)
                {
                    listAnswers += string.Concat(answer, " -\n ");
                }
                correctAnswer = AnswerList[RightAnswer].ToString();
            }

            return $"QHeader :: {HeaderQuestion}\nQBody :: {BodyQuestion}\nMark :: {Mark}\nAnswer Index :: [{correctAnswer}]\nAnswers List :: \n[{listAnswers}]";
        }
    }
}
