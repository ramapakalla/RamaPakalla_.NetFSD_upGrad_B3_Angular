// cart.js

//  total cart value using reduce()
export const calculateTotal = (products) =>
  products.reduce(
    (total, product) => total + product.price * product.quantity,
    0
  );

//  formatted invoice using map()
export const generateInvoice = (products) => {
  const formattedItems = products.map(
    (product) =>
      `${product.name} | ₹${product.price} x ${product.quantity} = ₹${
        product.price * product.quantity
      }`
  ).join("\n"); 

  const total = calculateTotal(products);

  return `
------ INVOICE ------
${formattedItems}

Total Items: ${products.length}
Total Cart Value: ₹${total}
---------------------
`;
};