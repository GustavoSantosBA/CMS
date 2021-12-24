import { Courses } from "./Courses";
import { Teacher } from "./Teacher";


export class Subjects {
  id?: number;
  name?: string;
  coursesId?: number;
  courses?: Courses;
  teacherId?: number;
  teacher?: Teacher;
}
