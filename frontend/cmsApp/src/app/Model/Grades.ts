
import { Student } from "./Stundent";
import { Subjects } from "./Subjects";

export class Grades {
  id?: number;
  studentId?: number;
  student?: Student;
  subjectsId?: number;
  subjects?: Subjects;
  grade?: number;
}
