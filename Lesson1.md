# Lesson 1: Import và Sử dụng Spine.Unity trong Unity

Trong bài học này, chúng ta sẽ học cách tích hợp Spine Pro vào Unity và xây dựng một controller cơ bản cho nhân vật.

---

## Nội dung chính

- **Cách import Spine-Unity**: Sử dụng `SkeletonAnimation` để điều khiển nhân vật.
- **Di chuyển nhân vật và điều khiển animation**:
  - Animation thường (`idle`, `run`, `jump`).
  - Animation đặc biệt (`portal`, `shoot`).

---

## Giải thích đoạn code

### **1. Các thành phần chính**

1. **`SkeletonAnimation`**
   - Điều khiển hoạt hình nhân vật.
   - Gọi các animation đã được tạo từ Spine Pro.

2. **`Rigidbody2D`**
   - Cung cấp vật lý cơ bản (di chuyển, va chạm, nhảy).

3. **Animation đặc biệt**
   - Chỉ chạy một lần và quay lại trạng thái mặc định (`idle`).

---

### **2. Logic chính trong script**

#### a. **Cấu trúc và trạng thái**
- **State Management**  
  - Biến `currentState` lưu trạng thái nhân vật hiện tại, giúp chuyển đổi animation hợp lý.
  - `isPlayingSpecialAnimation`: Đảm bảo animation đặc biệt không bị gián đoạn bởi các logic khác.

#### b. **Điều khiển animation**
1. **Hàm `SetAnimation`**  
   - Chạy animation cụ thể.
   - Tránh lặp lại animation nếu đã được kích hoạt.

2. **Hàm `PlaySpecialAnimation`**  
   - Kích hoạt animation đặc biệt như `portal` hoặc `shoot`.
   - Sau khi hoàn thành, tự động quay về trạng thái `idle`.

3. **Callback `OnAnimationComplete`**  
   - Được gọi khi animation hoàn tất.
   - Hỗ trợ xử lý logic sau khi animation đặc biệt kết thúc.

---

### **3. Demo chức năng**
#### Click vào hình ảnh để mở video demo
<a href="https://youtu.be/JZWKv9h0B4Q" target="_blank">
  <img src="https://github.com/user-attachments/assets/03261715-e8fe-4e49-9514-415a0b5d1dd6" alt="Demo Video - Spine Animation" width="50%" />
</a>


---

### Source code 
Xem source tại đây: [LS001-SimpleSpineController.cs](https://github.com/UnityToolkit/Unity-Animation-Collection/blob/main/LS001-SimpleSpineController.cs
## Yêu cầu

1. Tải và cài đặt Spine-Unity runtime.
2. Thiết lập nhân vật trong Unity với `SkeletonAnimation` và `Rigidbody2D`.

Hãy nhấn vào hình ảnh để xem video chi tiết! 🎥
