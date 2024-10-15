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



