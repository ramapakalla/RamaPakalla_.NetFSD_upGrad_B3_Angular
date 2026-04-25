import { DataManager } from "./DataManager.js";
import { User } from "./User.js";
import { Product } from "./Product.js";
import { getFirstElement } from "./getFirstElement.js";

// User Manager
const userManager = new DataManager<User>();

userManager.add({ id: 1, name: "Rama" });
userManager.add({ id: 2, name: "Swathi" });

console.log("Users:", userManager.getAll());

// Product Manager
const productManager = new DataManager<Product>();

productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Phone" });

console.log("Products:", productManager.getAll());

// Testing generic function
const firstUser = getFirstElement(userManager.getAll());
console.log("First User:", firstUser);

const firstProduct = getFirstElement(productManager.getAll());
console.log("First Product:", firstProduct);