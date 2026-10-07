import React, { useState, useEffect } from 'react';

export default function ProductForm({ onSubmit, initialData, onCancel }) {
    const [formData, setFormData] = useState({
        name: '', description: '', category: '', price: 0, quantity: 0, supplier: '', sku: ''
    });

    useEffect(() => { if (initialData) setFormData(initialData); }, [initialData]);

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(formData);
    };

    return (
        <form onSubmit={handleSubmit} className="product-form">
            <input placeholder="Name" required value={formData.name} onChange={e => setFormData({...formData, name: e.target.value})} />
            <input placeholder="Category" required value={formData.category} onChange={e => setFormData({...formData, category: e.target.value})} />
            <input type="number" step="0.01" placeholder="Price" required min="0.01" value={formData.price} onChange={e => setFormData({...formData, price: parseFloat(e.target.value)})} />
            <input type="number" placeholder="Quantity" required min="0" value={formData.quantity} onChange={e => setFormData({...formData, quantity: parseInt(e.target.value)})} />
            <input placeholder="Supplier" required value={formData.supplier} onChange={e => setFormData({...formData, supplier: e.target.value})} />
            <input placeholder="SKU" required value={formData.sku} onChange={e => setFormData({...formData, sku: e.target.value})} />
            <div className="form-actions">
                <button type="submit">Save</button>
                <button type="button" onClick={onCancel}>Cancel</button>
            </div>
        </form>
    );
}
