using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Questions
{
    class Answer
    {
        #region Attributs

        private int id;

        public string AnswerText { get; set; }

        #endregion

        public Answer()
        {

        }

        #region Constractor Overloading

        public Answer(int id, string answer)
        {
            ID = id;
            AnswerText = answer;

            while (!IDValidation())
            {

            }
        }

        #endregion

        #region Full Property

        public int ID
        {
            get { return id; }
            set
            {
                if (value >= 0)
                    id = value;
                else
                    Console.WriteLine("Error (From Answer Class when set int ID value):\n \tthe value must to be bigger than 0, So please try again ... ");
            }
        }

        #endregion

        #region Condition Methods

        public bool IDValidation()
        {
            if (ID >= 0)
                return true;
            else
            {
                Console.WriteLine("Please entry the valid naumber more than or equal \"0\".");
                return false;
            }
        }

        #endregion


        public override string ToString()
        {
            return $"ID.{id} :: Answer. {AnswerText}";
        }
    }
}
