// 1. Function with Required Parameter
function getWelcomeMessage(name: string): string {
    return `Welcome, ${name}!`;
}

// 2. Optional Parameters
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} has not provided age.`;
}

// 3. Default Parameters
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed
        ? `${name} is subscribed to the service.`
        : `${name} is not subscribed to the service.`;
}

// 4. Function returning boolean
const isEligibleForPremium = (age: number): boolean => {
    return age > 18;
};

// 5. Arrow Functions
const getAccountUpdate = (name: string): string => {
    return `Account details updated successfully for ${name}.`;
};

// 6. Lexical 'this' using Arrow Function
const notificationService = {
    appName: "MyApp",

    sendNotification: (message: string): string => {
        return `[${notificationService.appName}] ${message}`;
    }
};


console.log(getWelcomeMessage("Rama"));

console.log(getUserInfo("Rama", 22));
console.log(getUserInfo("Rama"));

console.log(getSubscriptionStatus("Rama", true));
console.log(getSubscriptionStatus("Rama"));

console.log("Eligible for Premium:", isEligibleForPremium(22));

console.log(getAccountUpdate("Rama"));

console.log(notificationService.sendNotification("You have a new message!"));