using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExaminationSystem.Questions;
using ExaminationSystem.Exams;
using ExaminationSystem.Subjects;

namespace ExaminationSystem.Helper
{
    static class StartExam
    {
        public static int Degree { get; set; }

        public static int TotalMark { get; set; }

        public static int NumQ { get; set; }

        public static int[] TFAnswers { get; set; }

        public static int[] MCQAnswers { get; set; }

        public static Stopwatch TimeElapsed { get; set; }


        // public static StartExam()
        //{
        //    NumQ = 0;
        //}

        public static void Stopwatch()
        {
            #region stop Watch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            TimeSpan ts = TimeSpan.FromMinutes(1);

            Console.WriteLine(ts);

            // ... This takes 10 seconds to finish.
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", stopwatch.Elapsed);
            //    System.Threading.Thread.Sleep(10);
            //    Console.Clear();
            //}
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(stopwatch.Elapsed);
                if (stopwatch.Elapsed >= ts)
                {
                    // Stop.
                    stopwatch.Stop();
                    break;
                }
            }

            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.IsRunning);
            // Write hours, minutes and seconds.
            Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", stopwatch.Elapsed);


            #endregion

        }


        #region Questions methods

        public static void CreateBaseQuestion(out BaseQuestion baseQuestion)
        {
            BaseQuestion baseQ = new BaseQuestion();

            Console.WriteLine("\nPlease entry the Question Header ... \n");

            while (baseQ.HeaderQuestion is null || baseQ.HeaderQuestion?.Length <= 1)
                baseQ.HeaderQuestion = Console.ReadLine() ?? "";


            Console.WriteLine("\nPlease entry the Question Body ... \n");

            while (baseQ.BodyQuestion is null || baseQ.BodyQuestion?.Length <= 1)
                baseQ.BodyQuestion = Console.ReadLine() ?? "";

            Console.WriteLine("\nPlease entry the Question Degree ... \n");

            int QMark;
            while (!int.TryParse(Console.ReadLine(), out QMark))
                Console.WriteLine("\nPlease entry the Correct Question Degree ... \n");
            baseQ.Mark = QMark;

            baseQuestion = baseQ;
        }

        public static void CreateTFQuestion(out TFQuestion tfQuestion)
        {
            BaseQuestion baseQuestion = new BaseQuestion();

            CreateBaseQuestion(out baseQuestion);

            TFQuestion _tfquestion = new TFQuestion(baseQuestion);

            Console.WriteLine("Please press 1 if this question is true, or any number if this question false.");

            int typeAnswer;
            while (!int.TryParse(Console.ReadLine(), out typeAnswer))
                Console.WriteLine("Please entry the correct number.");

                switch (typeAnswer)
                {
                    case 1:
                        _tfquestion.Answer = 1;
                        break;
                    default:
                        _tfquestion.Answer = 2;
                        break;
                }

            tfQuestion = _tfquestion;
        }

        public static void CreateMCQQuestion(out MCQQuestion mcQQuestion)
        {
            BaseQuestion baseQuestion = new BaseQuestion();

            CreateBaseQuestion(out baseQuestion);

            MCQQuestion mCQQuestion = new MCQQuestion(baseQuestion);

            mCQQuestion.AnswerList = new Answer[4];

            for (int i = 0; i < mCQQuestion.AnswerList.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Please entry answer number of index ({i})");
                    mCQQuestion.AnswerList[i] = new Answer(i, Console.ReadLine() ?? "");
                } while (mCQQuestion.AnswerList[i].AnswerText is null || mCQQuestion.AnswerList[i].AnswerText == "");

            }

            int answerChoice;
            bool logicAnswer = false;
            while (!logicAnswer)
            {
                Console.WriteLine("Please entry the correct index answer, or press \"Enter\" to set the first answer.");
                int.TryParse(Console.ReadLine(), out answerChoice);
                if (answerChoice >= 0 && answerChoice < mCQQuestion.AnswerList.Length)
                {
                    mCQQuestion.RightAnswer = answerChoice;
                    logicAnswer = true;
                }
            }

            mcQQuestion = mCQQuestion;
        }

        #endregion

        #region Exams Methods

        public static void CreateExam(Subject subject, out FinalExam fExam, out PracticalExam pExam)
        {
            Console.Clear();
            if (subject.TypeExam == TypeExam.FinalExam && subject.Name is not null)
            {
                Console.WriteLine($"You are selected Final Exam in the Subject {subject.Name}, so please input the required data:\n");

                FinalExam finalExam = new FinalExam();

                int time;
                do
                    Console.WriteLine("Please Enter The Time Of Exam in minutes: ");
                while (!int.TryParse(Console.ReadLine(), out time));
                finalExam.TimeExamPerMinute = time;

                int numQ;
                do
                    Console.WriteLine("Please Enter The Number Of Questions You Wanted to Create: ");
                while (!int.TryParse(Console.ReadLine(), out numQ));
                finalExam.NumberOfQuestion = numQ;

                Console.Clear();
                Console.WriteLine($"Now you will insert number of {finalExam.NumberOfQuestion} with (true / false) question.\n" +
                                  $"B.N: the number of answers: \"1\" is true \"other number\" is false.");

                finalExam.TFQuestions = new TFQuestion[finalExam.NumberOfQuestion];

                for (int i = 0; i < finalExam.TFQuestions.Length; i++)
                {
                    Console.WriteLine($"Ture & False Question No.{i+1}\n");
                    CreateTFQuestion(out finalExam.TFQuestions[i]);
                }

                Console.Clear();
                Console.WriteLine($"Now you will insert number of {finalExam.NumberOfQuestion} with MCQ question.\n");

                finalExam.MCQQuestions = new MCQQuestion[finalExam.NumberOfQuestion];

                for (int i = 0;i < finalExam.MCQQuestions.Length; i++)
                {
                    Console.WriteLine($"MCQ Question No.{i + 1}");
                    CreateMCQQuestion(out finalExam.MCQQuestions[i]);
                }
                //Console.WriteLine(finalExam);
                fExam = finalExam;
                pExam = null;
            }
            else if (subject.TypeExam == TypeExam.PracticalExam && subject.Name is not null)
            {
                Console.WriteLine($"You are selected Practical Exam in the Subject {subject.Name}, so please input the required data:\n");
                PracticalExam practicalExam = new PracticalExam();

                int time;
                do
                    Console.WriteLine("Please Enter The Time Of Exam in minutes: ");
                while (!int.TryParse(Console.ReadLine(), out time));
                practicalExam.TimeExamPerMinute = time;

                int numQ;
                do
                    Console.WriteLine("Please Enter The Number Of Questions You Wanted to Create: ");
                while (!int.TryParse(Console.ReadLine(), out numQ));
                practicalExam.NumberOfQuestion = numQ;

                Console.Clear();
                Console.WriteLine($"Now you will insert number of {practicalExam.NumberOfQuestion} with (true / false) question.\nB.N: the number of answers: \"1\" is true \"other number\" is false.");

                practicalExam.TFQuestions = new TFQuestion[practicalExam.NumberOfQuestion];

                for (int i = 0; i < practicalExam.TFQuestions.Length; i++)
                {
                    CreateTFQuestion(out practicalExam.TFQuestions[i]);
                }

                //Console.WriteLine(practicalExam);
                pExam = practicalExam;
                fExam = null;
            }
            else
            {
                Console.WriteLine("Sorry, You are didn't complete create Subject obj for create an Exam.\n");
                pExam = null;
                fExam = null;
            }

        }

        public static int CheckExam(FinalExam finalExam, PracticalExam practicalExam)
        {
            Console.WriteLine("Result Check Exam : 1 is Final Exam available.\n\t\t  2 is Practical Exam available.\n\t\t  0 No Exam available.");
            if (finalExam?.MCQQuestions is not null && finalExam?.TFQuestions is not null)
                return 1;
            else if (practicalExam?.TFQuestions is not null)
                return 2;
            else
                return 0;
        }

        #endregion

        #region Subject Methods

        public static void CreateSubject(out Subject sub)
        {
            Subject subject = new Subject();

            int id;
            do
                Console.WriteLine("Please entry the id of subject.");
            while (!int.TryParse(Console.ReadLine(), out id));
            subject.ID = id;

            do
            {
                Console.WriteLine("Please entry the name of subject.");
                subject.Name = Console.ReadLine() ?? "";
            }
            while (subject.Name == "");

            int type = 0;
            Console.WriteLine("Please entry 0 if the type is \"Final Exam\", or press any number to apply Practical Exam ...");
            while (!int.TryParse(Console.ReadLine(), out type))
                Console.WriteLine("Please entry the correct value (0) if you wont \"Final\" or press any number to apply Practical Exam ...");

            switch (type)
            {
                case 0:
                    subject.TypeExam = (TypeExam)0;
                    break;

                default:
                    subject.TypeExam = (TypeExam)1;
                    break;
            }

            //Console.WriteLine(subject);

            sub = subject;
        }

        #endregion

        public static void ShowTFAnswers(PracticalExam practicalExam)
        {
            Console.Clear();
            Console.WriteLine("The following your answer with question:\nB.N: 1 = true and any number = false.");
            for (int i = 0; i < practicalExam.TFQuestions.Length; i++)
            {
                Console.WriteLine($"HeaderQ  : {practicalExam.TFQuestions[i].HeaderQuestion}\n" +
                                  $"BodyQ    : {practicalExam.TFQuestions[i].BodyQuestion}\n" +
                                  $"YouAnswer: {TFAnswers[i]}\n" +
                                  $"-------------------------------------------------------------\n");
            }
        }

        public static void ShowTFAnswers(FinalExam finalExam)
        {
            Console.Clear();
            Console.WriteLine("================================== TF ==================================");
            Console.WriteLine("The following your answer with question:\nB.N: 1 = true and any number = false.");
            for (int i = 0; i < finalExam.TFQuestions.Length; i++)
            {
                Console.WriteLine($"HeaderQ  : {finalExam.TFQuestions[i].HeaderQuestion}\n" +
                                  $"BodyQ    : {finalExam.TFQuestions[i].BodyQuestion}\n" +
                                  $"YouAnswer: {TFAnswers[i]}\n" +
                                  $"-------------------------------------------------------------\n");
            }
            Console.WriteLine("================================== MCQ ==================================");
            for (int i = 0; i < finalExam.TFQuestions.Length; i++)
            {
                Console.WriteLine($"HeaderQ  : {finalExam.MCQQuestions[i].HeaderQuestion}\n" +
                                  $"BodyQ    : {finalExam.MCQQuestions[i].BodyQuestion}\n" +
                                  $"YouAnswer: {MCQAnswers[i]}\n" +
                                  $"-------------------------------------------------------------\n");
            }

        }

        public static void DoExam(PracticalExam PE)
        {
            if (PE.TFQuestions is not null)
            {
                TFAnswers = new int[PE.NumberOfQuestion];
                for (int i = 0; i < PE.TFQuestions.Length; i++)
                {
                    PE.TFQuestions[i].showQuestion(out TFAnswers[i]);
                }
            }

        }

        public static void DoExam(FinalExam FE)
        {
            if (FE.TFQuestions is not null)
            {
                TFAnswers = new int[FE.NumberOfQuestion];
                for (int i = 0; i < FE.TFQuestions.Length; i++)
                {
                    FE.TFQuestions[i].showQuestion(out TFAnswers[i]);
                }

                MCQAnswers = new int[FE.NumberOfQuestion];
                for(int i = 0;i < FE.MCQQuestions.Length; i++)
                {
                    FE.MCQQuestions[i].showQuestion(out MCQAnswers[i]);
                }

            }

        }

        public static void Run(FinalExam finalExam, PracticalExam practicalExam)
        {   
            int checkTypeExam = CheckExam(finalExam, practicalExam);
            Console.Clear();
            switch (checkTypeExam)
            {
                case 1:
                    Console.WriteLine("Do you want to start Final Exam, please press any number to start ... ");
                    TimeElapsed = new Stopwatch();
                    TimeElapsed.Start();

                    while (!int.TryParse(Console.ReadLine(), out _))
                        Console.WriteLine("Please enter a number ... ");

                    Console.Clear();

                    DoExam(finalExam);

                    TimeElapsed.Stop();

                    while (!int.TryParse(Console.ReadLine(), out _))
                        Console.WriteLine("This is the end of exam, so please enter a number for show your answers ... ");

                    ShowTFAnswers(finalExam);

                    Console.WriteLine($"\nYour Score = {Degree} From total Mark {TotalMark}");
                    Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", TimeElapsed.Elapsed);

                    break;
                case 2:
                    Console.WriteLine("Do you want to start Practical Exam, please press any number to start ... ");
                    TimeElapsed = new Stopwatch();
                    TimeElapsed.Start();

                    while (!int.TryParse(Console.ReadLine(), out _))
                        Console.WriteLine("Please enter a number ... ");

                    Console.Clear() ;

                    DoExam(practicalExam);

                    TimeElapsed.Stop();

                    while (!int.TryParse(Console.ReadLine(), out _))
                        Console.WriteLine("This is the end of exam, so please enter a number for show your answers ... ");

                    ShowTFAnswers(practicalExam);

                    Console.WriteLine($"\nYour Score = {Degree} From total Mark {TotalMark}");
                    Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", TimeElapsed.Elapsed);

                    break;
                default:
                    Console.WriteLine("Sorry, the Exams not ready to use right now.");
                    break;
            }
            
        }

    }
}
