import { generateInvoice } from "./cart.js";

const products = [
  { name: "Laptop", price: 50000, quantity: 1 },
  { name: "Smartphone", price: 20000, quantity: 2 },
  { name: "Headphones", price: 3000, quantity: 3 },
  { name: "Keyboard", price: 1500, quantity: 1 },
  { name: "Mouse", price: 800, quantity: 2 },
];

const invoice = generateInvoice(products);

document.body.innerHTML += `<pre>${invoice}</pre>`;