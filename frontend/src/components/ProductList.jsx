import React from 'react';

export default function ProductList({ products, onEdit, onDelete }) {
    return (
        <table>
            <thead>
                <tr>
                    <th>SKU</th><th>Name</th><th>Category</th><th>Price</th><th>Quantity</th><th>Status</th><th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {products.map(p => (
                    <tr key={p.id}>
                        <td>{p.sku}</td><td>{p.name}</td><td>{p.category}</td><td>${p.price}</td>
                        <td>{p.quantity}</td>
                        <td>
                            {p.quantity === 0 ? <span className="badge error">Out of Stock</span> : 
                             p.quantity < 5 ? <span className="badge warning">Low Stock</span> : 
                             <span className="badge success">In Stock</span>}
                        </td>
                        <td>
                            <button onClick={() => onEdit(p)}>Edit</button>
                            <button onClick={() => onDelete(p.id)}>Delete</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}
