using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Questions
{
    class BaseQuestion
    {
        #region Attributes with Auto Property

        public string HeaderQuestion { get; set; }
        public string BodyQuestion { get; set; }

        private int mark;

        #endregion

        public BaseQuestion()
        {

        }

        #region Constractor Overloading

        public BaseQuestion(BaseQuestion baseQuestion)
        {
            HeaderQuestion = baseQuestion.HeaderQuestion;
            BodyQuestion = baseQuestion.BodyQuestion;
            Mark = baseQuestion.Mark;
        }

        public BaseQuestion(string headerQ, string bodyQ, int mark)
        {
            HeaderQuestion = headerQ;
            BodyQuestion = bodyQ;
            Mark = mark;
        }

        #endregion

        #region Full Property

        public int Mark
        {
            get { return mark; }
            set
            {
                if (value > 0)
                    mark = value;
                else
                {
                    Console.WriteLine("B.N: Kindly noted we didn't have any mark value less than 1 degree,\n" +
                                      "\t So We will set 2 Mark degree as a defualt value.");
                    mark = 2;
                }
            }
        }

        #endregion

        #region Setter Methods

        //public bool SetMark(int mark)
        //{
        //    if (mark > 0)
        //    {
        //        this.Mark = mark;
        //        return true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("B.N: Kindly noted we didn't have any mark value less than 1 degree,\n" +
        //                          " So We will set 2 Mark degree as a defualt value.");
        //        Mark = 2;
        //        return false;
        //    }

        //} 

        #endregion 

        public override string ToString()
        {
            return $"QHeader : {HeaderQuestion}\nQBody : {BodyQuestion}\nMark : {Mark}";
        }

    }
}
