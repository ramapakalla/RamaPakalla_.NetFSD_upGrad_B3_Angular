import { PASS_MARKS } from "./constants.js";
export function getGrade(marks) {
    return marks >= PASS_MARKS ? "PASS" : "FAIL";
}
export function getTopper(students) {
    return students.reduce((topper, current) => current.marks > topper.marks ? current : topper);
}
