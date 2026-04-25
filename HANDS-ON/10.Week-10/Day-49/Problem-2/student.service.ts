import { Student } from "./student.model.js";
import { PASS_MARKS } from "./constants.js";

export function getGrade(marks: number): string {
    return marks >= PASS_MARKS ? "PASS" : "FAIL";
}

export function getTopper(students: Student[]): Student {
    return students.reduce((topper, current) =>
        current.marks > topper.marks ? current : topper
    );
}