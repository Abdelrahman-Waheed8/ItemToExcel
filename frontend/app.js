const API_BASE_URL = 'https://localhost:7242/api';

// Elements
const itemForm = document.getElementById('itemForm');
const categorySelect = document.getElementById('categoryId');
const itemsTableBody = document.getElementById('itemsTableBody');
const noItemsMessage = document.getElementById('noItemsMessage');
const exportBtn = document.getElementById('exportBtn');

// Initial Load
document.addEventListener('DOMContentLoaded', () => {
    fetchCategories();
    fetchItems();
});

// Fetch Categories for Dropdown
async function fetchCategories() {
    try {
        const response = await fetch(`${API_BASE_URL}/Category`);
        if (!response.ok) throw new Error('Failed to fetch categories');
        const categories = await response.json();
        
        categories.forEach(cat => {
            const option = document.createElement('option');
            option.value = cat.id;
            option.textContent = cat.name;
            categorySelect.appendChild(option);
        });
    } catch (error) {
        console.error('Error:', error);
        alert('Could not load categories. Make sure the backend is running and CORS is configured.');
    }
}

// Fetch and Display Items
async function fetchItems() {
    try {
        const response = await fetch(`${API_BASE_URL}/Item`);
        if (!response.ok) throw new Error('Failed to fetch items');
        const items = await response.json();
        
        displayItems(items);
    } catch (error) {
        console.error('Error:', error);
    }
}

function displayItems(items) {
    itemsTableBody.innerHTML = '';
    
    if (items.length === 0) {
        noItemsMessage.classList.remove('hidden');
        return;
    }
    
    noItemsMessage.classList.add('hidden');
    
    items.forEach(item => {
        const row = document.createElement('tr');
        row.className = 'hover:bg-slate-50 transition-colors';
        row.innerHTML = `
            <td class="px-6 py-4 font-medium text-slate-900">${item.name}</td>
            <td class="px-6 py-4">
                <span class="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                    ${item.categoryName}
                </span>
            </td>
            <td class="px-6 py-4 text-right">$${item.beforeDiscount.toFixed(2)}</td>
            <td class="px-6 py-4 text-right font-semibold text-slate-900">$${item.afterDiscount.toFixed(2)}</td>
            <td class="px-6 py-4 text-center">
                <button onclick="deleteItem(${item.id})" class="text-red-500 hover:text-red-700 transition-colors">
                    <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 mx-auto" viewBox="0 0 20 20" fill="currentColor">
                        <path fill-rule="evenodd" d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z" clip-rule="evenodd" />
                    </svg>
                </button>
            </td>
        `;
        itemsTableBody.appendChild(row);
    });
}

// Add Item
itemForm.addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const formData = new FormData(itemForm);
    const itemData = {
        name: formData.get('name'),
        catID: parseInt(formData.get('categoryId')),
        beforeDiscount: parseFloat(formData.get('beforeDiscount')),
        afterDiscount: parseFloat(formData.get('afterDiscount'))
    };

    try {
        const response = await fetch(`${API_BASE_URL}/Item`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(itemData)
        });

        if (!response.ok) {
            const error = await response.text();
            throw new Error(error || 'Failed to add item');
        }

        itemForm.reset();
        fetchItems();
    } catch (error) {
        console.error('Error:', error);
        alert('Error adding item: ' + error.message);
    }
});

// Delete Item
async function deleteItem(id) {
    if (!confirm('Are you sure you want to delete this item?')) return;
    
    try {
        const response = await fetch(`${API_BASE_URL}/Item/${id}`, {
            method: 'DELETE'
        });

        if (!response.ok) throw new Error('Failed to delete item');
        fetchItems();
    } catch (error) {
        console.error('Error:', error);
        alert('Error deleting item');
    }
}

// Export to Excel
exportBtn.addEventListener('click', async () => {
    try {
        const response = await fetch(`${API_BASE_URL}/Item/export`);
        if (!response.ok) throw new Error('Failed to export');
        
        const blob = await response.blob();
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'items.xlsx';
        document.body.appendChild(a);
        a.click();
        window.URL.revokeObjectURL(url);
        document.body.removeChild(a);
    } catch (error) {
        console.error('Error:', error);
        alert('Error exporting file');
    }
});
