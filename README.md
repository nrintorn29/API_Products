## API_Products

webapi จัดการสินค้าหลังบ้าน ด้วยระบบ CRUD โดยใช้ .NET SDK (version 10.0) ประกอบด้วย
-EF Core และรูปแบบ async/await สำหรับรองรับหลาย request
-มีหลายชั้นเพื่อง่ายต่อการพัฒนา Interface, Service, Controller
-ใช้ DTO เพื่อกำหนดขอบเขตของข้อมูล

## RUN

ติดตั้งเครื่องมือ EF และ สร้างฐานข้อมูล

```bash

dotnet tool install --global dotnet-ef
dotnet ef database update

```

รัน webapi

```bash

dotnet run

```

ทดลองใช้ api ไปที่ URL `http://localhost:5000/scalar/v1`

## Endpoints

|Method|Url|ความหมาย|
|---|---|---|
|GET|`api/Products`|ดูสินค้าทั้งหมด|
|GET|`api/Products/{id}`|ดูสินค้าตาม {id}|
|GET|`api/Products/search?name=`|ดูสินค้าตาม {name}|
|GET|`api/Products/expensive?minPrice=`|ดูสินค้าตาม {ราคา หรือมากกว่า}|
|POST|`api/Products`|เพิ่มสินค้า|
|PUT|`api/Products`|แก้ไขสินค้า|
|DELETE|`api/Products/{id}`|ลบสินค้าตาม {id}|
|DELETE|`api/Products`|ลบสินค้าทั้งหมด|