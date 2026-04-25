import { getGrade, getTopper } from "./student.service.js";
import { formatName, calculateAverage } from "./utils.js";
// Sample Data
const students = [
    { id: 1, name: "rama", marks: 75 },
    { id: 2, name: "swathi", marks: 85 },
    { id: 3, name: "krishna", marks: 35 }
];
// Formatted Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log(formatName(s.name));
});
// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${formatName(s.name)}: ${getGrade(s.marks)}`);
});
// Average Marks
const avg = calculateAverage(students);
console.log("\nAverage Marks:", avg);
// Topper
const topper = getTopper(students);
console.log("\nTopper:", topper);
