# API_Products

Web API สำหรับจัดการข้อมูลสินค้า (CRUD) สร้างด้วย ASP.NET Core (.NET 10)

## วิธีรัน

```bash
dotnet run
```

เปิดหน้าเอกสาร API ที่ `http://localhost:5082/scalar/v1`

## Endpoints

| Method | Path | ความหมาย |
|---|---|---|
| GET | `/api/products` | ดูสินค้าทั้งหมด |
| GET | `/api/products/{id}` | ดูสินค้าตาม id |
| GET | `/api/products/search?name=` | ค้นหาตามชื่อ |
| GET | `/api/products/expensive?minPrice=` | สินค้าราคาตั้งแต่ที่กำหนด |
| POST | `/api/products` | เพิ่มสินค้า |
| PUT | `/api/products/{id}` | แก้ไขสินค้า |
| DELETE | `/api/products/{id}` | ลบสินค้า |
| DELETE | `/api/products` | ลบทั้งหมด |
