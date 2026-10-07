import React, { useState, useEffect } from 'react';
import { productService } from './services/productService';
import ProductList from './components/ProductList';
import ProductForm from './components/ProductForm';
import Dashboard from './components/Dashboard';
import './index.css';

export default function App() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [editingProduct, setEditingProduct] = useState(null);
    const [isFormVisible, setIsFormVisible] = useState(false);

    useEffect(() => { loadProducts(); }, []);

    const loadProducts = async () => {
        try {
            setLoading(true);
            const res = await productService.getProducts(1, 100); 
            setProducts(res.data.items);
            setError(null);
        } catch (err) {
            setError("Unable to connect to the server.");
        } finally {
            setLoading(false);
        }
    };

    const handleSearch = async (e) => {
        const query = e.target.value;
        if (!query) return loadProducts();
        try {
            const res = await productService.searchProducts(query);
            setProducts(res.data);
        } catch { setError("Search failed."); }
    };

    const handleSave = async (product) => {
        try {
            if (product.id) await productService.updateProduct(product.id, product);
            else await productService.createProduct(product);
            setIsFormVisible(false);
            setEditingProduct(null);
            loadProducts();
        } catch (err) { setError("Please enter valid product information."); }
    };

    const handleDelete = async (id) => {
        if (!window.confirm("Delete this product?")) return;
        try {
            await productService.deleteProduct(id);
            loadProducts();
            alert("Product deleted successfully.");
        } catch (err) { setError("Failed to delete product."); }
    };

    return (
        <div className="container">
            <header>
                <h1>InventoryHub</h1>
                <input type="text" placeholder="Search..." onChange={handleSearch} className="search-bar" />
            </header>
            {error && <div className="alert error">{error}</div>}
            
            <Dashboard products={products} />
            
            <div className="actions-bar">
                <h2>Product Inventory</h2>
                <button onClick={() => { setEditingProduct(null); setIsFormVisible(true); }}>Add Product</button>
            </div>

            {isFormVisible ? (
                <ProductForm initialData={editingProduct} onSubmit={handleSave} onCancel={() => setIsFormVisible(false)} />
            ) : loading ? (
                <p>Loading...</p>
            ) : (
                <ProductList products={products} onEdit={(p) => { setEditingProduct(p); setIsFormVisible(true); }} onDelete={handleDelete} />
            )}
        </div>
    );
}
