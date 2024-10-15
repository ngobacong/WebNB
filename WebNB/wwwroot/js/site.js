        // Hàm để mở popup
function viewDetails() {
    document.getElementById("view-popup").style.display = "block";
        }

    // Hàm để đóng popup
    function closePopup() {
        document.getElementById("view-popup").style.display = "none";
        }

    // Đóng popup khi bấm ra ngoài modal
    window.onclick = function(event) {
        var popup = document.getElementById("view-popup");
    if (event.target == popup) {
        popup.style.display = "none";
            }
        }

// scripts.js

document.addEventListener('DOMContentLoaded', function () {
    // Dữ liệu mẫu
    const data = [];
    for (let i = 1; i <= 100; i++) {
        data.push({ id: i, name: `Name ${i}`, email: `name${i}@example.com`, dob: `1990-01-${String(i).padStart(2, '0')}` });
    }

    const rowsPerPage = 10; // Số hàng hiển thị trên mỗi trang
    let currentPage = 1; // Trang hiện tại

    // Hàm hiển thị bảng
    function displayTable(page) {
        const tableBody = document.querySelector('#dataTable tbody');
        tableBody.innerHTML = ''; // Xóa hàng trước đó

        const start = (page - 1) * rowsPerPage;
        const end = start + rowsPerPage;
        const paginatedData = data.slice(start, end);

        paginatedData.forEach(row => {
            const tr = document.createElement('tr');
            tr.innerHTML = `
                <td>${row.id}</td>
                <td>${row.name}</td>
                <td>${row.email}</td>
                <td>${row.dob}</td>
            `;
            tableBody.appendChild(tr);
        });

        // Cập nhật số trang hiện tại
        document.getElementById('currentPage').innerText = `Trang ${page}`;
    }

    // Hàm thiết lập nút điều hướng
    function setupNavigation() {
        const totalPages = Math.ceil(data.length / rowsPerPage);
        const prevButton = document.getElementById('prevBtn');
        const nextButton = document.getElementById('nextBtn');

        // Thiết lập trạng thái nút "Trước"
        prevButton.disabled = currentPage === 1;

        // Thiết lập trạng thái nút "Sau"
        nextButton.disabled = currentPage === totalPages;
    }

    // Cập nhật bảng và điều hướng
    function update() {
        displayTable(currentPage);
        setupNavigation();
    }

    // Xử lý sự kiện cho nút "Trước"
    document.getElementById('prevBtn').addEventListener('click', function () {
        if (currentPage > 1) {
            currentPage--;
            update();
        }
    });

    // Xử lý sự kiện cho nút "Sau"
    document.getElementById('nextBtn').addEventListener('click', function () {
        const totalPages = Math.ceil(data.length / rowsPerPage);
        if (currentPage < totalPages) {
            currentPage++;
            update();
        }
    });

    // Hiển thị ban đầu
    update();
});


