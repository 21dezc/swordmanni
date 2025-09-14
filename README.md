# swordmanni ⋆.˚
<img width="1072" height="546" alt="image" src="https://github.com/user-attachments/assets/3835da67-0edb-465b-a226-a718bc3db5c8" />

---

## รายละเอียด

### 1. การเคลื่อนไหวของผู้เล่น (PlayerMovement.cs)
- ผู้เล่นสามารถเคลื่อนที่ซ้าย/ขวาด้วยปุ่ม `A` และ `D` หรือปุ่มลูกศร  
- กด `Space` เพื่อกระโดด  
- มีระบบ **Wall Jump** เมื่อติดกำแพง  
- มีการ Flip สเกลตัวละครเมื่อเปลี่ยนทิศทาง  

**อนิเมชันที่ใช้ใน Player**  
- `Idle` → ยืนเฉยๆ  
- `Run` → เดิน/วิ่ง  
- `Jump` → กระโดด  
- `Hurt` → โดนโจมตี  
- `Die` → ตาย และหยุดการเคลื่อนไหว  

---

### 2. หัวจัย (heallth.cs + HealthBar.cs)
- ค่าพลังชีวิตเริ่มต้น (`_startingHealth`)  
- เมื่อโดนโจมตี → เรียก `TakeDamage()`  
- ถ้าพลังชีวิตเหลือ 0 → เล่นอนิเมชัน `die` + ปิดการควบคุมตัวละคร  
- HealthBar UI จะแสดงพลังชีวิตแบบเรียลไทม์  

---

### 3. เลื่อย (Enemy_Sideways.cs)
- ขยับไปมาซ้ายขวาในระยะที่กำหนด  
- ถ้าชนผู้เล่น → ลดพลังชีวิตผู้เล่น (`TakeDamage()`)  

---

### 4. Game Over (GameManager.cs)
- เมื่อผู้เล่นตาย → รออนิเมชัน `Die` จบ → แสดง **Game Over Panel**  
- มีปุ่ม `Try Again` สำหรับ Restart Scene ปัจจุบัน  

---



