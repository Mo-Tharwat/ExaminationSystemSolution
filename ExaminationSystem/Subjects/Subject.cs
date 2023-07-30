using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Subjects
{
    enum TypeExam
    {
        FinalExam,
        PracticalExam,
    }
    class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public TypeExam TypeExam { get; set; }


        public override string ToString()
        {
            return $"ID Subject :: {ID} - Subject Name :: {Name} - Type Exam :: {TypeExam}";
        }

        public void CreateExam()
        {

        }

    }
}
