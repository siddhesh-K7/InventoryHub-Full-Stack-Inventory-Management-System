const API_URL = 'http://localhost:5000/api/products';

export const productService = {
    async getProducts(page = 1, pageSize = 10) {
        const res = await fetch(`${API_URL}?page=${page}&pageSize=${pageSize}`);
        return await this.handleResponse(res);
    },
    async getProductById(id) {
        const res = await fetch(`${API_URL}/${id}`);
        return await this.handleResponse(res);
    },
    async createProduct(product) {
        const res = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(product)
        });
        return await this.handleResponse(res);
    },
    async updateProduct(id, product) {
        const res = await fetch(`${API_URL}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(product)
        });
        return await this.handleResponse(res);
    },
    async deleteProduct(id) {
        const res = await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
        return await this.handleResponse(res);
    },
    async searchProducts(query) {
        const res = await fetch(`${API_URL}/search?query=${query}`);
        return await this.handleResponse(res);
    },
    async handleResponse(response) {
        if (!response.ok) {
            const error = await response.text();
            throw new Error(error || 'Network error occurred');
        }
        return await response.json();
    }
};
