using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ExaminationSystem.Exams
{
    abstract class BaseExam
    {
        #region Attributes & Auto Property

        public int TimeExamPerMinute { get; set; }

        public int NumberOfQuestion { get; set; }

        #endregion

        public BaseExam()
        {

        }

        #region Constructor OverLoading

        public BaseExam(int timeElapsed, int numbersOfQuestion)
        {
            TimeExamPerMinute = timeElapsed;
            NumberOfQuestion = numbersOfQuestion;
        }

        #endregion

        //public abstract void RunExam();

    }
}
