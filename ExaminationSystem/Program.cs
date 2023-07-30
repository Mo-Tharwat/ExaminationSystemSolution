using ExaminationSystem.Questions;
using ExaminationSystem.Subjects;
using ExaminationSystem.Exams;
using ExaminationSystem.Helper;
using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Answer Testing ...

            //Answer a1 = new Answer(1, "This is Answer 1 ... ");
            //Answer a2 = new Answer(2, "This is Answer 2 ... ");
            //Answer a3 = new Answer(3, "This is Answer 3 ... ");
            //Answer a4 = new Answer(4, "This is Answer 4 ... ");

            //Console.WriteLine(a1); 

            #endregion

            #region MCQ Question Testing ...

            #region Object class member

            //Answer[] arrayAnswers = { a1, a2, a3, a4 };

            //MCQQuestion mCQ = new MCQQuestion("This is Header Question of MCQ ... ", "This is Body Question of MCQ ... ?", 4, 2, arrayAnswers);

            //Console.WriteLine(mCQ); 


            #endregion

            #region Class Member method

            //StartExam.CreateMCQQuestionWithAnswers();

            #endregion

            #endregion

            #region TF Question Testing ...

            //TFQuestion tFQuestion = new TFQuestion("This is Header Question of TF ... ", "This is Body Question of TF ... ?", 0, 30);

            #endregion


            #region Exam Testing ...

            Subject subject = new Subject();//No.1

            StartExam.CreateSubject(out subject);//No.2

            FinalExam finalExam = new FinalExam();//No.3
            PracticalExam practicalExam = new PracticalExam();//No.4


            StartExam.CreateExam(subject, out finalExam, out practicalExam);//No.5

            StartExam.Run(finalExam, practicalExam);//No.6



            ///StartExam.TimeElapsed = new Stopwatch();
            ///StartExam.TimeElapsed.Start();
            ///do
            ///    Console.WriteLine("Press any number to stop timer ... ");
            ///while (!int.TryParse(Console.ReadLine(), out _));
            ///StartExam.TimeElapsed.Stop();
            ///Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", StartExam.TimeElapsed.Elapsed);
            ///TFQuestion x = new TFQuestion("Header ... :", "Bady ... ?", 10, 1);
            ///StartExam.TFAnswers = new int[1];
            ///x.showQuestion(out StartExam.TFAnswers[0]);
            ///Console.WriteLine($"Your Answer: {StartExam.TFAnswers[0]}");

            ///Answer[] arrayAnswers =
            ///{
            ///    new Answer(1,"A1"),
            ///    new Answer(2,"A2"),
            ///    new Answer(3,"A3"),
            ///    new Answer(4,"A4")
            ///};
            ///
            ///MCQQuestion mCQQuestion = new MCQQuestion("Header ... :", "Body .... ?",15,2, arrayAnswers);
            ///
            ///int result;
            ///
            ///mCQQuestion.showQuestion(out result);
            ///
            ///Console.WriteLine($"The result is: {result}");






            #endregion






        }
    }
}