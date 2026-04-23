// 1. Variable Declaration
const userName: string = "Rama";
let age: number = 23;
const email: string = "rama@gmail.com";
let isSubscribed: boolean = false;

// 2. Type Inference
let country = "India";        
let loginCount = 5;           

// 3. Increment Age
age = age + 1;

// 4. Check Premium Eligibility
let isEligibleForPremium = age > 18 && isSubscribed;

// 5. Template Literal
const userProfileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}`;


console.log(userProfileMessage);
console.log("Country:", country);
console.log("Login Count:", loginCount);
console.log("Updated Age:", age);
console.log("Is Subscribed:", isSubscribed);
console.log("Eligible for Premium:", isEligibleForPremium);