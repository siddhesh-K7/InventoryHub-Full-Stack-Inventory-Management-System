import React from 'react';

export default function Dashboard({ products }) {
    const totalProducts = products.length;
    const totalQuantity = products.reduce((acc, p) => acc + p.quantity, 0);
    const totalValue = products.reduce((acc, p) => acc + (p.price * p.quantity), 0);
    const lowStockCount = products.filter(p => p.quantity > 0 && p.quantity < 5).length;
    const outOfStockCount = products.filter(p => p.quantity === 0).length;
    const categories = new Set(products.map(p => p.category)).size;

    return (
        <div className="dashboard-grid">
            <div className="card"><h3>Total Products</h3><p>{totalProducts}</p></div>
            <div className="card"><h3>Total Quantity</h3><p>{totalQuantity}</p></div>
            <div className="card"><h3>Inventory Value</h3><p>${totalValue.toFixed(2)}</p></div>
            <div className="card warning"><h3>Low Stock</h3><p>{lowStockCount}</p></div>
            <div className="card error"><h3>Out of Stock</h3><p>{outOfStockCount}</p></div>
            <div className="card"><h3>Categories</h3><p>{categories}</p></div>
        </div>
    );
}
