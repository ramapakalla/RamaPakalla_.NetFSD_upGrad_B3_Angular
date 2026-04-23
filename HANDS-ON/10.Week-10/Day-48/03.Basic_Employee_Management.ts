// Employee class
class Employee {
    public id: number;
    protected name: string;
    private _salary: number; // store salary internally

    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this._salary = salary;
    }

    // get salary
    public get salary(): number {
        return this._salary;
    }

    // set salary with validation
    public set salary(value: number) {
        if (value > 0) {
            this._salary = value;
        } else {
            console.log("Salary must be greater than 0");
        }
    }

    // show details
    public displayDetails(): void {
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this._salary}`);
    }
}


// Manager class extends Employee
class Manager extends Employee {
    public teamSize: number;

    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }

    // override display
    public displayDetails(): void {
        super.displayDetails();
        console.log(`Team Size: ${this.teamSize}`);
    }
}


// create objects
const emp1 = new Employee(1, "Rama", 30000);
const mgr1 = new Manager(2, "Bhavana", 60000, 5);

// use employee
emp1.displayDetails();
emp1.salary = 35000;
console.log("Updated Salary:", emp1.salary);

console.log("-----------");

// use manager
mgr1.displayDetails();
mgr1.salary = 70000;
console.log("Updated Manager Salary:", mgr1.salary);