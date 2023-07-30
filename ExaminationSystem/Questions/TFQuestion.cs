using ExaminationSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Questions
{
    class TFQuestion : BaseQuestion
    {
        #region Attributes

        private int answer;

        #endregion

        public TFQuestion()
        {

        }

        #region Constructor Overloading

        public TFQuestion(BaseQuestion baseQuestion) : base(baseQuestion)
        {
            
        }

        public TFQuestion(string header, string body, int mark, int answer) : base(header, body, mark)
        {
            Answer = answer;

            while (!AnswerValidation())
            {
                int.TryParse(Console.ReadLine(), out this.answer);
            }
        }

        #endregion

        #region Full Property

        public int Answer
        {
            get { return answer; }
            set
            {
                if (value == 1 || value == 2)
                    answer = value;
                else
                    Console.WriteLine("\nError (From TFQuestion Class, when set int Answer value):\n \tYou must be insert 1 if the answer is \"True\" or 2 if the answer is \"False\", so try again\n");
            }
        }

        #endregion

        #region Conditions Methods

        public bool AnswerValidation()
        {
            if (Answer == 1 || Answer == 2)
                return true;
            else
            {
                Console.WriteLine("Please entry the valid naumber \"1\" for True or \"2\" for False.");
                return false;
            }
        }

        #endregion

        public void showQuestion(out int result)
        {
            Console.WriteLine($"Hearder Q: {HeaderQuestion}");
            Console.WriteLine($"Body Q   : {BodyQuestion}");
            Console.WriteLine("\nplease entry one or two from choices (1 or 2):" +
                              "\n\n1.True \t\t\t\t\t 2.false" +
                              "\n-------------------------------------------------");

            int _answer;
            while(!int.TryParse(Console.ReadLine(), out _answer))
            {
                Console.WriteLine("Please entry the correct value (numbers only).");
            }

            if (_answer == Answer)
                StartExam.Degree += Mark;

            StartExam.TotalMark += Mark;

            result = _answer;
        }

        public override string ToString()
        {
            return $"QHeader : {HeaderQuestion}\nQBody : {BodyQuestion}\nMark : {Mark}\nAnswer : {Answer}";
        }

    }
}
