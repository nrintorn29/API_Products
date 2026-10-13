# API_Products

Web API สำหรับจัดการข้อมูลสินค้า (CRUD) สร้างด้วย ASP.NET Core (.NET 10)

## วิธีรัน

ติดตั้งเครื่องมือ EF Core (ครั้งเดียว) แล้วสร้างฐานข้อมูล:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

จากนั้นรันโปรเจกต์:

```bash
dotnet run
```

เปิดหน้าเอกสาร API ที่ `http://localhost:{PORT}/scalar/v1`
PORT ดูได้หลักจากรันเสร็จแล้ว ที่ Terminal

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
